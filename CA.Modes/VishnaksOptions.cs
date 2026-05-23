using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace CA.Modes
{
    [Serializable]
    public class VishnaksOptions : ITestableModel
    {
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
            //            int num6 = 0;
            //            if (listOfMatrices[0][j, k] > 0)
            //            {
            //                num6 = 1;
            //            }
            //            num6 += (listOfMatrices[0][(j == 0) ? (width - 1) : (j - 1), k] > 0) ? 1 : 0;
            //            num6 += (listOfMatrices[0][(j == (width - 1)) ? 0 : (j + 1), k] > 0) ? 1 : 0;
            //            num6 += (listOfMatrices[0][j, (k == 0) ? (length - 1) : (k - 1)] > 0) ? 1 : 0;
            //            num6 += (listOfMatrices[0][j, (k == (length - 1)) ? 0 : (k + 1)] > 0) ? 1 : 0;
            //            num6 += (listOfMatrices[0][(j == 0) ? (width - 1) : (j - 1), (k == 0) ? (length - 1) : (k - 1)] > 0) ? 1 : 0;
            //            num6 += (listOfMatrices[0][(j == (width - 1)) ? 0 : (j + 1), (k == (length - 1)) ? 0 : (k + 1)] > 0) ? 1 : 0;
            //            num6 += (listOfMatrices[0][(j == 0) ? (width - 1) : (j - 1), (k == (length - 1)) ? 0 : (k + 1)] > 0) ? 1 : 0;
            //            num6 += (listOfMatrices[0][(j == (width - 1)) ? 0 : (j + 1), (k == 0) ? (length - 1) : (k - 1)] > 0) ? 1 : 0;
            //            if ((num6 > 5) || (num6 == 4))
            //            {
            //                listOfMatrices[4][j, k] = 1;
            //                if (i == (iterationsCount - 1))
            //                {
            //                    b.SetPixel(k, j, Colors[0]);
            //                }
            //            }
            //            else
            //            {
            //                listOfMatrices[4][j, k] = 0;
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
            return Localization.Locales.Resources.Rules_VishnaksOptions_Description;
        }

        #region ITestableModel Members

        public void Show(ref IntPtr Dim0, ref IntPtr Dim1, ref IntPtr Dim2, ref IntPtr Dim3, ref IntPtr Dim4, ref IntPtr Dim5, ref IntPtr Dim6, ref IntPtr Dim7, ref IntPtr Dim8, ref IntPtr Dim9, ref IntPtr Dim10, int height, int width, IntPtr SdlScreenPixelBuffer, IntPtr colors)
        {
            throw new NotImplementedException();
        }

        public string Name
        {
            get { return Localization.Locales.Resources.Rules_VishnaksOptions_Name; }
        }
        #endregion
    }
}
