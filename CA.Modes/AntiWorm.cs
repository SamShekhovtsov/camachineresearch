using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace CA.Modes
{
    [Serializable]
    public class AntiWorm : ITestableModel, IDiagramme
    {
        // Fields
        public List<long>[] demografia;

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
            //            int num6 = 0;
            //            num6 += (listOfMatrices[0][(j == 0) ? (width - 1) : (j - 1), k] > 0) ? 1 : 0;
            //            num6 += (listOfMatrices[0][(j == (width - 1)) ? 0 : (j + 1), k] > 0) ? 1 : 0;
            //            num6 += (listOfMatrices[0][j, (k == 0) ? (length - 1) : (k - 1)] > 0) ? 1 : 0;
            //            num6 += (listOfMatrices[0][j, (k == (length - 1)) ? 0 : (k + 1)] > 0) ? 1 : 0;
            //            num6 += (listOfMatrices[0][(j == 0) ? (width - 1) : (j - 1), (k == 0) ? (length - 1) : (k - 1)] > 0) ? 1 : 0;
            //            num6 += (listOfMatrices[0][(j == (width - 1)) ? 0 : (j + 1), (k == (length - 1)) ? 0 : (k + 1)] > 0) ? 1 : 0;
            //            num6 += (listOfMatrices[0][(j == 0) ? (width - 1) : (j - 1), (k == (length - 1)) ? 0 : (k + 1)] > 0) ? 1 : 0;
            //            num6 += (listOfMatrices[0][(j == (width - 1)) ? 0 : (j + 1), (k == 0) ? (length - 1) : (k - 1)] > 0) ? 1 : 0;
            //            if ((listOfMatrices[2][j, k] == 0) && (listOfMatrices[3][j, k] == 0))
            //            {
            //                listOfMatrices[4][j, k] = 1;
            //            }
            //            else
            //            {
            //                listOfMatrices[4][j, k] = 0;
            //            }
            //            if (num6 > 2)
            //            {
            //                listOfMatrices[5][j, k] = 1;
            //            }
            //            if ((listOfMatrices[0][j, k] == 1) && (listOfMatrices[1][j, k] == 1))
            //            {
            //                listOfMatrices[6][j, k] = 1;
            //                listOfMatrices[7][j, k] = 1;
            //            }
            //            else if (((listOfMatrices[2][j, k] == 0) && (listOfMatrices[3][j, k] == 0)) || ((listOfMatrices[2][j, k] == 0) && (listOfMatrices[3][j, k] == 1)))
            //            {
            //                listOfMatrices[6][j, k] = 0;
            //                listOfMatrices[7][j, k] = 0;
            //            }
            //            else if ((listOfMatrices[2][j, k] == 1) && (listOfMatrices[3][j, k] == 0))
            //            {
            //                listOfMatrices[6][j, k] = 0;
            //                listOfMatrices[7][j, k] = 1;
            //            }
            //            else if ((listOfMatrices[2][j, k] == 1) && (listOfMatrices[3][j, k] == 1))
            //            {
            //                listOfMatrices[6][j, k] = 1;
            //                listOfMatrices[7][j, k] = 0;
            //            }
            //            if ((i == (iterationsCount - 1)) && (listOfMatrices[4][j, k] == 1))
            //            {
            //                b.SetPixel(k, j, Colors[2]);
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
            //    numArray = listOfMatrices[3];
            //    listOfMatrices[3] = listOfMatrices[7];
            //    listOfMatrices[7] = numArray;
            //}
        }

        public override string ToString()
        {
            return Localization.Locales.Resources.Rules_AntiWorm_Description;
        }

        // Properties
        public List<long>[] Demografia
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                this.demografia = value;
            }
        }

        #region ITestableModel Members


        public void Show(ref IntPtr Dim0, ref IntPtr Dim1, ref IntPtr Dim2, ref IntPtr Dim3, ref IntPtr Dim4, ref IntPtr Dim5, ref IntPtr Dim6, ref IntPtr Dim7, ref IntPtr Dim8, ref IntPtr Dim9, ref IntPtr Dim10, int height, int width, IntPtr SdlScreenPixelBuffer, IntPtr colors)
        {
            throw new NotImplementedException();
        }

        public string Name
        {
            get { return Localization.Locales.Resources.Rules_AntiWorm_Name; }
        }

        #endregion
    }
}
