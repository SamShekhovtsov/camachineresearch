using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace CA.Modes
{
    [Serializable]
    public class Naiv_Deffusion : ITestableModel
    {
        // Fields
        private short ccwA;
        private short ccwB;
        private short cwA;
        private short cwB;
        private short oppA;
        private short oppB;

        // Methods
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
            //            switch (listOfMatrices[2][j, k])
            //            {
            //                case 0:
            //                    this.cwA = listOfMatrices[0][j, (k == (length - 1)) ? 0 : (k + 1)];
            //                    this.ccwA = listOfMatrices[0][(j == (width - 1)) ? 0 : (j + 1), k];
            //                    this.oppA = listOfMatrices[0][(j == (width - 1)) ? 0 : (j + 1), (k == (length - 1)) ? 0 : (k + 1)];
            //                    break;

            //                case 1:
            //                    this.cwA = listOfMatrices[0][(j == (width - 1)) ? 0 : (j + 1), k];
            //                    this.ccwA = listOfMatrices[0][j, (k == 0) ? (length - 1) : (k - 1)];
            //                    this.oppA = listOfMatrices[0][(j == (width - 1)) ? 0 : (j + 1), (k == 0) ? (length - 1) : (k - 1)];
            //                    break;

            //                case 2:
            //                    this.cwA = listOfMatrices[0][(j == 0) ? (width - 1) : (j - 1), k];
            //                    this.ccwA = listOfMatrices[0][j, (k == (length - 1)) ? 0 : (k + 1)];
            //                    this.oppA = listOfMatrices[0][(j == 0) ? (width - 1) : (j - 1), (k == (length - 1)) ? 0 : (k + 1)];
            //                    break;

            //                case 3:
            //                    this.cwA = listOfMatrices[0][j, (k == 0) ? (length - 1) : (k - 1)];
            //                    this.ccwA = listOfMatrices[0][(j == 0) ? (width - 1) : (j - 1), k];
            //                    this.oppA = listOfMatrices[0][(j == 0) ? (width - 1) : (j - 1), (k == 0) ? (length - 1) : (k - 1)];
            //                    break;
            //            }
            //            switch (listOfMatrices[2][j, k])
            //            {
            //                case 0:
            //                    this.cwB = listOfMatrices[1][j, (k == (length - 1)) ? 0 : (k + 1)];
            //                    this.ccwB = listOfMatrices[1][(j == (width - 1)) ? 0 : (j + 1), k];
            //                    this.oppB = listOfMatrices[1][(j == (width - 1)) ? 0 : (j + 1), (k == (length - 1)) ? 0 : (k + 1)];
            //                    break;

            //                case 1:
            //                    this.cwB = listOfMatrices[1][(j == (width - 1)) ? 0 : (j + 1), k];
            //                    this.ccwB = listOfMatrices[1][j, (k == 0) ? (length - 1) : (k - 1)];
            //                    this.oppB = listOfMatrices[1][(j == (width - 1)) ? 0 : (j + 1), (k == 0) ? (length - 1) : (k - 1)];
            //                    break;

            //                case 2:
            //                    this.cwB = listOfMatrices[1][(j == 0) ? (width - 1) : (j - 1), k];
            //                    this.ccwB = listOfMatrices[1][j, (k == (length - 1)) ? 0 : (k + 1)];
            //                    this.oppB = listOfMatrices[1][(j == 0) ? (width - 1) : (j - 1), (k == (length - 1)) ? 0 : (k + 1)];
            //                    break;

            //                case 3:
            //                    this.cwB = listOfMatrices[1][j, (k == 0) ? (length - 1) : (k - 1)];
            //                    this.ccwB = listOfMatrices[1][(j == 0) ? (width - 1) : (j - 1), k];
            //                    this.oppB = listOfMatrices[1][(j == 0) ? (width - 1) : (j - 1), (k == 0) ? (length - 1) : (k - 1)];
            //                    break;
            //            }
            //            listOfMatrices[4][j, k] = ((((listOfMatrices[1][j, k] ^ this.cwB) ^ this.ccwB) ^ this.oppB) == 0) ? this.ccwA : this.cwA;
            //            listOfMatrices[5][j, k] = (short)(((this.oppB & this.ccwB) ^ this.cwB) ^ listOfMatrices[1][j, k]);
            //            listOfMatrices[6][j, k] = (short)(3 - listOfMatrices[2][j, k]);
            //            if ((i == (iterationsCount - 1)) && (listOfMatrices[4][j, k] == 1))
            //            {
            //                b.SetPixel(k, j, Colors[0]);
            //            }
            //        }
            //    }
            //    short[,] numArray = listOfMatrices[0];
            //    listOfMatrices[0] = listOfMatrices[4];
            //    listOfMatrices[4] = numArray;
            //    numArray = listOfMatrices[1];
            //    listOfMatrices[1] = listOfMatrices[5];
            //    listOfMatrices[5] = numArray;
            //    numArray = listOfMatrices[2];
            //    listOfMatrices[2] = listOfMatrices[6];
            //    listOfMatrices[6] = numArray;
            //}
        }

        public override string ToString()
        {
            return Localization.Locales.Resources.Rules_Naiv_Deffusion_Description;
        }

        #region ITestableModel Members


        public void Show(ref IntPtr Dim0, ref IntPtr Dim1, ref IntPtr Dim2, ref IntPtr Dim3, ref IntPtr Dim4, ref IntPtr Dim5, ref IntPtr Dim6, ref IntPtr Dim7, ref IntPtr Dim8, ref IntPtr Dim9, ref IntPtr Dim10, int height, int width, IntPtr SdlScreenPixelBuffer, IntPtr colors)
        {
            throw new NotImplementedException();
        }

        public string Name
        {
            get { return Localization.Locales.Resources.Rules_Naiv_Deffusion_Name; }
        }

        #endregion
    }
}
