using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using CA.Modes;
using System.Text;

namespace CA.Modes
{
    public unsafe class GM_GAS : ITestableModel
    {
        // Fields
        private static int height_1;
        private static int width_1;
        private static int interationsCount_min_1;
        private static int jmult_width;
        private static int j_intheend_multiplywidth;
        private static int j_inthebegining_multiplywidth;
        private static int k_intheend;
        private static int k_inthebegining;
        private short ccw1;
        private short ccwA;
        private short ccwB;
        private bool collision = false;
        private short cw1;
        private short cwA;
        private short cwB;
        private short opp1;
        private short oppA;
        private short oppB;
        private bool woll = false;
        private bool _firstTime = true;

        private static short* Dim0_jmult_width;
        private static short* Dim0_j_intheend_multiplywidth;
        private static short* Dim0_j_inthebegining_multiplywidth;
        private static short* Dim1_jmult_width;
        private static short* Dim1_j_intheend_multiplywidth;
        private static short* Dim1_j_inthebegining_multiplywidth;
        private static short* Dim3_jmult_width;
        private static short* Dim3_j_intheend_multiplywidth;
        private static short* Dim3_j_inthebegining_multiplywidth;
        // Methods

        #region ITestableModel Members

        public int GetCapacity()
        {
            return 1;
        }
        
        public void Test(ref IntPtr Dim0, ref IntPtr Dim1, ref IntPtr Dim2, ref IntPtr Dim3, ref IntPtr Dim4, ref IntPtr Dim5,
                  ref IntPtr Dim6, ref IntPtr Dim7, ref IntPtr Dim8,
                  ref IntPtr Dim9, ref IntPtr Dim10, int iterationsCount, int height, int width,
                  IntPtr SdlScreenPixelBuffer, IntPtr colors)
        {
            height_1 = height - 1;
            width_1 = width - 1;
            interationsCount_min_1 = iterationsCount - 1;
            UInt32* SdlPositionInTheScreenBuffer = (UInt32*)SdlScreenPixelBuffer;
            UInt32* colorsT = (UInt32*)colors;
            short* ptDim0 = (short*)Dim0,
                   ptDim1 = (short*)Dim1,
                   ptDim2 = (short*)Dim2,
                   ptDim3 = (short*)Dim3,
                   ptDim4 = (short*)Dim4,
                   ptDim5 = (short*)Dim5,
                   ptDim6 = (short*)Dim6;

            if (_firstTime)
            {
                for (int j = 0; j < width; j++)
                {
                        jmult_width = j * width;
                        j_intheend_multiplywidth = (j == width_1 ? 0 : j + 1) * width;
                        j_inthebegining_multiplywidth = (j == 0 ? width_1 : j - 1) * width;
                        Dim3_jmult_width = ptDim3 + jmult_width;
                        Dim3_j_intheend_multiplywidth = ptDim3 + j_intheend_multiplywidth;
                        Dim3_j_inthebegining_multiplywidth = ptDim3 + j_inthebegining_multiplywidth;
                    for (int k = 0; k < height; k++)
                    {
                        k_inthebegining = k == 0 ? height_1 : k - 1;
                        k_intheend = k == height_1 ? 0 : k + 1;

                        if (j == 600 && (k >= 300 && k <= 400))
                        {
                            *(Dim3_jmult_width + k) = 1;
                        }
                        else if ((k == 300 || k == 400) && (j > 400 && j <= 600))
                        {
                            *(Dim3_jmult_width + k) = 1;
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
                    Dim1_j_intheend_multiplywidth = ptDim1 + j_intheend_multiplywidth;
                    Dim1_j_inthebegining_multiplywidth = ptDim1 + j_inthebegining_multiplywidth;
                    Dim3_jmult_width = ptDim3 + jmult_width;
                    Dim3_j_intheend_multiplywidth = ptDim3 + j_intheend_multiplywidth;
                    Dim3_j_inthebegining_multiplywidth = ptDim3 + j_inthebegining_multiplywidth;
                    for (int k = 0; k < height; k++)
                    {
                        k_inthebegining = k == 0 ? height_1 : k - 1;
                        k_intheend = k == height_1 ? 0 : k + 1;
                        switch (*(ptDim2 + jmult_width + k))
                        {
                            case 0:
                                cwA = *(Dim0_jmult_width + k_intheend);
                                ccwA = *(Dim0_j_intheend_multiplywidth + k);
                                oppA = *(Dim0_j_intheend_multiplywidth + k_intheend);
                                cwB = *(Dim3_jmult_width + k_intheend);
                                ccwB = *(Dim3_j_intheend_multiplywidth + k);
                                oppB = *(Dim3_j_intheend_multiplywidth + k_intheend);
                                cw1 = *(Dim1_jmult_width + k_intheend);
                                ccw1 = *(Dim1_j_intheend_multiplywidth + k);
                                opp1 = *(Dim1_j_intheend_multiplywidth + k_intheend);
                                break;

                            case 1:
                                cwA = *(Dim0_j_intheend_multiplywidth + k);
                                ccwA = *(Dim0_jmult_width + k_inthebegining);
                                oppA = *(Dim0_j_intheend_multiplywidth + k_inthebegining);
                                cwB = *(Dim3_j_intheend_multiplywidth + k);
                                ccwB = *(Dim3_jmult_width + k_inthebegining);
                                oppB = *(Dim3_j_intheend_multiplywidth + k_inthebegining);
                                cw1 = *(Dim1_j_intheend_multiplywidth + k);
                                ccw1 = *(Dim1_jmult_width + k_inthebegining);
                                opp1 = *(Dim1_j_intheend_multiplywidth + k_inthebegining);
                                break;

                            case 2:
                                cwA = *(Dim0_j_inthebegining_multiplywidth + k);
                                ccwA = *(Dim0_jmult_width + k_intheend);
                                oppA = *(Dim0_j_inthebegining_multiplywidth + k_intheend);
                                cwB = *(Dim3_j_inthebegining_multiplywidth + k);
                                ccwB = *(Dim3_jmult_width + k_intheend);
                                oppB = *(Dim3_j_inthebegining_multiplywidth + k_intheend);
                                cw1 = *(Dim1_j_inthebegining_multiplywidth + k);
                                ccw1 = *(Dim1_jmult_width + k_intheend);
                                opp1 = *(Dim1_j_inthebegining_multiplywidth + k_intheend);
                                break;

                            case 3:
                                cwA = *(Dim0_jmult_width + k_inthebegining);
                                ccwA = *(Dim0_j_inthebegining_multiplywidth + k);
                                oppA = *(Dim0_j_inthebegining_multiplywidth + k_inthebegining);
                                cwB = *(Dim3_jmult_width + k_inthebegining);
                                ccwB = *(Dim3_j_inthebegining_multiplywidth + k);
                                oppB = *(Dim3_j_inthebegining_multiplywidth + k_inthebegining);
                                cw1 = *(Dim1_jmult_width + k_inthebegining);
                                ccw1 = *(Dim1_j_inthebegining_multiplywidth + k);
                                opp1 = *(Dim1_j_inthebegining_multiplywidth + k_inthebegining);
                                break;
                        }
                        woll = (((oppB + ccwB) + cwB) + *(Dim3_jmult_width + k)) > 0;
                        collision = ((*(Dim0_jmult_width + k) == oppA) && (cwA == ccwA)) && (*(Dim0_jmult_width + k) != cwA);
                        *(ptDim5 + jmult_width + k) = (short)(((opp1 & ccw1) ^ cw1) ^ *(Dim1_jmult_width + k));
                        *(ptDim6 + jmult_width + k) = (short)(3 - *(ptDim2 + jmult_width + k));
                        if (woll || collision)
                        {
                            *(ptDim4 + jmult_width + k) = *(Dim0_jmult_width + k);
                        }
                        else
                        {
                            *(ptDim4 + jmult_width + k) = ((((*(Dim1_jmult_width + k) ^ cw1) ^ ccw1) ^ opp1) == 0) ? ccwA : cwA;
                        }
                        if (i == interationsCount_min_1)
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
                        woll = false;
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
            }
            _firstTime = false;
        }
        
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
            get { return Localization.Locales.Resources.Rules_GM_GAS_Name; }
        }
        #endregion

        public override string ToString()
        {
            return Localization.Locales.Resources.Rules_GM_GAS_Description;
        }
    }

}
