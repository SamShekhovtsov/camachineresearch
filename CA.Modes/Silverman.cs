using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace CA.Modes
{
    [Serializable]
    public unsafe class Silverman : ITestableModel, IDiagramme
    {
        #region -- old code --
        //// Fields
        //public List<long>[] demografia = new List<long>[2];
        //private long param_1;
        //private long param_2;

        //// Methods
        //public Silverman()
        //{
        //    this.demografia[0] = new List<long>();
        //    this.demografia[1] = new List<long>();
        //}

        //public int GetCapacity()
        //{
        //    return 2;
        //}

        //public void Test(int iterationsCount, int height, int width)
        //{
        //    int length = listOfMatrices[0].GetLength(0);
        //    int width = listOfMatrices[0].GetLength(1);
        //    b = new Bitmap(width, length);
        //    int num3 = 0;
        //    while (num3 < iterationsCount)
        //    {
        //        for (int i = 0; i < width; i++)
        //        {
        //            for (int j = 0; j < length; j++)
        //            {
        //                if ((listOfMatrices[0][i, j] | listOfMatrices[1][i, j]) == 0)
        //                {
        //                    int num6 = 0;
        //                    num6 += (listOfMatrices[0][(i == 0) ? (width - 1) : (i - 1), j] > 0) ? 1 : 0;
        //                    num6 += (listOfMatrices[0][(i == (width - 1)) ? 0 : (i + 1), j] > 0) ? 1 : 0;
        //                    num6 += (listOfMatrices[0][i, (j == 0) ? (length - 1) : (j - 1)] > 0) ? 1 : 0;
        //                    num6 += (listOfMatrices[0][i, (j == (length - 1)) ? 0 : (j + 1)] > 0) ? 1 : 0;
        //                    num6 += (listOfMatrices[0][(i == 0) ? (width - 1) : (i - 1), (j == 0) ? (length - 1) : (j - 1)] > 0) ? 1 : 0;
        //                    num6 += (listOfMatrices[0][(i == (width - 1)) ? 0 : (i + 1), (j == (length - 1)) ? 0 : (j + 1)] > 0) ? 1 : 0;
        //                    num6 += (listOfMatrices[0][(i == 0) ? (width - 1) : (i - 1), (j == (length - 1)) ? 0 : (j + 1)] > 0) ? 1 : 0;
        //                    num6 += (listOfMatrices[0][(i == (width - 1)) ? 0 : (i + 1), (j == 0) ? (length - 1) : (j - 1)] > 0) ? 1 : 0;
        //                    if (num6 == 2)
        //                    {
        //                        listOfMatrices[4][i, j] = 1;
        //                    }
        //                }
        //                else
        //                {
        //                    listOfMatrices[4][i, j] = 0;
        //                }
        //                listOfMatrices[5][i, j] = listOfMatrices[0][i, j];
        //                if (num3 == (iterationsCount - 1))
        //                {
        //                    if ((listOfMatrices[4][i, j] == 1) && (listOfMatrices[5][i, j] == 0))
        //                    {
        //                        b.SetPixel(j, i, Colors[2]);
        //                        this.param_1 += 1L;
        //                    }
        //                    else if ((listOfMatrices[4][i, j] == 0) && (listOfMatrices[5][i, j] == 1))
        //                    {
        //                        b.SetPixel(j, i, Colors[4]);
        //                        this.param_2 += 1L;
        //                    }
        //                }
        //            }
        //        }
        //        this.demografia[0].Add(this.param_1);
        //        this.demografia[1].Add(this.param_2);
        //        short[,] numArray = listOfMatrices[0];
        //        listOfMatrices[0] = listOfMatrices[4];
        //        listOfMatrices[4] = numArray;
        //        numArray = listOfMatrices[1];
        //        listOfMatrices[1] = listOfMatrices[5];
        //        listOfMatrices[5] = numArray;
        //        num3++;
        //        this.param_1 = 0L;
        //        this.param_2 = 0L;
        //    }
        //}

        //public override string ToString()
        //{
        //    return "Приклад системи другого порядку - де наступна конфігурація є функцією теперішньої і минулої конфігурацій, тобто, при визначенні подальшої траекторії використовується пара послідовних конфігурацій. Зворотністі системи дозволяє на її базі моделювати процеси Нь'ютонівської механіки. Автор - Ед Френкін, Масачусетський технологічний інститут.";
        //}
        #endregion

        // Properties        
        // Fields
        public List<long>[] demografia = new List<long>[2];
        private long param_1;
        private long param_2;

        // Methods
        public Silverman()
        {
            this.demografia[0] = new List<long>();
            this.demografia[1] = new List<long>();
        }
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

        private static int height_1;
        private static int width_1;
        private static int jmult_width;
        private static int j_intheend_multiplywidth;
        private static int j_inthebegining_multiplywidth;
        private static int interationsCount_1;
        private static int k_intheend;
        private static int k_inthebegining;

        private static short* Dim0_jmult_width;
        private static short* Dim1_jmult_width;
        private static short* Dim0_j_intheend_multiplywidth;
        private static short* Dim0_j_inthebegining_multiplywidth;
        private static short* Dim4_jmult_width;
        private static short* Dim5_jmult_width;

        // Methods
        public int GetCapacity()
        {
            return 1;
        }

        public void Test(ref IntPtr Dim0, ref IntPtr Dim1, ref IntPtr Dim2, ref IntPtr Dim3, ref IntPtr Dim4, ref IntPtr Dim5, ref IntPtr Dim6, ref IntPtr Dim7, ref IntPtr Dim8,
           ref IntPtr Dim9, ref IntPtr Dim10, int iterationsCount, int height, int width, IntPtr SdlScreenPixelBuffer, IntPtr colors)
        {
            //Stopwatch stopwatch = new Stopwatch();
            height_1 = height - 1;
            width_1 = width - 1;
            interationsCount_1 = iterationsCount - 1;
            //stopwatch.Start();
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
                    Dim1_jmult_width = ptDim1 + jmult_width;
                    Dim4_jmult_width = ptDim4 + jmult_width;
                    Dim5_jmult_width = ptDim5 + jmult_width;
                    Dim0_j_intheend_multiplywidth = ptDim0 + j_intheend_multiplywidth;
                    Dim0_j_inthebegining_multiplywidth = ptDim0 + j_inthebegining_multiplywidth;
                    for (int k = 0; k < height; k++)
                    {
                        if ((*(Dim0_jmult_width + k) | *(Dim1_jmult_width + k)) == 0)
                        {
                            int num6 = 0;
                            k_inthebegining = k == 0 ? height_1 : k - 1;
                            k_intheend = k == height_1 ? 0 : k + 1;
                            num6 += *(Dim0_j_inthebegining_multiplywidth + k) > 0 ? 1 : 0;
                            num6 += *(Dim0_j_intheend_multiplywidth + k) > 0 ? 1 : 0;
                            num6 += *(Dim0_jmult_width + k_inthebegining) > 0 ? 1 : 0;
                            num6 += *(Dim0_jmult_width + k_intheend) > 0 ? 1 : 0;
                            num6 += *(Dim0_j_inthebegining_multiplywidth + k_inthebegining) > 0 ? 1 : 0;
                            num6 += *(Dim0_j_intheend_multiplywidth + k_intheend) > 0 ? 1 : 0;
                            num6 += *(Dim0_j_inthebegining_multiplywidth + k_intheend) > 0 ? 1 : 0;
                            num6 += *(Dim0_j_intheend_multiplywidth + k_inthebegining) > 0 ? 1 : 0;
                            if (num6 == 2)
                            {
                                *(Dim4_jmult_width + k) = 1;
                            }
                        }
                        else
                        {
                            *(Dim4_jmult_width + k) = 0;
                        }
                        *(Dim5_jmult_width + k) = *(Dim0_jmult_width + k);
                        if (i == interationsCount_1)
                        {
                            if (*(Dim4_jmult_width + k) == 1 && *(Dim5_jmult_width + k) == 0)
                            {
                                *(SdlPositionInTheScreenBuffer + jmult_width + k) = *(colorsT + 2);
                                //b.SetPixel(k, j, Colors[2]);
                                //this.param_1 += 1L;
                            }
                            else if (*(Dim4_jmult_width + k) == 0 && *(Dim5_jmult_width + k) == 1)
                            {
                                *(SdlPositionInTheScreenBuffer + jmult_width + k) = *(colorsT + 4);
                                //b.SetPixel(k, j, Colors[4]);
                                //this.param_2 += 1L;
                            }
                            else
                            {
                                *(SdlPositionInTheScreenBuffer + jmult_width + k) = *(colorsT + 11);
                            }
                        }
                    }
                }
                //this.demografia[0].Add(this.param_1);
                //this.demografia[1].Add(this.param_2);
                IntPtr numArray = Dim0;
                Dim0 = Dim4;
                Dim4 = numArray;
                numArray = Dim1;
                Dim1 = Dim5;
                Dim5 = numArray;
                //this.param_1 = 0L;
                //this.param_2 = 0L;
                //stopwatch.Stop();
                //Console.WriteLine("Test method totally elapsed.: " + stopwatch.Elapsed);
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
            get { return Localization.Locales.Resources.Rules_Silverman_Name; }
        }

        public override string ToString()
        {
            return Localization.Locales.Resources.Rules_Silverman_Description;
        }
    }
}
