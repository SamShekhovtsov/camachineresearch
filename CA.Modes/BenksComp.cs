using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace CA.Modes
{
    public class BenksComp : ITestableModel, IDiagramme
    {
        // Fields
        public List<long>[] demografia = new List<long>[2];
        private long param_1;
        private long param_2;

        // Methods
        public BenksComp()
        {
            this.demografia[0] = new List<long>();
            this.demografia[1] = new List<long>();
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
            //int num3 = 0;
            //while (num3 < iterationsCount)
            //{
            //    for (int i = 0; i < width; i++)
            //    {
            //        for (int j = 0; j < length; j++)
            //        {
            //            int num6 = 0;
            //            num6 += (listOfMatrices[0][(i == 0) ? (width - 1) : (i - 1), j] > 0) ? 1 : 0;
            //            num6 += (listOfMatrices[0][(i == (width - 1)) ? 0 : (i + 1), j] > 0) ? 1 : 0;
            //            num6 += (listOfMatrices[0][i, (j == 0) ? (length - 1) : (j - 1)] > 0) ? 1 : 0;
            //            num6 += (listOfMatrices[0][i, (j == (length - 1)) ? 0 : (j + 1)] > 0) ? 1 : 0;
            //            if ((num6 < 2) || ((num6 == 2) && (listOfMatrices[0][(i == (width - 1)) ? 0 : (i + 1), j] == listOfMatrices[0][(i == 0) ? (width - 1) : (i - 1), j])))
            //            {
            //                listOfMatrices[4][i, j] = listOfMatrices[0][i, j];
            //            }
            //            else if ((num6 == 2) && (listOfMatrices[0][(i == (width - 1)) ? 0 : (i + 1), j] != listOfMatrices[0][(i == 0) ? (width - 1) : (i - 1), j]))
            //            {
            //                listOfMatrices[4][i, j] = 0;
            //                this.param_2 += 1L;
            //            }
            //            else if (num6 > 2)
            //            {
            //                listOfMatrices[4][i, j] = 1;
            //            }
            //            if ((num3 == (iterationsCount - 1)) && (listOfMatrices[4][i, j] == 1))
            //            {
            //                b.SetPixel(j, i, Colors[0]);
            //                this.param_1 += 1L;
            //            }
            //        }
            //    }
            //    this.demografia[0].Add(this.param_1);
            //    this.demografia[1].Add(this.param_2);
            //    short[,] numArray = listOfMatrices[0];
            //    listOfMatrices[0] = listOfMatrices[4];
            //    listOfMatrices[4] = numArray;
            //    num3++;
            //    this.param_1 = 0L;
            //    this.param_2 = 0L;
            //}
        }

        public override string ToString()
        {
            return Localization.Locales.Resources.Rules_BenksComp_Description;
        }

        // Properties
        public List<long>[] Demografia
        {
            get
            {
                return this.demografia;
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
            get { return Localization.Locales.Resources.Rules_BenksComp_Name; }
        }

        #endregion
    }
}
