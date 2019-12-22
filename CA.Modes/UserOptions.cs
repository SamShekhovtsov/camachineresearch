using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace CA.Modes
{
    [Serializable]
    public class UserOptions : ITestableModel
    {
        // Fields
        private List<int> forStillBirth;
        private List<int> forSurvival;

        // Methods
        public UserOptions()
        {
            this.forSurvival = new List<int>();
            this.forStillBirth = new List<int>();
        }

        public UserOptions(List<int> ForSurvival, List<int> ForStillBirth)
        {
            this.forSurvival = new List<int>();
            this.forStillBirth = new List<int>();
            this.forStillBirth = ForStillBirth;
            this.forSurvival = ForSurvival;
        }

        public UserOptions(string ForSurvival, string ForStillBirth)
        {
            this.forSurvival = new List<int>();
            this.forStillBirth = new List<int>();
            this.ForStillBirth = ForStillBirth;
            this.ForSurvival = ForSurvival;
        }

        private void Convert(List<int> list, string value)
        {
            list.Clear();
            string[] strArray = value.Split(new char[] { ',' });
            foreach (string str in strArray)
            {
                string[] strArray2 = str.Split(new char[] { '-' });
                if (strArray2.Length == 1)
                {
                    list.Add(int.Parse(strArray2[0]));
                }
                else
                {
                    for (int i = int.Parse(strArray2[0]); i <= int.Parse(strArray2[1]); i++)
                    {
                        list.Add(i);
                    }
                }
            }
        }

        public int GetCapacity()
        {
            return 1;
        }

        public void Test(ref IntPtr Dim0, ref IntPtr Dim1, ref IntPtr Dim2, ref IntPtr Dim3, ref IntPtr Dim4, ref IntPtr Dim5,
                  ref IntPtr Dim6, ref IntPtr Dim7, ref IntPtr Dim8,
                  ref IntPtr Dim9, ref IntPtr Dim10, int iterationsCount, int height, int width,
                  IntPtr SdlScreenPixelBuffer, IntPtr colors)
        {
            //int length = listOfMatrices[0].GetLength(0);
            //int width = listOfMatrices[0].GetLength(1);
            //b = new Bitmap(width, length);
            //for (int i = 0; i < iterationsCount; i++)
            //{
            //    for (int j = 0; j < width; j++)
            //    {
            //        for (int k = 0; k < length; k++)
            //        {
            //            List<int> forSurvival;
            //            if (listOfMatrices[0][j, k] > 0)
            //            {
            //                forSurvival = this.forSurvival;
            //            }
            //            else
            //            {
            //                forSurvival = this.forStillBirth;
            //            }
            //            int num6 = 0;
            //            num6 += listOfMatrices[0][(j == 0) ? (width - 1) : (j - 1), k];
            //            num6 += listOfMatrices[0][(j == (width - 1)) ? 0 : (j + 1), k];
            //            num6 += listOfMatrices[0][j, (k == 0) ? (length - 1) : (k - 1)];
            //            num6 += listOfMatrices[0][j, (k == (length - 1)) ? 0 : (k + 1)];
            //            num6 += listOfMatrices[0][(j == 0) ? (width - 1) : (j - 1), (k == 0) ? (length - 1) : (k - 1)];
            //            num6 += listOfMatrices[0][(j == (width - 1)) ? 0 : (j + 1), (k == (length - 1)) ? 0 : (k + 1)];
            //            num6 += listOfMatrices[0][(j == 0) ? (width - 1) : (j - 1), (k == (length - 1)) ? 0 : (k + 1)];
            //            num6 += listOfMatrices[0][(j == (width - 1)) ? 0 : (j + 1), (k == 0) ? (length - 1) : (k - 1)];
            //            listOfMatrices[4][j, k] = 0;
            //            foreach (int num7 in forSurvival)
            //            {
            //                if (num6 == num7)
            //                {
            //                    listOfMatrices[4][j, k] = 1;
            //                    break;
            //                }
            //            }
            //            if ((i == (iterationsCount - 1)) && (listOfMatrices[4][j, k] == 1))
            //            {
            //                b.SetPixel(k, j, Colors[0]);
            //            }
            //        }
            //    }
            //    short[,] numArray = listOfMatrices[0];
            //    listOfMatrices[0] = listOfMatrices[4];
            //    listOfMatrices[4] = numArray;
            //}
        }

        public override string ToString()
        {
            return Localization.Locales.Resources.Rules_UserOptions_Description;
        }

        // Properties
        public string ForStillBirth
        {
            set
            {
                this.Convert(this.forStillBirth, value);
            }
        }

        public string ForSurvival
        {
            set
            {
                this.Convert(this.forSurvival, value);
            }
        }

        #region ITestableModel Members

        public void Show(ref IntPtr Dim0, ref IntPtr Dim1, ref IntPtr Dim2, ref IntPtr Dim3, ref IntPtr Dim4, ref IntPtr Dim5, ref IntPtr Dim6, ref IntPtr Dim7, ref IntPtr Dim8, ref IntPtr Dim9, ref IntPtr Dim10, int height, int width, IntPtr SdlScreenPixelBuffer, IntPtr colors)
        {
            throw new NotImplementedException();
        }

        public string Name
        {
            get { return Localization.Locales.Resources.Rules_UserOptions_Name; }
        }
        #endregion
    }
}
