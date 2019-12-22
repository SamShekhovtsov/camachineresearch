using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace CA.Modes
{
    [Serializable]
    public class Demographiya : ITestableModel, IDiagramme, ILead
    {
        // Fields
        private short ccw1;
        private short ccw2;
        private short ccwA;
        private short ccwB;
        private short cw1;
        private short cw2;
        private short cwA;
        private short cwB;
        public List<long>[] demografia = new List<long>[2];
        private int HunderDeath;
        private int LHerbivorous;
        private int LPredator;
        private short opp1;
        private short opp2;
        private short oppA;
        private short oppB;
        private long param_1;
        private long param_2;
        private bool phase = false;
        private int PHerbivorous;
        private int PPredator;
        private bool Satiety = false;
        private short Wccw;
        private short Wcw;
        private bool woll = false;
        private short Wopp;

        // Methods
        public Demographiya()
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
            //    int num4;
            //    int num5;
            //    this.phase = !this.phase;
            //    if (this.phase)
            //    {
            //        num4 = 0;
            //        while (num4 < width)
            //        {
            //            num5 = 0;
            //            while (num5 < length)
            //            {
            //                short num6;
            //                if (Math.Abs(listOfMatrices[3][num4, num5]) > 0)
            //                {
            //                    if ((Math.Abs(listOfMatrices[3][num4, num5]) >= this.LPredator) || (listOfMatrices[9][num4, num5] >= this.HunderDeath))
            //                    {
            //                        listOfMatrices[9][num4, num5] = (short)(num6 = 0);
            //                        listOfMatrices[3][num4, num5] = num6;
            //                    }
            //                    else
            //                    {
            //                        listOfMatrices[3][num4, num5] = (listOfMatrices[3][num4, num5] < 0) ? ((short)(listOfMatrices[3][num4, num5] - 1)) : ((short)(listOfMatrices[3][num4, num5] + 1));
            //                        listOfMatrices[9][num4, num5] = (short)(listOfMatrices[9][num4, num5] + 1);
            //                    }
            //                }
            //                if (listOfMatrices[0][num4, num5] > 0)
            //                {
            //                    listOfMatrices[0][num4, num5] = (listOfMatrices[0][num4, num5] < this.LHerbivorous) ? ((short)(listOfMatrices[0][num4, num5] + 1)) : ((short)0);
            //                }
            //                if (listOfMatrices[3][num4, num5] > 0)
            //                {
            //                    if (listOfMatrices[0][(num4 == 0) ? (width - 1) : (num4 - 1), num5] > 0)
            //                    {
            //                        listOfMatrices[0][(num4 == 0) ? (width - 1) : (num4 - 1), num5] = 0;
            //                        listOfMatrices[3][(num4 == 0) ? (width - 1) : (num4 - 1), num5] = listOfMatrices[3][num4, num5];
            //                        listOfMatrices[9][(num4 == 0) ? (width - 1) : (num4 - 1), num5] = 0;
            //                        if (num3 == (iterationsCount - 1))
            //                        {
            //                            b.SetPixel(num5, (num4 == 0) ? (width - 1) : (num4 - 1), Colors[4]);
            //                        }
            //                        listOfMatrices[3][num4, num5] = (short)(num6 = 0);
            //                        listOfMatrices[9][num4, num5] = num6;
            //                        this.Satiety = true;
            //                    }
            //                    else if (listOfMatrices[0][(num4 == (width - 1)) ? 0 : (num4 + 1), num5] > 0)
            //                    {
            //                        listOfMatrices[0][(num4 == (width - 1)) ? 0 : (num4 + 1), num5] = 0;
            //                        listOfMatrices[3][(num4 == (width - 1)) ? 0 : (num4 + 1), num5] = (short) (-listOfMatrices[3][num4, num5]);
            //                        listOfMatrices[9][(num4 == (width - 1)) ? 0 : (num4 + 1), num5] = 0;
            //                        if (num3 == (iterationsCount - 1))
            //                        {
            //                            b.SetPixel(num5, (num4 == (width - 1)) ? 0 : (num4 + 1), Colors[4]);
            //                        }
            //                        listOfMatrices[3][num4, num5] = (short)(num6 = 0);
            //                        listOfMatrices[9][num4, num5] = num6;
            //                        this.Satiety = true;
            //                    }
            //                    else if (listOfMatrices[0][num4, (num5 == 0) ? (length - 1) : (num5 - 1)] > 0)
            //                    {
            //                        listOfMatrices[0][num4, (num5 == 0) ? (length - 1) : (num5 - 1)] = 0;
            //                        listOfMatrices[3][num4, (num5 == 0) ? (length - 1) : (num5 - 1)] = listOfMatrices[3][num4, num5];
            //                        listOfMatrices[9][num4, (num5 == 0) ? (length - 1) : (num5 - 1)] = 0;
            //                        if (num3 == (iterationsCount - 1))
            //                        {
            //                            b.SetPixel((num5 == 0) ? (length - 1) : (num5 - 1), num4, Colors[4]);
            //                        }
            //                        listOfMatrices[3][num4, num5] = (short)(num6 = 0);
            //                        listOfMatrices[9][num4, num5] = num6;
            //                        this.Satiety = true;
            //                    }
            //                    else if (listOfMatrices[0][num4, (num5 == (length - 1)) ? 0 : (num5 + 1)] > 0)
            //                    {
            //                        listOfMatrices[0][num4, (num5 == (length - 1)) ? 0 : (num5 + 1)] = 0;
            //                        listOfMatrices[3][num4, (num5 == (length - 1)) ? 0 : (num5 + 1)] = (short) (-listOfMatrices[3][num4, num5]);
            //                        listOfMatrices[9][num4, (num5 == (length - 1)) ? 0 : (num5 + 1)] = 0;
            //                        if (num3 == (iterationsCount - 1))
            //                        {
            //                            b.SetPixel((num5 == (length - 1)) ? 0 : (num5 + 1), num4, Colors[4]);
            //                        }
            //                        listOfMatrices[3][num4, num5] = (short)(num6 = 0);
            //                        listOfMatrices[9][num4, num5] = num6;
            //                        this.Satiety = true;
            //                    }
            //                    else if (listOfMatrices[0][(num4 == 0) ? (width - 1) : (num4 - 1), (num5 == 0) ? (length - 1) : (num5 - 1)] > 0)
            //                    {
            //                        listOfMatrices[0][(num4 == 0) ? (width - 1) : (num4 - 1), (num5 == 0) ? (length - 1) : (num5 - 1)] = 0;
            //                        listOfMatrices[3][(num4 == 0) ? (width - 1) : (num4 - 1), (num5 == 0) ? (length - 1) : (num5 - 1)] = listOfMatrices[3][num4, num5];
            //                        listOfMatrices[9][(num4 == 0) ? (width - 1) : (num4 - 1), (num5 == 0) ? (length - 1) : (num5 - 1)] = 0;
            //                        if (num3 == (iterationsCount - 1))
            //                        {
            //                            b.SetPixel((num5 == 0) ? (length - 1) : (num5 - 1), (num4 == 0) ? (width - 1) : (num4 - 1), Colors[4]);
            //                        }
            //                        listOfMatrices[3][num4, num5] = (short)(num6 = 0);
            //                        listOfMatrices[9][num4, num5] = num6;
            //                        this.Satiety = true;
            //                    }
            //                    else if (listOfMatrices[0][(num4 == (width - 1)) ? 0 : (num4 + 1), (num5 == (length - 1)) ? 0 : (num5 + 1)] > 0)
            //                    {
            //                        listOfMatrices[0][(num4 == (width - 1)) ? 0 : (num4 + 1), (num5 == (length - 1)) ? 0 : (num5 + 1)] = 0;
            //                        listOfMatrices[3][(num4 == (width - 1)) ? 0 : (num4 + 1), (num5 == (length - 1)) ? 0 : (num5 + 1)] = (short) (-listOfMatrices[3][num4, num5]);
            //                        listOfMatrices[9][(num4 == (width - 1)) ? 0 : (num4 + 1), (num5 == (length - 1)) ? 0 : (num5 + 1)] = 0;
            //                        if (num3 == (iterationsCount - 1))
            //                        {
            //                            b.SetPixel((num5 == (length - 1)) ? 0 : (num5 + 1), (num4 == (width - 1)) ? 0 : (num4 + 1), Colors[4]);
            //                        }
            //                        listOfMatrices[3][num4, num5] = (short)(num6 = 0);
            //                        listOfMatrices[9][num4, num5] = num6;
            //                        this.Satiety = true;
            //                    }
            //                    else if (listOfMatrices[0][(num4 == 0) ? (width - 1) : (num4 - 1), (num5 == (length - 1)) ? 0 : (num5 + 1)] > 0)
            //                    {
            //                        listOfMatrices[0][(num4 == 0) ? (width - 1) : (num4 - 1), (num5 == (length - 1)) ? 0 : (num5 + 1)] = 0;
            //                        listOfMatrices[3][(num4 == 0) ? (width - 1) : (num4 - 1), (num5 == (length - 1)) ? 0 : (num5 + 1)] = listOfMatrices[3][num4, num5];
            //                        listOfMatrices[9][(num4 == 0) ? (width - 1) : (num4 - 1), (num5 == (length - 1)) ? 0 : (num5 + 1)] = 0;
            //                        if (num3 == (iterationsCount - 1))
            //                        {
            //                            b.SetPixel((num5 == (length - 1)) ? 0 : (num5 + 1), (num4 == 0) ? (width - 1) : (num4 - 1), Colors[4]);
            //                        }
            //                        listOfMatrices[3][num4, num5] = (short)(num6 = 0);
            //                        listOfMatrices[9][num4, num5] = num6;
            //                        this.Satiety = true;
            //                    }
            //                    else if (listOfMatrices[0][(num4 == (width - 1)) ? 0 : (num4 + 1), (num5 == 0) ? (length - 1) : (num5 - 1)] > 0)
            //                    {
            //                        listOfMatrices[0][(num4 == (width - 1)) ? 0 : (num4 + 1), (num5 == 0) ? (length - 1) : (num5 - 1)] = 0;
            //                        listOfMatrices[3][(num4 == (width - 1)) ? 0 : (num4 + 1), (num5 == 0) ? (length - 1) : (num5 - 1)] = (short) (-listOfMatrices[3][num4, num5]);
            //                        listOfMatrices[9][(num4 == (width - 1)) ? 0 : (num4 + 1), (num5 == 0) ? (length - 1) : (num5 - 1)] = 0;
            //                        if (num3 == (iterationsCount - 1))
            //                        {
            //                            b.SetPixel((num5 == 0) ? (length - 1) : (num5 - 1), (num4 == (width - 1)) ? 0 : (num4 + 1), Colors[4]);
            //                        }
            //                        listOfMatrices[3][num4, num5] = (short)(num6 = 0);
            //                        listOfMatrices[9][num4, num5] = num6;
            //                        this.Satiety = true;
            //                    }
            //                }
            //                else if (listOfMatrices[3][num4, num5] < 0)
            //                {
            //                    listOfMatrices[3][num4, num5] = (short) (-listOfMatrices[3][num4, num5]);
            //                }
            //                if ((((listOfMatrices[0][num4, num5] > 0) && ((listOfMatrices[0][num4, num5] % this.PHerbivorous) == 0)) && (listOfMatrices[0][num4, num5] > 2)) && (((listOfMatrices[0][(num4 == (width - 1)) ? 0 : (num4 + 1), (num5 == (length - 1)) ? 0 : (num5 + 1)] == 0) && (listOfMatrices[3][(num4 == (width - 1)) ? 0 : (num4 + 1), (num5 == (length - 1)) ? 0 : (num5 + 1)] == 0)) && (listOfMatrices[8][(num4 == (width - 1)) ? 0 : (num4 + 1), (num5 == (length - 1)) ? 0 : (num5 + 1)] == 0)))
            //                {
            //                    listOfMatrices[0][(num4 == (width - 1)) ? 0 : (num4 + 1), (num5 == (length - 1)) ? 0 : (num5 + 1)] = 1;
            //                }
            //                if ((((listOfMatrices[3][num4, num5] > 0) && ((listOfMatrices[3][num4, num5] % this.PPredator) == 0)) && (listOfMatrices[3][num4, num5] > 2)) && (((listOfMatrices[3][(num4 == (width - 1)) ? 0 : (num4 + 1), (num5 == (length - 1)) ? 0 : (num5 + 1)] == 0) && (listOfMatrices[0][(num4 == (width - 1)) ? 0 : (num4 + 1), (num5 == (length - 1)) ? 0 : (num5 + 1)] == 0)) && (listOfMatrices[8][(num4 == (width - 1)) ? 0 : (num4 + 1), (num5 == (length - 1)) ? 0 : (num5 + 1)] == 0)))
            //                {
            //                    listOfMatrices[3][(num4 == (width - 1)) ? 0 : (num4 + 1), (num5 == (length - 1)) ? 0 : (num5 + 1)] = 1;
            //                    listOfMatrices[9][(num4 == (width - 1)) ? 0 : (num4 + 1), (num5 == (length - 1)) ? 0 : (num5 + 1)] = 1;
            //                }
            //                if ((listOfMatrices[0][num4, num5] > 0) && (listOfMatrices[8][num4, num5] > 0))
            //                {
            //                    listOfMatrices[0][num4, num5] = 0;
            //                }
            //                if (num3 == (iterationsCount - 1))
            //                {
            //                    if (listOfMatrices[0][num4, num5] > 0)
            //                    {
            //                        b.SetPixel(num5, num4, Colors[8]);
            //                    }
            //                    if (listOfMatrices[3][num4, num5] > 0)
            //                    {
            //                        b.SetPixel(num5, num4, Colors[4]);
            //                    }
            //                    if (listOfMatrices[8][num4, num5] == 1)
            //                    {
            //                        b.SetPixel(num5, num4, Colors[1]);
            //                    }
            //                }
            //                num5++;
            //            }
            //            num4++;
            //        }
            //    }
            //    else
            //    {
            //        for (num4 = 0; num4 < width; num4++)
            //        {
            //            num5 = 0;
            //            while (num5 < length)
            //            {
            //                switch (listOfMatrices[2][num4, num5])
            //                {
            //                    case 0:
            //                        this.cwA = listOfMatrices[0][num4, (num5 == (length - 1)) ? 0 : (num5 + 1)];
            //                        this.ccwA = listOfMatrices[0][(num4 == (width - 1)) ? 0 : (num4 + 1), num5];
            //                        this.oppA = listOfMatrices[0][(num4 == (width - 1)) ? 0 : (num4 + 1), (num5 == (length - 1)) ? 0 : (num5 + 1)];
            //                        this.cwB = listOfMatrices[3][num4, (num5 == (length - 1)) ? 0 : (num5 + 1)];
            //                        this.ccwB = listOfMatrices[3][(num4 == (width - 1)) ? 0 : (num4 + 1), num5];
            //                        this.oppB = listOfMatrices[3][(num4 == (width - 1)) ? 0 : (num4 + 1), (num5 == (length - 1)) ? 0 : (num5 + 1)];
            //                        this.cw1 = listOfMatrices[1][num4, (num5 == (length - 1)) ? 0 : (num5 + 1)];
            //                        this.ccw1 = listOfMatrices[1][(num4 == (width - 1)) ? 0 : (num4 + 1), num5];
            //                        this.opp1 = listOfMatrices[1][(num4 == (width - 1)) ? 0 : (num4 + 1), (num5 == (length - 1)) ? 0 : (num5 + 1)];
            //                        this.Wcw = listOfMatrices[8][num4, (num5 == (length - 1)) ? 0 : (num5 + 1)];
            //                        this.Wccw = listOfMatrices[8][(num4 == (width - 1)) ? 0 : (num4 + 1), num5];
            //                        this.Wopp = listOfMatrices[8][(num4 == (width - 1)) ? 0 : (num4 + 1), (num5 == (length - 1)) ? 0 : (num5 + 1)];
            //                        this.cw2 = listOfMatrices[9][num4, (num5 == (length - 1)) ? 0 : (num5 + 1)];
            //                        this.ccw2 = listOfMatrices[9][(num4 == (width - 1)) ? 0 : (num4 + 1), num5];
            //                        this.opp2 = listOfMatrices[9][(num4 == (width - 1)) ? 0 : (num4 + 1), (num5 == (length - 1)) ? 0 : (num5 + 1)];
            //                        break;

            //                    case 1:
            //                        this.cwA = listOfMatrices[0][(num4 == (width - 1)) ? 0 : (num4 + 1), num5];
            //                        this.ccwA = listOfMatrices[0][num4, (num5 == 0) ? (length - 1) : (num5 - 1)];
            //                        this.oppA = listOfMatrices[0][(num4 == (width - 1)) ? 0 : (num4 + 1), (num5 == 0) ? (length - 1) : (num5 - 1)];
            //                        this.cwB = listOfMatrices[3][(num4 == (width - 1)) ? 0 : (num4 + 1), num5];
            //                        this.ccwB = listOfMatrices[3][num4, (num5 == 0) ? (length - 1) : (num5 - 1)];
            //                        this.oppB = listOfMatrices[3][(num4 == (width - 1)) ? 0 : (num4 + 1), (num5 == 0) ? (length - 1) : (num5 - 1)];
            //                        this.cw1 = listOfMatrices[1][(num4 == (width - 1)) ? 0 : (num4 + 1), num5];
            //                        this.ccw1 = listOfMatrices[1][num4, (num5 == 0) ? (length - 1) : (num5 - 1)];
            //                        this.opp1 = listOfMatrices[1][(num4 == (width - 1)) ? 0 : (num4 + 1), (num5 == 0) ? (length - 1) : (num5 - 1)];
            //                        this.Wcw = listOfMatrices[8][(num4 == (width - 1)) ? 0 : (num4 + 1), num5];
            //                        this.Wccw = listOfMatrices[8][num4, (num5 == 0) ? (length - 1) : (num5 - 1)];
            //                        this.Wopp = listOfMatrices[8][(num4 == (width - 1)) ? 0 : (num4 + 1), (num5 == 0) ? (length - 1) : (num5 - 1)];
            //                        this.cw2 = listOfMatrices[9][(num4 == (width - 1)) ? 0 : (num4 + 1), num5];
            //                        this.ccw2 = listOfMatrices[9][num4, (num5 == 0) ? (length - 1) : (num5 - 1)];
            //                        this.opp2 = listOfMatrices[9][(num4 == (width - 1)) ? 0 : (num4 + 1), (num5 == 0) ? (length - 1) : (num5 - 1)];
            //                        break;

            //                    case 2:
            //                        this.cwA = listOfMatrices[0][(num4 == 0) ? (width - 1) : (num4 - 1), num5];
            //                        this.ccwA = listOfMatrices[0][num4, (num5 == (length - 1)) ? 0 : (num5 + 1)];
            //                        this.oppA = listOfMatrices[0][(num4 == 0) ? (width - 1) : (num4 - 1), (num5 == (length - 1)) ? 0 : (num5 + 1)];
            //                        this.cwB = listOfMatrices[3][(num4 == 0) ? (width - 1) : (num4 - 1), num5];
            //                        this.ccwB = listOfMatrices[3][num4, (num5 == (length - 1)) ? 0 : (num5 + 1)];
            //                        this.oppB = listOfMatrices[3][(num4 == 0) ? (width - 1) : (num4 - 1), (num5 == (length - 1)) ? 0 : (num5 + 1)];
            //                        this.cw1 = listOfMatrices[1][(num4 == 0) ? (width - 1) : (num4 - 1), num5];
            //                        this.ccw1 = listOfMatrices[1][num4, (num5 == (length - 1)) ? 0 : (num5 + 1)];
            //                        this.opp1 = listOfMatrices[1][(num4 == 0) ? (width - 1) : (num4 - 1), (num5 == (length - 1)) ? 0 : (num5 + 1)];
            //                        this.Wcw = listOfMatrices[8][(num4 == 0) ? (width - 1) : (num4 - 1), num5];
            //                        this.Wccw = listOfMatrices[8][num4, (num5 == (length - 1)) ? 0 : (num5 + 1)];
            //                        this.Wopp = listOfMatrices[8][(num4 == 0) ? (width - 1) : (num4 - 1), (num5 == (length - 1)) ? 0 : (num5 + 1)];
            //                        this.cw2 = listOfMatrices[9][(num4 == 0) ? (width - 1) : (num4 - 1), num5];
            //                        this.ccw2 = listOfMatrices[9][num4, (num5 == (length - 1)) ? 0 : (num5 + 1)];
            //                        this.opp2 = listOfMatrices[9][(num4 == 0) ? (width - 1) : (num4 - 1), (num5 == (length - 1)) ? 0 : (num5 + 1)];
            //                        break;

            //                    case 3:
            //                        this.cwA = listOfMatrices[0][num4, (num5 == 0) ? (length - 1) : (num5 - 1)];
            //                        this.ccwA = listOfMatrices[0][(num4 == 0) ? (width - 1) : (num4 - 1), num5];
            //                        this.oppA = listOfMatrices[0][(num4 == 0) ? (width - 1) : (num4 - 1), (num5 == 0) ? (length - 1) : (num5 - 1)];
            //                        this.cwB = listOfMatrices[3][num4, (num5 == 0) ? (length - 1) : (num5 - 1)];
            //                        this.ccwB = listOfMatrices[3][(num4 == 0) ? (width - 1) : (num4 - 1), num5];
            //                        this.oppB = listOfMatrices[3][(num4 == 0) ? (width - 1) : (num4 - 1), (num5 == 0) ? (length - 1) : (num5 - 1)];
            //                        this.cw1 = listOfMatrices[1][num4, (num5 == 0) ? (length - 1) : (num5 - 1)];
            //                        this.ccw1 = listOfMatrices[1][(num4 == 0) ? (width - 1) : (num4 - 1), num5];
            //                        this.opp1 = listOfMatrices[1][(num4 == 0) ? (width - 1) : (num4 - 1), (num5 == 0) ? (length - 1) : (num5 - 1)];
            //                        this.Wcw = listOfMatrices[8][num4, (num5 == 0) ? (length - 1) : (num5 - 1)];
            //                        this.Wccw = listOfMatrices[8][(num4 == 0) ? (width - 1) : (num4 - 1), num5];
            //                        this.Wopp = listOfMatrices[8][(num4 == 0) ? (width - 1) : (num4 - 1), (num5 == 0) ? (length - 1) : (num5 - 1)];
            //                        this.cw2 = listOfMatrices[9][num4, (num5 == 0) ? (length - 1) : (num5 - 1)];
            //                        this.ccw2 = listOfMatrices[9][(num4 == 0) ? (width - 1) : (num4 - 1), num5];
            //                        this.opp2 = listOfMatrices[9][(num4 == 0) ? (width - 1) : (num4 - 1), (num5 == 0) ? (length - 1) : (num5 - 1)];
            //                        break;
            //                }
            //                listOfMatrices[5][num4, num5] = (short)(((this.opp1 & this.ccw1) ^ this.cw1) ^ listOfMatrices[1][num4, num5]);
            //                listOfMatrices[6][num4, num5] = (short)(3 - listOfMatrices[2][num4, num5]);
            //                this.woll = (((this.Wopp + this.Wccw) + this.Wcw) + listOfMatrices[8][num4, num5]) > 0;
            //                if (this.woll)
            //                {
            //                    listOfMatrices[4][num4, num5] = listOfMatrices[0][num4, num5];
            //                    listOfMatrices[10][num4, num5] = listOfMatrices[9][num4, num5];
            //                    listOfMatrices[7][num4, num5] = listOfMatrices[3][num4, num5];
            //                }
            //                else
            //                {
            //                    listOfMatrices[7][num4, num5] = ((((listOfMatrices[1][num4, num5] ^ this.cw1) ^ this.ccw1) ^ this.opp1) == 0) ? this.ccwB : this.cwB;
            //                    listOfMatrices[10][num4, num5] = ((((listOfMatrices[1][num4, num5] ^ this.cw1) ^ this.ccw1) ^ this.opp1) == 0) ? this.ccw2 : this.cw2;
            //                    listOfMatrices[4][num4, num5] = ((((listOfMatrices[1][num4, num5] ^ this.cw1) ^ this.ccw1) ^ this.opp1) == 0) ? this.ccwA : this.cwA;
            //                }
            //                if (listOfMatrices[7][num4, num5] == listOfMatrices[4][num4, num5])
            //                {
            //                    listOfMatrices[4][num4, num5] = 0;
            //                }
            //                if (listOfMatrices[4][num4, num5] > 0)
            //                {
            //                    if (num3 == (iterationsCount - 1))
            //                    {
            //                        b.SetPixel(num5, num4, Colors[8]);
            //                    }
            //                    this.param_1 += 1L;
            //                }
            //                if (listOfMatrices[7][num4, num5] > 0)
            //                {
            //                    if (num3 == (iterationsCount - 1))
            //                    {
            //                        b.SetPixel(num5, num4, Colors[4]);
            //                    }
            //                    this.param_2 += 1L;
            //                }
            //                if ((listOfMatrices[8][num4, num5] == 1) && (num3 == (iterationsCount - 1)))
            //                {
            //                    b.SetPixel(num5, num4, Colors[1]);
            //                }
            //                num5++;
            //                this.Satiety = false;
            //                this.woll = false;
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
            //        numArray = listOfMatrices[2];
            //        listOfMatrices[2] = listOfMatrices[6];
            //        listOfMatrices[6] = numArray;
            //        numArray = listOfMatrices[3];
            //        listOfMatrices[3] = listOfMatrices[7];
            //        listOfMatrices[7] = numArray;
            //        numArray = listOfMatrices[9];
            //        listOfMatrices[9] = listOfMatrices[10];
            //        listOfMatrices[10] = numArray;
            //    }
            //    num3++;
            //    this.param_1 = 0L;
            //    this.param_2 = 0L;
            //}
        }

        public override string ToString()
        {
            return Localization.Locales.Resources.Rules_Demografia_Description;
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

        public int hunderDeath
        {
            get
            {
                return this.HunderDeath;
            }
            set
            {
                this.HunderDeath = value;
            }
        }

        public int LiveHerbivorous
        {
            get
            {
                return this.LHerbivorous;
            }
            set
            {
                this.LHerbivorous = value;
            }
        }

        public int LivePredator
        {
            get
            {
                return this.LPredator;
            }
            set
            {
                this.LPredator = value;
            }
        }

        public int ReproductionHerbivorousus
        {
            get
            {
                return this.PHerbivorous;
            }
            set
            {
                this.PHerbivorous = value;
            }
        }

        public int ReproductionPredators
        {
            get
            {
                return this.PPredator;
            }
            set
            {
                this.PPredator = value;
            }
        }

        #region ITestableModel Members


        public void Show(ref IntPtr Dim0, ref IntPtr Dim1, ref IntPtr Dim2, ref IntPtr Dim3, ref IntPtr Dim4, ref IntPtr Dim5, ref IntPtr Dim6, ref IntPtr Dim7, ref IntPtr Dim8, ref IntPtr Dim9, ref IntPtr Dim10, int height, int width, IntPtr SdlScreenPixelBuffer, IntPtr colors)
        {
            throw new NotImplementedException();
        }

        public string Name
        {
            get { return Localization.Locales.Resources.Rules_Demographiya_Name; }
        }

        #endregion
    }
}
