using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using CA.Modes;
using System.Text;

namespace CA.Modes
{
    [Serializable]
    public class Dendrit : ITestableModel, IDiagramme
    {
        // Fields
        private short ccw1;
        private short ccwA;
        private short ccwB;
        private short cw1;
        private short cwA;
        private short cwB;
        public List<long>[] demografia = new List<long>[2];
        private bool dendrit = false;
        private short opp1;
        private short oppA;
        private short oppB;
        private long Param_1 = 0L;
        private long Param_2 = 0L;

        // Methods
        public Dendrit()
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
            //            switch (listOfMatrices[2][i, j])
            //            {
            //                case 0:
            //                    this.cwA = listOfMatrices[0][i, (j == (length - 1)) ? 0 : (j + 1)];
            //                    this.ccwA = listOfMatrices[0][(i == (width - 1)) ? 0 : (i + 1), j];
            //                    this.oppA = listOfMatrices[0][(i == (width - 1)) ? 0 : (i + 1), (j == (length - 1)) ? 0 : (j + 1)];
            //                    this.cwB = listOfMatrices[3][i, (j == (length - 1)) ? 0 : (j + 1)];
            //                    this.ccwB = listOfMatrices[3][(i == (width - 1)) ? 0 : (i + 1), j];
            //                    this.oppB = listOfMatrices[3][(i == (width - 1)) ? 0 : (i + 1), (j == (length - 1)) ? 0 : (j + 1)];
            //                    this.cw1 = listOfMatrices[1][i, (j == (length - 1)) ? 0 : (j + 1)];
            //                    this.ccw1 = listOfMatrices[1][(i == (width - 1)) ? 0 : (i + 1), j];
            //                    this.opp1 = listOfMatrices[1][(i == (width - 1)) ? 0 : (i + 1), (j == (length - 1)) ? 0 : (j + 1)];
            //                    break;

            //                case 1:
            //                    this.cwA = listOfMatrices[0][(i == (width - 1)) ? 0 : (i + 1), j];
            //                    this.ccwA = listOfMatrices[0][i, (j == 0) ? (length - 1) : (j - 1)];
            //                    this.oppA = listOfMatrices[0][(i == (width - 1)) ? 0 : (i + 1), (j == 0) ? (length - 1) : (j - 1)];
            //                    this.cwB = listOfMatrices[3][(i == (width - 1)) ? 0 : (i + 1), j];
            //                    this.ccwB = listOfMatrices[3][i, (j == 0) ? (length - 1) : (j - 1)];
            //                    this.oppB = listOfMatrices[3][(i == (width - 1)) ? 0 : (i + 1), (j == 0) ? (length - 1) : (j - 1)];
            //                    this.cw1 = listOfMatrices[1][(i == (width - 1)) ? 0 : (i + 1), j];
            //                    this.ccw1 = listOfMatrices[1][i, (j == 0) ? (length - 1) : (j - 1)];
            //                    this.opp1 = listOfMatrices[1][(i == (width - 1)) ? 0 : (i + 1), (j == 0) ? (length - 1) : (j - 1)];
            //                    break;

            //                case 2:
            //                    this.cwA = listOfMatrices[0][(i == 0) ? (width - 1) : (i - 1), j];
            //                    this.ccwA = listOfMatrices[0][i, (j == (length - 1)) ? 0 : (j + 1)];
            //                    this.oppA = listOfMatrices[0][(i == 0) ? (width - 1) : (i - 1), (j == (length - 1)) ? 0 : (j + 1)];
            //                    this.cwB = listOfMatrices[3][(i == 0) ? (width - 1) : (i - 1), j];
            //                    this.ccwB = listOfMatrices[3][i, (j == (length - 1)) ? 0 : (j + 1)];
            //                    this.oppB = listOfMatrices[3][(i == 0) ? (width - 1) : (i - 1), (j == (length - 1)) ? 0 : (j + 1)];
            //                    this.cw1 = listOfMatrices[1][(i == 0) ? (width - 1) : (i - 1), j];
            //                    this.ccw1 = listOfMatrices[1][i, (j == (length - 1)) ? 0 : (j + 1)];
            //                    this.opp1 = listOfMatrices[1][(i == 0) ? (width - 1) : (i - 1), (j == (length - 1)) ? 0 : (j + 1)];
            //                    break;

            //                case 3:
            //                    this.cwA = listOfMatrices[0][i, (j == 0) ? (length - 1) : (j - 1)];
            //                    this.ccwA = listOfMatrices[0][(i == 0) ? (width - 1) : (i - 1), j];
            //                    this.oppA = listOfMatrices[0][(i == 0) ? (width - 1) : (i - 1), (j == 0) ? (length - 1) : (j - 1)];
            //                    this.cwB = listOfMatrices[3][i, (j == 0) ? (length - 1) : (j - 1)];
            //                    this.ccwB = listOfMatrices[3][(i == 0) ? (width - 1) : (i - 1), j];
            //                    this.oppB = listOfMatrices[3][(i == 0) ? (width - 1) : (i - 1), (j == 0) ? (length - 1) : (j - 1)];
            //                    this.cw1 = listOfMatrices[1][i, (j == 0) ? (length - 1) : (j - 1)];
            //                    this.ccw1 = listOfMatrices[1][(i == 0) ? (width - 1) : (i - 1), j];
            //                    this.opp1 = listOfMatrices[1][(i == 0) ? (width - 1) : (i - 1), (j == 0) ? (length - 1) : (j - 1)];
            //                    break;
            //            }
            //            this.dendrit = (((this.oppB + this.ccwB) + this.cwB) + listOfMatrices[3][i, j]) > 0;
            //            listOfMatrices[5][i, j] = (short)(((this.opp1 & this.ccw1) ^ this.cw1) ^ listOfMatrices[1][i, j]);
            //            listOfMatrices[6][i, j] = (short)(3 - listOfMatrices[2][i, j]);
            //            if (this.dendrit)
            //            {
            //                listOfMatrices[7][i, j] = (listOfMatrices[0][i, j] > listOfMatrices[3][i, j]) ? listOfMatrices[0][i, j] : listOfMatrices[3][i, j];
            //                listOfMatrices[4][i, j] = 0;
            //            }
            //            else
            //            {
            //                listOfMatrices[7][i, j] = listOfMatrices[3][i, j];
            //                listOfMatrices[4][i, j] = ((((listOfMatrices[1][i, j] ^ this.cw1) ^ this.ccw1) ^ this.opp1) == 0) ? this.ccwA : this.cwA;
            //            }
            //            if (listOfMatrices[4][i, j] == 1)
            //            {
            //                this.Param_1 += 1L;
            //                if (num3 == (iterationsCount - 1))
            //                {
            //                    b.SetPixel(j, i, Colors[0]);
            //                }
            //            }
            //            if (listOfMatrices[7][i, j] == 1)
            //            {
            //                this.Param_2 += 1L;
            //                if (num3 == (iterationsCount - 1))
            //                {
            //                    b.SetPixel(j, i, Colors[3]);
            //                }
            //            }
            //        }
            //    }
            //    this.demografia[0].Add(this.Param_1);
            //    this.demografia[1].Add(this.Param_2);
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
            //    num3++;
            //    this.Param_1 = 0L;
            //    this.Param_2 = 0L;
            //}
        }

        public override string ToString()
        {
            return Localization.Locales.Resources.Rules_Dendrit_Description;
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
            get { return Localization.Locales.Resources.Rules_Dendrit_Name; }
        }

        #endregion
    }
}
