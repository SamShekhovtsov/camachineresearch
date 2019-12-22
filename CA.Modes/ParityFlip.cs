using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace CA.Modes
{
    public class ParityFlip : ITestableModel
    {
        // Methods
        public int GetCapacity()
        {
            return 2;
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
            //            int num6 = listOfMatrices[0][j, k];
            //            num6 = (num6 == listOfMatrices[0][(j == 0) ? (width - 1) : (j - 1), k]) ? 0 : 1;
            //            num6 = (num6 == listOfMatrices[0][(j == (width - 1)) ? 0 : (j + 1), k]) ? 0 : 1;
            //            num6 = (num6 == listOfMatrices[0][j, (k == 0) ? (length - 1) : (k - 1)]) ? 0 : 1;
            //            num6 = (num6 == listOfMatrices[0][j, (k == (length - 1)) ? 0 : (k + 1)]) ? 0 : 1;
            //            if (num6 == listOfMatrices[1][j, k])
            //            {
            //                listOfMatrices[4][j, k] = 0;
            //            }
            //            else
            //            {
            //                listOfMatrices[4][j, k] = 1;
            //            }
            //            listOfMatrices[5][j, k] = listOfMatrices[0][j, k];
            //            if (i == (iterationsCount - 1))
            //            {
            //                if ((listOfMatrices[4][j, k] == 1) && (listOfMatrices[5][j, k] == 0))
            //                {
            //                    b.SetPixel(k, j, Colors[2]);
            //                }
            //                else if ((listOfMatrices[4][j, k] == 0) && (listOfMatrices[5][j, k] == 1))
            //                {
            //                    b.SetPixel(k, j, Colors[4]);
            //                }
            //            }
            //        }
            //    }
            //    short[,] numArray = listOfMatrices[0];
            //    listOfMatrices[0] = listOfMatrices[4];
            //    listOfMatrices[4] = numArray;
            //    numArray = listOfMatrices[1];
            //    listOfMatrices[1] = listOfMatrices[5];
            //    listOfMatrices[5] = numArray;
            //}
        }

        public override string ToString()
        {
            return Localization.Locales.Resources.Rules_ParityFlip_Description;
        }

        #region ITestableModel Members

        public void Show(ref IntPtr Dim0, ref IntPtr Dim1, ref IntPtr Dim2, ref IntPtr Dim3, ref IntPtr Dim4, ref IntPtr Dim5, ref IntPtr Dim6, ref IntPtr Dim7, ref IntPtr Dim8, ref IntPtr Dim9, ref IntPtr Dim10, int height, int width, IntPtr SdlScreenPixelBuffer, IntPtr colors)
        {
            throw new NotImplementedException();
        }

        public string Name
        {
            get { return Localization.Locales.Resources.Rules_ParityFlip_Name; }
        }

        #endregion
    }
}
