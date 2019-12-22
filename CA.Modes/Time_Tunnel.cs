using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace CA.Modes
{
    /// <summary>
    /// 
    /// </summary>
    public unsafe class Time_Tunnel : ITestableModel
    {
        private static int height_1;
        private static int width_1;
        private static int jmult_width;
        private static int j_intheend_multiplywidth;
        private static int j_inthebegining_multiplywidth;
        private static int interationsCount_1;
        private static int k_intheend;
        private static int k_inthebegining;

        private static short* Dim0_jmult_width;
        private static short* Dim0_j_intheend_multiplywidth;
        private static short* Dim0_j_inthebegining_multiplywidth;
        private static short* Dim1_jmult_width;
        private static short* Dim4_jmult_width;
        private static short* Dim5_jmult_width;

        #region ITestableModel Members

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
            height_1 = height - 1;
            width_1 = width - 1;
            interationsCount_1 = iterationsCount - 1;
            UInt32* SdlPositionInTheScreenBuffer = (UInt32*)SdlScreenPixelBuffer;
            UInt32* colorsT = (UInt32*)colors;
            short* ptDim0 = (short*)Dim0,
                   ptDim1 = (short*)Dim1,
                   ptDim4 = (short*)Dim4,
                   ptDim5 = (short*)Dim5;
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
                    Dim4_jmult_width = ptDim4 + jmult_width;
                    Dim5_jmult_width = ptDim5 + jmult_width;

                    for (int k = 0; k < height; k++)
                    {
                        k_inthebegining = k == 0 ? height_1 : k - 1;
                        k_intheend = k == height_1 ? 0 : k + 1;

                        short num6 = *(Dim0_jmult_width + k);
                        num6 += *(Dim0_j_inthebegining_multiplywidth + k);
                        num6 += *(Dim0_j_intheend_multiplywidth + k);
                        num6 += *(Dim0_jmult_width + k_inthebegining);
                        num6 += *(Dim0_jmult_width + k_intheend);
                        //num6 = ((num6 > 0) && (num6 < 5)) ? 1 : 0;
                        switch(num6)
                        {
                            case 0:
                                {
                                    num6 = 0;
                                    break;
                                }
                            case 5:
                                {
                                    num6 = 0;
                                    break;
                                }
                            default:
                                {
                                    num6 = 1;
                                    break;
                                }
                        }
                        //if (num6 == *(Dim1_jmult_width + k))
                        //{
                        //    *(Dim4_jmult_width + k) = 0;
                        //}
                        //else
                        //{
                        //    *(Dim4_jmult_width + k) = 1;
                        //}
                        num6 ^= *(Dim1_jmult_width + k);
                        *(Dim4_jmult_width + k) = num6;
                        *(Dim5_jmult_width + k) = *(Dim0_jmult_width + k);
                        if (i == interationsCount_1)
                        {
                            if ((*(Dim4_jmult_width + k) == 1) && (*(Dim5_jmult_width + k) == 0))
                            {
                                //b.SetPixel(k, j, Colors[2]);
                                *(SdlPositionInTheScreenBuffer + jmult_width + k) = *(colorsT + 2);
                            }
                            else if ((*(Dim4_jmult_width + k) == 0) && (*(Dim5_jmult_width + k) == 1))
                            {
                                //b.SetPixel(k, j, Colors[4]);
                                *(SdlPositionInTheScreenBuffer + jmult_width + k) = *(colorsT + 4);
                            }
                            else
                            {
                                *(SdlPositionInTheScreenBuffer + jmult_width + k) = *(colorsT + 11);
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
            }
        }

        public void Show(ref IntPtr Dim0, ref IntPtr Dim1, ref IntPtr Dim2, ref IntPtr Dim3, ref IntPtr Dim4, ref IntPtr Dim5, ref IntPtr Dim6, ref IntPtr Dim7, ref IntPtr Dim8, ref IntPtr Dim9, ref IntPtr Dim10, int height, int width, IntPtr SdlScreenPixelBuffer, IntPtr colors)
        {
            UInt32* SdlPositionInTheScreenBuffer = (UInt32*)SdlScreenPixelBuffer;
            UInt32* colorsT = (UInt32*)colors;
            short* ptDim4 = (short*)Dim4,
                   ptDim5 = (short*)Dim5;
            for (int j = 0; j < width; j++)
            {
                jmult_width = j * width;
                Dim4_jmult_width = ptDim4 + jmult_width;
                Dim5_jmult_width = ptDim5 + jmult_width;
                for (int k = 0; k < height; k++)
                {
                    if ((*(Dim4_jmult_width + k) == 1) && (*(Dim5_jmult_width + k) == 0))
                    {
                        *(SdlPositionInTheScreenBuffer + jmult_width + k) = *(colorsT + 2);
                    }
                    else if ((*(Dim4_jmult_width + k) == 0) && (*(Dim5_jmult_width + k) == 1))
                    {
                        *(SdlPositionInTheScreenBuffer + jmult_width + k) = *(colorsT + 4);
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
            get { return Localization.Locales.Resources.Rules_Time_Tunnel_Name; }
        }
        #endregion

        public override string ToString()
        {
            return Localization.Locales.Resources.Rules_Time_Tunnel_Description;
        }
    }
}
