//-----------------------------------------------------------------------------
// <copyright file="HarmonicOscillator.cs" company="SemQQQ">
//     Copyright (c) SemQQQ. All rights reserved. CPOL Licence
// </copyright>
// <author name="Sem Shekhovtsov" email="semshehovtsov@gmail.com"/>
//-----------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CA.Modes
{
    public unsafe class HarmonicOscillator : ITestableModel
    {
        private static int height_1;
        private static int width_1;
        private static int jmult_width;
        private static int j_intheend_multiplywidth;
        private static int j_inthebegining_multiplywidth;

        private static short* Dim0_jmult_width;
        private static short* Dim1_jmult_width;
        private static short* Dim3_jmult_width;
        private static short* Dim4_jmult_width;
        private static short* Dim5_jmult_width;
        private static short* Dim6_jmult_width;
        private static short* Dim0_j_intheend_multiplywidth;
        private static short* Dim0_j_inthebegining_multiplywidth;
        private static short* Dim1_j_intheend_multiplywidth;
        private static short* Dim1_j_inthebegining_multiplywidth;
        private static short* Dim3_j_intheend_multiplywidth;
        private static short* Dim3_j_inthebegining_multiplywidth;
        private long _ruleIteration = 0;

        #region ITestableModel Members

        public int GetCapacity()
        {
            return 2;
        }

        public void Test(ref IntPtr Dim0, ref IntPtr Dim1, ref IntPtr Dim2, ref IntPtr Dim3, ref IntPtr Dim4,
                         ref IntPtr Dim5,
                         ref IntPtr Dim6, ref IntPtr Dim7, ref IntPtr Dim8,
                         ref IntPtr Dim9, ref IntPtr Dim10, int iterationsCount, int height, int width,
                         IntPtr SdlScreenPixelBuffer, IntPtr colors)
        {
            height_1 = height - 1;
            width_1 = width - 1;

            int amplitude = 40;
            // 2 * 3.14 * 0.09 = 0.5652
            //short currentOffset = (short)Math.Round(amplitude * Math.Cos(0.002 * _ruleIteration));
            short currentOffset = (short)Math.Round(amplitude * Math.Cos(0.02 * _ruleIteration));
            //Console.WriteLine("Current offset = " + currentOffset.ToString());
            UInt32* SdlPositionInTheScreenBuffer = (UInt32*)SdlScreenPixelBuffer;
            UInt32* colorsT = (UInt32*)colors;
            short* ptDim0 = (short*)Dim0,
                   ptDim1 = (short*)Dim1,
                   ptDim3 = (short*)Dim3,
                   ptDim4 = (short*)Dim4,
                   ptDim5 = (short*)Dim5,
                   ptDim6 = (short*)Dim6;
            for (int i = 0; i < iterationsCount; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    jmult_width = j * width;
                    j_intheend_multiplywidth = (j == width_1 ? 0 : j + 1) * width;
                    j_inthebegining_multiplywidth = (j == 0 ? width_1 : j - 1) * width;
                    Dim0_jmult_width = ptDim0 + jmult_width;
                    Dim1_jmult_width = ptDim1 + jmult_width;
                    Dim3_jmult_width = ptDim3 + jmult_width;
                    Dim4_jmult_width = ptDim4 + jmult_width;
                    Dim5_jmult_width = ptDim5 + jmult_width;
                    Dim6_jmult_width = ptDim6 + jmult_width;
                    Dim0_j_intheend_multiplywidth = ptDim0 + j_intheend_multiplywidth;
                    Dim0_j_inthebegining_multiplywidth = ptDim0 + j_inthebegining_multiplywidth;
                    Dim1_j_intheend_multiplywidth = ptDim1 + j_intheend_multiplywidth;
                    Dim1_j_inthebegining_multiplywidth = ptDim1 + j_inthebegining_multiplywidth;
                    Dim3_j_intheend_multiplywidth = ptDim3 + j_intheend_multiplywidth;
                    Dim3_j_inthebegining_multiplywidth = ptDim3 + j_inthebegining_multiplywidth;

                    for (int k = 0; k < height; k++)
                    {
                        // look down for a cell which is exactly below the current OR in the very top
                        // if it is active, and offset was changed for it, then move pointer to the current cell position
                        if (*(Dim0_j_inthebegining_multiplywidth + k) == 1
                            // check that offset was changed
                            && *(Dim1_j_inthebegining_multiplywidth + k) != currentOffset
                            // check that pointer has to be moved UP
                            && *(Dim3_j_inthebegining_multiplywidth + k) <= 0)
                        {
                            *(Dim4_jmult_width + k) = 1;
                            *(Dim5_jmult_width + k) = currentOffset;
                            if (currentOffset == amplitude || currentOffset == -amplitude)
                            {
                                *(Dim6_jmult_width + k) = 1;
                            }
                            else
                            {
                                *(Dim6_jmult_width + k) = 0;
                            }
                        }

                        // look down for a cell which is exactly above the current OR in the very bottom
                        // if it is active, and offset was changed for it, then move pointer to the current cell position
                        else if (*(Dim0_j_intheend_multiplywidth + k) == 1
                            // check that offset was changed
                            && *(Dim1_j_intheend_multiplywidth + k) != currentOffset
                            // check that pointer has to be moved DOWN
                            && *(Dim3_j_intheend_multiplywidth + k) > 0)
                        {
                            *(Dim4_jmult_width + k) = 1;
                            *(Dim5_jmult_width + k) = currentOffset;
                            if (currentOffset == amplitude || currentOffset == -amplitude)
                            {
                                *(Dim6_jmult_width + k) = 0;
                            }
                            else
                            {
                                *(Dim6_jmult_width + k) = 1;
                            }
                        }

                        else if (*(Dim0_jmult_width + k) == 1 && *(Dim1_jmult_width + k) != currentOffset)
                        {
                            *(Dim4_jmult_width + k) = 0;
                        }
                        else
                        {
                            *(Dim4_jmult_width + k) = *(Dim0_jmult_width + k);
                            *(Dim6_jmult_width + k) = *(Dim3_jmult_width + k);
                            *(Dim5_jmult_width + k) = *(Dim1_jmult_width + k);
                        }

                        // adding colors to the visible plane
                        if (*(Dim4_jmult_width + k) == 1)
                        {
                            *(SdlPositionInTheScreenBuffer + jmult_width + k) = *(colorsT + 3);
                        }
                        else
                        {
                            *(SdlPositionInTheScreenBuffer + jmult_width + k) = *(colorsT + 11);
                        }
                    }
                }

                IntPtr numArray = Dim0;
                Dim0 = Dim4;
                Dim4 = numArray;
                numArray = Dim1;
                Dim1 = Dim5;
                Dim5 = numArray;
                numArray = Dim3;
                Dim3 = Dim6;
                Dim6 = numArray;

                // increasing rule iterations counter
                _ruleIteration++;
            }
        }

        public void Show(ref IntPtr Dim0, ref IntPtr Dim1, ref IntPtr Dim2, ref IntPtr Dim3, ref IntPtr Dim4, ref IntPtr Dim5, ref IntPtr Dim6, ref IntPtr Dim7, ref IntPtr Dim8, ref IntPtr Dim9, ref IntPtr Dim10, int height, int width, IntPtr SdlScreenPixelBuffer, IntPtr colors)
        {
            height_1 = height - 1;
            width_1 = width - 1;
            UInt32* SdlPositionInTheScreenBuffer = (UInt32*)SdlScreenPixelBuffer;
            UInt32* colorsT = (UInt32*)colors;
            short* ptDim0 = (short*)Dim0,
                   ptDim1 = (short*)Dim1,
                   ptDim3 = (short*)Dim3,
                   ptDim4 = (short*)Dim4,
                   ptDim5 = (short*)Dim5,
                   ptDim6 = (short*)Dim6;
            for (int j = 0; j < width; j++)
            {
                jmult_width = j * width;
                Dim4_jmult_width = ptDim4 + jmult_width;

                for (int k = 0; k < height; k++)
                {
                    if (*(Dim4_jmult_width + k) == 1)
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
            get { return "Harmonic Oscillator"; }
        }
        
        #endregion

        public override string ToString()
        {
            return "Detailed description of the harmonic oscillator";
        }
    }
}
