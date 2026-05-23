using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using CA.Modes;

namespace CA.UI
{
    public unsafe partial class CellFieldUI : Form
    {
        public void GenerateRandomValueForMatrix(int index, int itemsCountToFill)
        {
            switch (index)
            {
                case 1:
                    {
                        this.rbPlane0.Checked = true;
                        break;
                    }
                case 2:
                    {
                        this.rbPlane0.Checked = true;
                        break;
                    }
                case 3:
                    {
                        this.rbPlane0.Checked = true;
                        break;
                    }
                case 4:
                    {
                        this.rbPlane0.Checked = true;
                        break;
                    }
                default:
                    break;
            }

            for (int i = 0; i < itemsCountToFill; i++)
            {
                SetRandomValueToSelectedMatrix(this, EventArgs.Empty);
            }
        }

        public void GoToNextGeneration()
        {
            GoToNextGeneration(null, EventArgs.Empty);
        }

        public void InitForTesting(ITestableModel testable)
        {
            try
            {
                AllocateMemoryForMatrices();
                CurrentFieldOptions = new FieldOptions(true, 700);
                userColorPalette = userColorPalette = new UserColorPalette(new Color[] { Color.Purple, Color.LimeGreen, Color.Black, Color.DarkOrchid, Color.Red, Color.Blue, Color.OrangeRed, Color.MediumSpringGreen, Color.DarkGreen, Color.Tan });
                currAmountOfCellsGorizomtal = 700;
                currAmountOfCellsVertical = 700;
                rbPlane0.Checked = true;
                AlgorithmConfiguration alg = new AlgorithmConfiguration("2, 3", "3");
                alg.CurrentAlgorithm = testable;
                ConfigureSystemForAlgorithm(alg);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
