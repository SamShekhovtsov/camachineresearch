using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace CA.Modes
{
    public unsafe class Rac : ITestableModel
    {
        private static int height_1;
        private static int width_1;
        private static int jmult_width;
        private static int j_intheend_multiplywidth;
        private static int j_inthebegining_multiplywidth;
        private static int k_intheend;
        private static int k_inthebegining;

        private static short* Dim0_jmult_width;
        private static short* Dim0_j_intheend_multiplywidth;
        private static short* Dim0_j_inthebegining_multiplywidth;
        private static short* Dim1_jmult_width;
        private static short* Dim2_jmult_width;
        private static short* Dim2_j_intheend_multiplywidth;
        private static short* Dim2_j_inthebegining_multiplywidth;
        private static short* Dim3_jmult_width;
        private static short* Dim4_jmult_width;
        private static short* Dim5_jmult_width;
        private static short* Dim6_jmult_width;
        private static short* Dim7_jmult_width;
        private bool _firstTime = true;

        // Methods
        public int GetCapacity()
        {
            return 3;
        }

        public void TestOld(ref IntPtr Dim0, ref IntPtr Dim1, ref IntPtr Dim2, ref IntPtr Dim3, ref IntPtr Dim4, ref IntPtr Dim5,
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
            //            num6 += listOfMatrices[0][(j == 0) ? (width - 1) : (j - 1), k];
            //            num6 += listOfMatrices[0][(j == (width - 1)) ? 0 : (j + 1), k];
            //            num6 += listOfMatrices[0][j, (k == 0) ? (length - 1) : (k - 1)];
            //            num6 += listOfMatrices[0][j, (k == (length - 1)) ? 0 : (k + 1)];
            //            num6 = ((num6 > 0) && (num6 < 5)) ? 1 : 0;
            //            if (num6 == listOfMatrices[1][j, k])
            //            {
            //                listOfMatrices[4][j, k] = 0;
            //            }
            //            else
            //            {
            //                listOfMatrices[4][j, k] = 1;
            //            }
            //            listOfMatrices[5][j, k] = listOfMatrices[0][j, k];
            //            num6 = listOfMatrices[2][j, k];
            //            num6 += listOfMatrices[2][(j == 0) ? (width - 1) : (j - 1), k];
            //            num6 += listOfMatrices[2][(j == (width - 1)) ? 0 : (j + 1), k];
            //            num6 += listOfMatrices[2][j, (k == 0) ? (length - 1) : (k - 1)];
            //            num6 += listOfMatrices[2][j, (k == (length - 1)) ? 0 : (k + 1)];
            //            num6 = ((num6 > 0) && (num6 < 5)) ? 1 : 0;
            //            if (num6 == listOfMatrices[3][j, k])
            //            {
            //                listOfMatrices[6][j, k] = 0;
            //            }
            //            else
            //            {
            //                listOfMatrices[6][j, k] = 1;
            //            }
            //            listOfMatrices[7][j, k] = listOfMatrices[2][j, k];
            //            if (i == (iterationsCount - 1))
            //            {
            //                int num7 = 0;
            //                int num8 = 0;
            //                num7 = (listOfMatrices[0][j, k] == listOfMatrices[2][j, k]) ? 0 : 1;
            //                num8 = (listOfMatrices[1][j, k] == listOfMatrices[3][j, k]) ? 0 : 1;
            //                if ((num7 == 1) && (num8 == 1))
            //                {
            //                    b.SetPixel(k, j, Colors[3]);
            //                }
            //                if ((num7 == 1) && (num8 == 0))
            //                {
            //                    b.SetPixel(k, j, Colors[4]);
            //                }
            //                if ((num7 == 0) && (num8 == 1))
            //                {
            //                    b.SetPixel(k, j, Colors[5]);
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
            //    numArray = listOfMatrices[2];
            //    listOfMatrices[2] = listOfMatrices[6];
            //    listOfMatrices[6] = numArray;
            //    numArray = listOfMatrices[3];
            //    listOfMatrices[3] = listOfMatrices[7];
            //    listOfMatrices[7] = numArray;
            //}
        }

        public void Test(ref IntPtr Dim0, ref IntPtr Dim1, ref IntPtr Dim2, ref IntPtr Dim3, ref IntPtr Dim4, ref IntPtr Dim5,
                  ref IntPtr Dim6, ref IntPtr Dim7, ref IntPtr Dim8,
                  ref IntPtr Dim9, ref IntPtr Dim10, int iterationsCount, int height, int width,
                  IntPtr SdlScreenPixelBuffer, IntPtr colors)
        {
            height_1 = height - 1;
            width_1 = width - 1;
            UInt32* SdlPositionInTheScreenBuffer = (UInt32*)SdlScreenPixelBuffer;
            UInt32* colorsT = (UInt32*)colors;
            short* ptDim0 = (short*)Dim0,
                   ptDim1 = (short*)Dim1,
                   ptDim2 = (short*)Dim2,
                   ptDim3 = (short*)Dim3,
                   ptDim4 = (short*)Dim4,
                   ptDim5 = (short*)Dim5,
                   ptDim6 = (short*)Dim6,
                   ptDim7 = (short*)Dim7;

            if (_firstTime)
            {

                for (int j = 0; j < width; j++)
                {
                    int f1 = 0, f2 = 1, f3 = 0;

                    jmult_width = j * width;
                    j_intheend_multiplywidth = (j == width_1 ? 0 : j + 1) * width;
                    j_inthebegining_multiplywidth = (j == 0 ? width_1 : j - 1) * width;
                    Dim0_jmult_width = ptDim0 + jmult_width;
                    Dim0_j_intheend_multiplywidth = ptDim0 + j_intheend_multiplywidth;
                    Dim0_j_inthebegining_multiplywidth = ptDim0 + j_inthebegining_multiplywidth;

                    Dim2_jmult_width = ptDim2 + jmult_width;
                    Dim2_j_intheend_multiplywidth = ptDim2 + j_intheend_multiplywidth;
                    Dim2_j_inthebegining_multiplywidth = ptDim2 + j_inthebegining_multiplywidth;
                    for (int k = 0; k < height; k++)
                    {
                        k_inthebegining = k == 0 ? height_1 : k - 1;
                        k_intheend = k == height_1 ? 0 : k + 1;

                        if ((j + k) % 5 == 0)
                        {
                            *(Dim0_jmult_width + k) = 1;
                            *(Dim2_jmult_width + k) = 1;
                        }
                        else if ((j + k) % 9 == 0)
                        {
                            *(Dim0_jmult_width + k) = 1;
                            *(Dim2_jmult_width + k) = 1;
                        }

                        f3 = f1 + f2;
                        if (f3 < height)
                        {
                            *(Dim0_jmult_width + f3) = 1;
                            *(Dim2_jmult_width + f3) = 1;

                            f1 = f2;
                            f2 = f3;
                        }
                    }
                }
            }

            for (int i = 0; i < iterationsCount; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    jmult_width = j * width;
                    j_intheend_multiplywidth = (j == width_1 ? 0 : j + 1) * width;
                    j_inthebegining_multiplywidth = (j == 0 ? width_1 : j - 1) * width;
                    Dim0_jmult_width = ptDim0 + jmult_width;
                    Dim0_j_intheend_multiplywidth = ptDim0 + j_intheend_multiplywidth;
                    Dim0_j_inthebegining_multiplywidth = ptDim0 + j_inthebegining_multiplywidth;
                    
                    Dim1_jmult_width = ptDim1 + jmult_width;
                    Dim2_jmult_width = ptDim2 + jmult_width;
                    Dim2_j_intheend_multiplywidth = ptDim2 + j_intheend_multiplywidth;
                    Dim2_j_inthebegining_multiplywidth = ptDim2 + j_inthebegining_multiplywidth;
                    Dim3_jmult_width = ptDim3 + jmult_width;
                    Dim4_jmult_width = ptDim4 + jmult_width;
                    Dim5_jmult_width = ptDim5 + jmult_width;
                    Dim6_jmult_width = ptDim6 + jmult_width;
                    Dim7_jmult_width = ptDim7 + jmult_width;

                    for (int k = 0; k < height; k++)
                    {
                        k_inthebegining = k == 0 ? height_1 : k - 1;
                        k_intheend = k == height_1 ? 0 : k + 1;

                        int num6 = *(Dim0_jmult_width + k);
                        num6 += *(Dim0_j_inthebegining_multiplywidth + k);
                        num6 += *(Dim0_j_intheend_multiplywidth + k);
                        num6 += *(Dim0_jmult_width + k_inthebegining);
                        num6 += *(Dim0_jmult_width + k_intheend);
                        num6 = ((num6 > 0) && (num6 < 5)) ? 1 : 0;

                        if (num6 == *(Dim1_jmult_width + k))
                        {
                            *(Dim4_jmult_width + k) = 0;
                        }
                        else
                        {
                            *(Dim4_jmult_width + k) = 1;
                        }
                        *(Dim5_jmult_width + k) = *(Dim0_jmult_width + k);
                        num6 = *(Dim2_jmult_width + k);
                        num6 += *(Dim2_j_inthebegining_multiplywidth + k);
                        num6 += *(Dim2_j_intheend_multiplywidth + k);
                        num6 += *(Dim2_jmult_width + k_inthebegining);
                        num6 += *(Dim2_jmult_width + k_intheend);
                        num6 = ((num6 > 0) && (num6 < 5)) ? 1 : 0;
                        if (num6 == *(Dim3_jmult_width + k))
                        {
                            *(Dim6_jmult_width + k) = 0;
                        }
                        else
                        {
                            *(Dim6_jmult_width + k) = 1;
                        }
                        *(Dim7_jmult_width + k) = *(Dim2_jmult_width + k);
                        if (i == (iterationsCount - 1))
                        {
                            int num7 = 0;
                            int num8 = 0;
                            num7 = (*(Dim0_jmult_width + k) == *(Dim2_jmult_width + k)) ? 0 : 1;
                            num8 = (*(Dim1_jmult_width + k) == *(Dim3_jmult_width + k)) ? 0 : 1;
                            if ((num7 == 1) && (num8 == 1))
                            {
                                *(SdlPositionInTheScreenBuffer + jmult_width + k) = *(colorsT + 3);
                            } else if ((num7 == 1) && (num8 == 0))
                            {
                                *(SdlPositionInTheScreenBuffer + jmult_width + k) = *(colorsT + 4);
                            } else if ((num7 == 0) && (num8 == 1))
                            {
                                *(SdlPositionInTheScreenBuffer + jmult_width + k) = *(colorsT + 5);
                            }
                            else
                            {
                                *(SdlPositionInTheScreenBuffer + jmult_width + k) = *(colorsT+11);
                            }
                        }
                    }
                }
            }

            IntPtr numArray = Dim0;
            Dim0 = Dim4;
            Dim4 = numArray;

            numArray = Dim1;
            Dim1 = Dim5;
            Dim5 = numArray;

            numArray = Dim2;
            Dim2 = Dim6;
            Dim6 = numArray;

            numArray = Dim3;
            Dim3 = Dim7;
            Dim7 = numArray;

            _firstTime = false;
        }

        public override string ToString()
        {
            return Localization.Locales.Resources.Rules_Rac_Description;
        }

        #region ITestableModel Members

        public void Show(ref IntPtr Dim0, ref IntPtr Dim1, ref IntPtr Dim2, ref IntPtr Dim3, ref IntPtr Dim4, ref IntPtr Dim5, ref IntPtr Dim6, ref IntPtr Dim7, ref IntPtr Dim8, ref IntPtr Dim9, ref IntPtr Dim10, int height, int width, IntPtr SdlScreenPixelBuffer, IntPtr colors)
        {
            UInt32* SdlPositionInTheScreenBuffer = (UInt32*)SdlScreenPixelBuffer;
            UInt32* colorsT = (UInt32*)colors;
            short* ptDim3 = (short*)Dim3,
                   ptDim4 = (short*)Dim4;
            for (int j = 0; j < width; j++)
            {
                jmult_width = j * width;
                Dim3_jmult_width = ptDim3 + jmult_width;
                for (int k = 0; k < height; k++)
                {
                    if (*(ptDim4 + jmult_width + k) == 1)
                    {
                        *(SdlPositionInTheScreenBuffer + jmult_width + k) = *colorsT;
                    }
                    else if (*(Dim3_jmult_width + k) == 1)
                    {
                        *(SdlPositionInTheScreenBuffer + jmult_width + k) = *(colorsT + 3);
                    }
                    else
                    {
                        *(SdlPositionInTheScreenBuffer + jmult_width + k) = *(colorsT + 11);
                    }
                }
            }
        }

        public string Name
        {
            get { return Localization.Locales.Resources.Rules_Rac_Name; }
        }
        #endregion
    }
}
