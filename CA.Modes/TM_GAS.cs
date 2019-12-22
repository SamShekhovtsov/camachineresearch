using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Threading;

namespace CA.Modes
{
    public unsafe class TM_GAS : ITestableModel
    {
        #region -- old code --
        //public short[] Dim0 { get; set; }
        //public short[] Dim1 { get; set; }
        //public short[] Dim2 { get; set; }
        //public short[] Dim3 { get; set; }
        //public short[] Dim4 { get; set; }
        //public short[] Dim5 { get; set; }
        //public short[] Dim6 { get; set; }
        //public short[] Dim7 { get; set; }
        //public short[] Dim8 { get; set; }
        //public short[] Dim9 { get; set; }
        //public short[] Dim10 { get; set; }
        //public Color[] DimColors { get; set; }
        //public Action GettingScreen { get; set; }
        //public Bitmap TargetBitmapScreen { get; set; }

        //// Methods
        //public int GetCapacity()
        //{
        //    return 1;
        //}

        //public void Test(int iterationsCount, int height, int width)
        //{
        //    Stopwatch stopwatch = new Stopwatch();
        //    short ccwA = 0;
        //    short ccwB = 0;
        //    short cwA = 0;
        //    short cwB = 0;
        //    short oppA = 0;
        //    short oppB = 0;
        //    bool collision = false;
        //    bool phase = false;
        //    bool woll = false;
        //    stopwatch.Start();
        //    //int height = Dim0.GetLength(0);
        //    //int width = Dim0.GetLength(1);
        //    //Bitmap targetBitmapScreen = new Bitmap(width, height);
        //    for (int i = 0; i < iterationsCount; i++)
        //    {
        //        phase = !phase;
        //        for (int j = 0; j < width; j++)
        //        {
        //            for (int k = 0; k < height; k++)
        //            {
        //                switch (Dim2[j * width + k])
        //                {
        //                    case 0:
        //                        cwA = Dim0[j * width + ((k == (height - 1)) ? 0 : (k + 1))];
        //                        ccwA = Dim0[((j == (width - 1)) ? 0 : (j + 1)) * width + k];
        //                        oppA = Dim0[((j == (width - 1)) ? 0 : (j + 1)) * width + ((k == (height - 1)) ? 0 : (k + 1))];
        //                        cwB = Dim3[j * width + ((k == (height - 1)) ? 0 : (k + 1))];
        //                        ccwB = Dim3[((j == (width - 1)) ? 0 : (j + 1)) * width + k];
        //                        oppB = Dim3[((j == (width - 1)) ? 0 : (j + 1)) * width + ((k == (height - 1)) ? 0 : (k + 1))];
        //                        break;

        //                    case 1:
        //                        cwA = Dim0[((j == (width - 1)) ? 0 : (j + 1)) * width + k];
        //                        ccwA = Dim0[j * width + ((k == 0) ? (height - 1) : (k - 1))];
        //                        oppA = Dim0[((j == (width - 1)) ? 0 : (j + 1)) * width + ((k == 0) ? (height - 1) : (k - 1))];
        //                        cwB = Dim3[((j == (width - 1)) ? 0 : (j + 1)) * width + k];
        //                        ccwB = Dim3[j * width + ((k == 0) ? (height - 1) : (k - 1))];
        //                        oppB = Dim3[((j == (width - 1)) ? 0 : (j + 1)) * width + ((k == 0) ? (height - 1) : (k - 1))];
        //                        break;

        //                    case 2:
        //                        cwA = Dim0[((j == 0) ? (width - 1) : (j - 1)) * width + k];
        //                        ccwA = Dim0[j * width + ((k == (height - 1)) ? 0 : (k + 1))];
        //                        oppA = Dim0[((j == 0) ? (width - 1) : (j - 1)) * width + ((k == (height - 1)) ? 0 : (k + 1))];
        //                        cwB = Dim3[((j == 0) ? (width - 1) : (j - 1)) * width + k];
        //                        ccwB = Dim3[j * width + ((k == (height - 1)) ? 0 : (k + 1))];
        //                        oppB = Dim3[((j == 0) ? (width - 1) : (j - 1)) * width + ((k == (height - 1)) ? 0 : (k + 1))];
        //                        break;

        //                    case 3:
        //                        cwA = Dim0[j * width + ((k == 0) ? (height - 1) : (k - 1))];
        //                        ccwA = Dim0[((j == 0) ? (width - 1) : (j - 1)) * width + k];
        //                        oppA = Dim0[((j == 0) ? (width - 1) : (j - 1)) * width + ((k == 0) ? (height - 1) : (k - 1))];
        //                        cwB = Dim3[j * width + ((k == 0) ? (height - 1) : (k - 1))];
        //                        ccwB = Dim3[((j == 0) ? (width - 1) : (j - 1)) * width + k];
        //                        oppB = Dim3[((j == 0) ? (width - 1) : (j - 1)) * width + ((k == 0) ? (height - 1) : (k - 1))];
        //                        break;
        //                }
        //                woll = (((oppB + ccwB) + cwB) + Dim3[j * width + k]) > 0;
        //                collision = ((Dim0[j * width + k] == oppA) && (cwA == ccwA)) && (Dim0[j * width + k] != cwA);
        //                Dim6[j * width + k] = (byte)(3 - Dim2[j * width + k]);
        //                if (woll || collision)
        //                {
        //                    Dim4[j * width + k] = Dim0[j * width + k];
        //                }
        //                else
        //                {
        //                    Dim4[j * width + k] = phase ? cwA : ccwA;
        //                }
        //                if (i == (iterationsCount - 1))
        //                {
        //                    //unsafe
        //                    //{
        //                    //if (Dim4[j * width + k] == 1)
        //                    //{
        //                    //    TargetBitmapScreen.SetPixel(k, j, DimColors[0]);
        //                    //}
        //                    //if (Dim3[j * width + k] == 1)
        //                    //{
        //                    //    TargetBitmapScreen.SetPixel(k, j, DimColors[3]);
        //                    //}
        //                    //}
        //                }
        //            }
        //        }

        //        // exchange temporary matrices with current, old with new
        //        short[] numArray = Dim0;
        //        Dim0 = Dim4;
        //        Dim4 = numArray;
        //        numArray = Dim2;
        //        Dim2 = Dim6;
        //        Dim6 = numArray;
        //    }
        //    stopwatch.Stop();
        //    Console.WriteLine("Test method totally elapsed.: " + stopwatch.Elapsed);
        //}

        //public override string ToString()
        //{
        //    return "Модель розрідженого газу з врахуванням зіткнень частинок, та зіткнень частинок з стінками пробірки. Автор Норман Марголус (Масачусетський технологічний інститут).";
        //}
        #endregion
        
        static bool _phase = false;
        private static int height_1;
        private static int width_1;
        private static int jmult_width;
        private static int j_intheend_multiplywidth;
        private static int j_inthebegining_multiplywidth;
        private static int interationsCount_1;
        private static short ccwA;
        private static short ccwB;
        private static short cwA;
        private static short cwB;
        private static short oppA;
        private static short oppB;
        private static bool collision = false;
        private static bool woll = false;
        private static int k_intheend;
        private static int k_inthebegining;

        private static short* Dim0_jmult_width;
        private static short* Dim0_j_intheend_multiplywidth;
        private static short* Dim0_j_inthebegining_multiplywidth;
        private static short* Dim3_jmult_width;
        private static short* Dim3_j_intheend_multiplywidth;
        private static short* Dim3_j_inthebegining_multiplywidth;
        private bool _firstTime = true;
        
        #region -- ITestableModel Members --
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
                   ptDim2 = (short*)Dim2,
                   ptDim3 = (short*)Dim3,
                   ptDim4 = (short*)Dim4,
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
                _phase = !_phase;
                for (int j = 0; j < width; j++)
                {
                    jmult_width = j * width;
                    j_intheend_multiplywidth = (j == width_1 ? 0 : j + 1) * width;
                    j_inthebegining_multiplywidth = (j == 0 ? width_1 : j - 1) * width;
                    Dim0_jmult_width = ptDim0 + jmult_width;
                    Dim0_j_intheend_multiplywidth = ptDim0 + j_intheend_multiplywidth;
                    Dim0_j_inthebegining_multiplywidth = ptDim0 + j_inthebegining_multiplywidth;
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
                                break;

                            case 1:
                                cwA = *(Dim0_j_intheend_multiplywidth + k);
                                ccwA = *(Dim0_jmult_width + k_inthebegining);
                                oppA = *(Dim0_j_intheend_multiplywidth + k_inthebegining);
                                cwB = *(Dim3_j_intheend_multiplywidth + k);
                                ccwB = *(Dim3_jmult_width + k_inthebegining);
                                oppB = *(Dim3_j_intheend_multiplywidth + k_inthebegining);
                                break;

                            case 2:
                                cwA = *(Dim0_j_inthebegining_multiplywidth + k);
                                ccwA = *(Dim0_jmult_width + k_intheend);
                                oppA = *(Dim0_j_inthebegining_multiplywidth + k_intheend);
                                cwB = *(Dim3_j_inthebegining_multiplywidth + k);
                                ccwB = *(Dim3_jmult_width + k_intheend);
                                oppB = *(Dim3_j_inthebegining_multiplywidth + k_intheend);
                                break;

                            case 3:
                                cwA = *(Dim0_jmult_width + k_inthebegining);
                                ccwA = *(Dim0_j_inthebegining_multiplywidth + k);
                                oppA = *(Dim0_j_inthebegining_multiplywidth + k_inthebegining);
                                cwB = *(Dim3_jmult_width + k_inthebegining);
                                ccwB = *(Dim3_j_inthebegining_multiplywidth + k);
                                oppB = *(Dim3_j_inthebegining_multiplywidth + k_inthebegining);
                                break;
                        }
                        woll = (((oppB + ccwB) + cwB) + *(Dim3_jmult_width + k)) > 0;
                        collision = ((*(Dim0_jmult_width + k) == oppA) && (cwA == ccwA)) && (*(Dim0_jmult_width + k) != cwA);
                        *(ptDim6 + jmult_width + k) = (short)(3 - *(ptDim2 + jmult_width + k));
                        if (woll || collision)
                        {
                            *(ptDim4 + jmult_width + k) = *(Dim0_jmult_width + k);
                        }
                        else
                        {
                            *(ptDim4 + jmult_width + k) = _phase ? cwA : ccwA;
                        }
                        if (i == interationsCount_1)
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
            }

            // exchange temporary matrices with current, old with new
            IntPtr numArray = Dim0;
            Dim0 = Dim4;
            Dim4 = numArray;
            numArray = Dim2;
            Dim2 = Dim6;
            Dim6 = numArray;
            //stopwatch.Stop();
            //Console.WriteLine("Test method totally elapsed.: " + stopwatch.Elapsed);
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
            get { return Localization.Locales.Resources.Rules_TM_GAS_Name; }
        }
        #endregion

        public override string ToString()
        {
            return Localization.Locales.Resources.Rules_TM_GAS_Description;
        }
    }
}
