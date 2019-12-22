using System;
using System.Collections.Generic;
using System.Text;
using CA.Modes;

namespace CA.UI
{
    [Serializable]
    public class AlgorithmConfiguration
    {
        //Правила зміни генерацій
        public string CurrRule = "Власні правила";
        public string RuleForSurv, RuleForBirth;
        public bool Shleif_1;
        public bool Shleif_2;
        public ITestableModel CurrentAlgorithm;

        public AlgorithmConfiguration(string mas1, string mas2)
        {
            RuleForSurv = mas1;
            RuleForBirth = mas2;
            CurrentAlgorithm = new WaveSample();
        }
    }
}
