using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using CA.Modes;
using System.Xml.Linq;
using System.Xml;
using System.IO;
using CA.UI.Infrastructure;
using Ionic.Zip;

namespace CA.UI
{
    public class InOutDataContainer
    {
        private XDocument _outFileDescription = new XDocument();
        private CellFieldUI _caMachineState;

        public InOutDataContainer(CellFieldUI formContainer)
        {
            _caMachineState = formContainer;
        }

        public void SerializeStateToXDocument()
        {
            _outFileDescription = new XDocument(new XDeclaration("1.0", "utf-8", "yes"));
            XElement xElemRoot = new XElement("CAMachineStateDescRoot");
            _outFileDescription.Add(xElemRoot);

            //---------Field options
            XElement fieldInfo = new XElement("CAFieldInfo");
            xElemRoot.Add(fieldInfo);
            fieldInfo.Add(new XElement("ShowInnerBorders", _caMachineState.CurrentFieldOptions.ShowMatrixBorders));
            fieldInfo.Add(new XElement("SizeOfACell", _caMachineState.CurrentCellSize));
            fieldInfo.Add(new XElement("SizeOfTheField", _caMachineState.CurrentCellSize));
            fieldInfo.Add(new XElement("NumberOfDimensions", _caMachineState.NumberOfDimensions));


            //--------- Algorithm
            XElement algorithmConfig = new XElement("CAAlgorithmConfiguration");
            xElemRoot.Add(algorithmConfig);
            algorithmConfig.Add(new XElement("ShowLoop1", _caMachineState.CurrAlgorithmConfiguration.Shleif_1));
            algorithmConfig.Add(new XElement("ShowLoop2", _caMachineState.CurrAlgorithmConfiguration.Shleif_2));
            algorithmConfig.Add(new XElement("TempRuleParameters", string.Format("{0}?{1}", _caMachineState.CurrAlgorithmConfiguration.RuleForBirth,
                _caMachineState.CurrAlgorithmConfiguration.RuleForSurv)));
            algorithmConfig.Add(new XElement("TransitionsAutoChangeInterval", _caMachineState.AutoTransitionsInterval));
            algorithmConfig.Add(new XElement("AlgorithmTypeMetaInfo",
                new XElement("FullName", _caMachineState.CurrAlgorithmConfiguration.CurrentAlgorithm.GetType().FullName),
                new XElement("ModuleName", _caMachineState.CurrAlgorithmConfiguration.CurrentAlgorithm.GetType().Module.Name)));
        }

        public void SaveToFile(string filePath)
        {
            SerializeStateToXDocument();

            if (_outFileDescription != null)
            {
                _outFileDescription.Save(filePath, SaveOptions.None);
            }
        }

        internal void InitFromSavedState(XDocument savedStateInfo)
        {
            _outFileDescription = savedStateInfo;
            _caMachineState.NumberOfDimensions = int.Parse(savedStateInfo.Element("CAMachineStateDescRoot")
                .Element("CAFieldInfo").Element("NumberOfDimensions").Value);

            string[] tempParams = savedStateInfo.Element("CAMachineStateDescRoot")
                .Element("CAAlgorithmConfiguration").Element("TempRuleParameters").Value.Split('?');
            AlgorithmConfiguration config = new AlgorithmConfiguration(tempParams[0], tempParams[1]);
            config.Shleif_1 = bool.Parse(savedStateInfo.Element("CAMachineStateDescRoot")
                .Element("CAAlgorithmConfiguration").Element("ShowLoop1").Value);
            config.Shleif_2 = bool.Parse(savedStateInfo.Element("CAMachineStateDescRoot")
                .Element("CAAlgorithmConfiguration").Element("ShowLoop2").Value);
            string moduleName = savedStateInfo.Element("CAMachineStateDescRoot")
                .Element("CAAlgorithmConfiguration").Element("AlgorithmTypeMetaInfo").Element("ModuleName").Value;
            string typeName = savedStateInfo.Element("CAMachineStateDescRoot")
                .Element("CAAlgorithmConfiguration").Element("AlgorithmTypeMetaInfo").Element("FullName").Value;

            Type algorithmType = Type.GetType(string.Format("{0},{1}", typeName, Path.GetFileNameWithoutExtension(moduleName)));

            if (algorithmType == null)
            {
                // try to find this algorithm in all the list of all available algorithms.
                ITestableModel targetModel = ModelPluginLoader.FindPlaginByTypeName(typeName);
                if (targetModel == null)
                {
                    throw new TypeLoadException("The target Module wasn't found. " + typeName);
                }
                config.CurrentAlgorithm = targetModel;
            }
            else
            {
                config.CurrentAlgorithm = (ITestableModel) Activator.CreateInstance(algorithmType);
            }

            if (savedStateInfo.Element("CAMachineStateDescRoot")
                 .Element("CAAlgorithmConfiguration")
                 .Element("TransitionsAutoChangeInterval") != null)
            {
                _caMachineState.AutoTransitionsInterval = int.Parse(savedStateInfo.Element("CAMachineStateDescRoot")
                                                              .Element("CAAlgorithmConfiguration")
                                                              .Element("TransitionsAutoChangeInterval").
                                                              Value);
            }

            //TODO Sam: check LoadAlgorithm method for DEMOGRAPHIA algorithm config!!!!
            _caMachineState.LoadAlgorithm(config);

            bool showInnerBorders = bool.Parse(savedStateInfo.Element("CAMachineStateDescRoot")
                .Element("CAFieldInfo").Element("ShowInnerBorders").Value);
            short sizeOfACell = short.Parse(savedStateInfo.Element("CAMachineStateDescRoot")
                .Element("CAFieldInfo").Element("SizeOfACell").Value);
            int sizeOfField = int.Parse(savedStateInfo.Element("CAMachineStateDescRoot")
                .Element("CAFieldInfo").Element("SizeOfTheField").Value);
            FieldOptions fieldOptions = new FieldOptions(showInnerBorders, sizeOfField);

            _caMachineState.ConfigureForCellSize(sizeOfACell);
            _caMachineState.ConfigureField(fieldOptions);
        }
    }

    public class SaveRestoreHelper
    {
        private const string _machinestateConf = "machinestate.config";
        private const string _matrDataFile = "matrices.data";

        public static void SaveCAMachineState(CellFieldUI currentUIState, string filePath)
        {
            InOutDataContainer infoContainer = new InOutDataContainer(currentUIState);
            infoContainer.SaveToFile(_machinestateConf);

            Stream stream = new FileStream(_matrDataFile,
                FileMode.Create, FileAccess.Write, FileShare.None);
            currentUIState.SaveFieldsDataToStream(stream);
            stream.Close();

            using (ZipFile zip = new ZipFile())
            {
                // add XML machine configuration to output zip file
                zip.AddFile(_machinestateConf);
                // add matrices content to file
                zip.AddFile(_matrDataFile);
                zip.Save(filePath);
            }

            RemoveFile(_machinestateConf);
            RemoveFile(_matrDataFile);
        }

        private static void RemoveFile(string filepath)
        {
            try
            {
                File.Delete(filepath);
            }
            catch (Exception)
            {
                //TODO log exceptions....
            }
        }

        public static void RestoreMachineState(CellFieldUI currentUIState, string filePath)
        {
            InOutDataContainer infoContainer = new InOutDataContainer(currentUIState);
            using (ZipFile zip = ZipFile.Read(filePath))
            {
                Stream xmlConfigStream = new MemoryStream();
                zip[_machinestateConf].Extract(xmlConfigStream);

                xmlConfigStream.Position = 0;
                infoContainer.InitFromSavedState(XDocument.Load(xmlConfigStream));

                Stream caMatrDataStream = new MemoryStream();
                zip[_matrDataFile].Extract(caMatrDataStream);
                caMatrDataStream.Position = 0;
                currentUIState.InitDimensionsFromStream(caMatrDataStream);

                xmlConfigStream.Close();
                caMatrDataStream.Close();
            }
            currentUIState.DisplaySystemState();
        }
    }
}
