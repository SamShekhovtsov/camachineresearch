using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace CA.Modes
{
    [Serializable]
    public class Gistogramma : ITestableModel
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
            //b.MakeTransparent(Color.Tan);
            //for (int i = 0; i < (length - 1); i++)
            //{
            //    listOfMatrices[2][width - 10, i] = 1;
            //}
            //for (int j = 0; j < width; j++)
            //{
            //    for (int k = 0; k < width; k++)
            //    {
            //        for (int m = 0; m < length; m++)
            //        {
            //            if (listOfMatrices[2][k, m] > 0)
            //            {
            //                while (listOfMatrices[0][(k == 0) ? (width - 1) : (k - 1), m] > 0)
            //                {
            //                    listOfMatrices[2][k - 1, m] = 1;
            //                    if (j == (width - 1))
            //                    {
            //                        b.SetPixel(m, k, Colors[3]);
            //                    }
            //                    listOfMatrices[0][(k == 0) ? (width - 1) : (k - 1), m] = 0;
            //                }
            //            }
            //            listOfMatrices[1][k, m] = listOfMatrices[0][(k == 0) ? (width - 1) : (k - 1), m];
            //            if ((listOfMatrices[1][k, m] > 0) && (j == (width - 1)))
            //            {
            //                b.SetPixel(m, k, Colors[1]);
            //            }
            //            if ((listOfMatrices[2][k, m] > 0) && (j == (width - 1)))
            //            {
            //                b.SetPixel(m, k, Colors[3]);
            //            }
            //        }
            //    }
            //    short[,] numArray = listOfMatrices[0];
            //    listOfMatrices[0] = listOfMatrices[1];
            //    listOfMatrices[1] = numArray;
            //}
        }

        #region ITestableModel Members


        public void Show(ref IntPtr Dim0, ref IntPtr Dim1, ref IntPtr Dim2, ref IntPtr Dim3, ref IntPtr Dim4, ref IntPtr Dim5, ref IntPtr Dim6, ref IntPtr Dim7, ref IntPtr Dim8, ref IntPtr Dim9, ref IntPtr Dim10, int height, int width, IntPtr SdlScreenPixelBuffer, IntPtr colors)
        {
            throw new NotImplementedException();
        }

        public string Name
        {
            get { return "Gistogramma"; }
        }

        #endregion
    }
}
