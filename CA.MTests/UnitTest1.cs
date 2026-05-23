using System;
using System.Diagnostics;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using CA.Modes;
using CA.UI;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CA.MTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            CellFieldUI mainForm = new CellFieldUI();
            mainForm.InitForTesting(new TM_GAS());
            mainForm.GenerateRandomValueForMatrix(1, 20000);
            TimeSpan totalElapsed = MeasureExecTime(mainForm.GoToNextGeneration, 200);
            mainForm.Close();
            mainForm.Dispose();
            Assert.IsTrue(totalElapsed <= TimeSpan.FromSeconds(7.3));
            //Console.Write(totalElapsed.ToString());
        }

        private static TimeSpan MeasureExecTime(Action action, int iterations)
        {
            action(); // warm up
            var sw = Stopwatch.StartNew();
            for (int i = 0; i < iterations; i++)
            {
                action();
            }
            return sw.Elapsed;
        }

    }
}
