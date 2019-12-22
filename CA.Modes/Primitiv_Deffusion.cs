using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace CA.Modes
{
    public unsafe class Primitiv_Deffusion : ITestableModel
    {
        // Fields
        private short neighbour;
        private short neighbour1;
        private static int height_1;
        private static int width_1;
        private static int jmult_width;
        private static int j_intheend_multiplywidth;
        private static int j_inthebegining_multiplywidth;
        private static int k_intheend;
        private static int k_inthebegining;
        private static int interationsCount_1;

        private static short* Dim0_jmult_width;
        private static short* Dim0_j_intheend_multiplywidth;
        private static short* Dim0_j_inthebegining_multiplywidth;
        private static short* Dim1_jmult_width;
        private static short* Dim1_j_intheend_multiplywidth;
        private static short* Dim1_j_inthebegining_multiplywidth;
        private static short* Dim2_jmult_width;
        private static short* Dim4_jmult_width;
        private static short* Dim5_jmult_width;
        private static short* Dim6_jmult_width;

        #region ITestableModel Members

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
            height_1 = height - 1;
            width_1 = width - 1;
            interationsCount_1 = iterationsCount - 1;
            UInt32* SdlPositionInTheScreenBuffer = (UInt32*)SdlScreenPixelBuffer;
            UInt32* colorsT = (UInt32*)colors;
            short* ptDim0 = (short*)Dim0,
                   ptDim1 = (short*)Dim1,
                   ptDim2 = (short*)Dim2,
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
                    Dim2_jmult_width = ptDim2 + jmult_width;
                    Dim4_jmult_width = ptDim4 + jmult_width;
                    Dim5_jmult_width = ptDim5 + jmult_width;
                    Dim6_jmult_width = ptDim6 + jmult_width;
                    Dim1_j_intheend_multiplywidth = ptDim1 + j_intheend_multiplywidth;
                    Dim1_j_inthebegining_multiplywidth = ptDim1 + j_inthebegining_multiplywidth;
                    for (int k = 0; k < height; k++)
                    {
                        k_inthebegining = k == 0 ? height_1 : k - 1;
                        k_intheend = k == height_1 ? 0 : k + 1;

                        *(Dim5_jmult_width + k) = (short)((((
                            *(Dim1_j_intheend_multiplywidth + k) &
                            *(Dim1_jmult_width + k_intheend)) ^
                            *(Dim1_jmult_width + k_inthebegining)) ^
                            *(Dim1_j_inthebegining_multiplywidth + k)) ^
                            *(Dim1_jmult_width + k));

                        *(Dim6_jmult_width + k) = (*(Dim2_jmult_width + k) == 0) ? ((short)1) : ((short)0);
                        neighbour = (*(Dim2_jmult_width + k) == 0) ? *(Dim0_jmult_width + k_intheend) : *(Dim0_jmult_width + k_inthebegining);
                        neighbour1 = (*(Dim2_jmult_width + k) == 0) ? *(Dim1_jmult_width + k_intheend) : *(Dim1_jmult_width + k_inthebegining);
                        *(Dim4_jmult_width + k) = ((*(Dim1_jmult_width + k) ^ neighbour1) == 1) ? neighbour : *(Dim0_jmult_width + k);
                        if ((i == interationsCount_1) && (*(Dim4_jmult_width + k) == 1))
                        {
                            *(SdlPositionInTheScreenBuffer + jmult_width + k) = *colorsT;
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
                numArray = Dim2;
                Dim2 = Dim6;
                Dim6 = numArray;
            }
        }
        
        public void Show(ref IntPtr Dim0, ref IntPtr Dim1, ref IntPtr Dim2, ref IntPtr Dim3, ref IntPtr Dim4, ref IntPtr Dim5, ref IntPtr Dim6, ref IntPtr Dim7, ref IntPtr Dim8, ref IntPtr Dim9, ref IntPtr Dim10, int height, int width, IntPtr SdlScreenPixelBuffer, IntPtr colors)
        {
            UInt32* SdlPositionInTheScreenBuffer = (UInt32*)SdlScreenPixelBuffer;
            UInt32* colorsT = (UInt32*)colors;
            short* ptDim4 = (short*)Dim4;
            for (int j = 0; j < width; j++)
            {
                jmult_width = j * width;
                for (int k = 0; k < height; k++)
                {
                    if (*(ptDim4 + jmult_width + k) == 1)
                    {
                        *(SdlPositionInTheScreenBuffer + jmult_width + k) = *colorsT;
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
            get { return Localization.Locales.Resources.Rules_Primitiv_Deffusion_Name; }
        }
        #endregion

        public override string ToString()
        {
            return Localization.Locales.Resources.Rules_Primitiv_Deffusion_Description;
        }
    }
}
