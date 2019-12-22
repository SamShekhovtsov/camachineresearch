using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CA.Modes
{
    public unsafe class WaveSample : ITestableModel
    {
        private static int height_1;
        private static int width_1;
        private static int jmult_width;
        private static int j_intheend_multiplywidth;
        private static int j_inthebegining_multiplywidth;
        private static int k_intheend;
        private static int k_inthebegining;

        private static short* Dim0_jmult_width;
        private static short* Dim1_jmult_width;
        private static short* Dim2_jmult_width;
        private static short* Dim3_jmult_width;
        private static short* Dim4_jmult_width;
        private static short* Dim5_jmult_width;
        private static short* Dim6_jmult_width;
        private static short* Dim7_jmult_width;
        private static short* Dim8_jmult_width;
        private static short* Dim0_j_intheend_multiplywidth;
        private static short* Dim0_j_inthebegining_multiplywidth;
        private static short* Dim1_j_intheend_multiplywidth;
        private static short* Dim1_j_inthebegining_multiplywidth;
        private static short* Dim2_j_intheend_multiplywidth;
        private static short* Dim2_j_inthebegining_multiplywidth;
        private static short* Dim3_j_intheend_multiplywidth;
        private static short* Dim3_j_inthebegining_multiplywidth;
        private static short* Dim5_j_intheend_multiplywidth;
        private static short* Dim5_j_inthebegining_multiplywidth;
        private static short* Dim7_j_intheend_multiplywidth;
        private static short* Dim7_j_inthebegining_multiplywidth;
        private static short* Dim8_j_intheend_multiplywidth;
        private static short* Dim8_j_inthebegining_multiplywidth;
        private long _ruleIteration = 1;
        private double _pahseDelayKoef = 0.02;
        private short _spaceDistabilizationConstant = 7;
        private double _phase = 0.02;
        // Methods

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

            short visibilityDuration = 3;
            short activationEnergy = 10;

            // 2 * 3.14 * 0.09 = 0.5652
            //Console.WriteLine("Current offset = " + currentOffset.ToString());
            UInt32* SdlPositionInTheScreenBuffer = (UInt32*)SdlScreenPixelBuffer;
            UInt32* colorsT = (UInt32*)colors;
            short* ptDim0 = (short*)Dim0,
                   ptDim1 = (short*)Dim1,
                   ptDim2 = (short*)Dim2,
                   ptDim3 = (short*)Dim3,
                   ptDim4 = (short*)Dim4,
                   ptDim5 = (short*)Dim5,
                   ptDim6 = (short*)Dim6,
                   ptDim7 = (short*)Dim7,
                   ptDim8 = (short*)Dim8,
                   ptDim9 = (short*)Dim9;

            if (_ruleIteration == 1)
            {
                for (int j = 0; j < width; j++)
                {
                        jmult_width = j * width;
                        Dim0_jmult_width = ptDim0 + jmult_width;
                        Dim2_jmult_width = ptDim2 + jmult_width;
                        Dim5_jmult_width = ptDim5 + jmult_width;
                        Dim8_jmult_width = ptDim8 + jmult_width;
                    for (int k = 0; k < height; k++)
                    {
                        k_inthebegining = k == 0 ? height_1 : k - 1;
                        k_intheend = k == height_1 ? 0 : k + 1;

                        if (j == 40 && k==25)
                        {
                            *(Dim0_jmult_width + k) = 0;
                            *(Dim2_jmult_width + k) = 10;
                            *(Dim5_jmult_width + k) = -1;
                            *(Dim8_jmult_width + k) = 200;
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
                    Dim1_jmult_width = ptDim1 + jmult_width;
                    Dim2_jmult_width = ptDim2 + jmult_width;
                    Dim3_jmult_width = ptDim3 + jmult_width;
                    Dim4_jmult_width = ptDim4 + jmult_width;
                    Dim5_jmult_width = ptDim5 + jmult_width;
                    Dim6_jmult_width = ptDim6 + jmult_width;
                    Dim7_jmult_width = ptDim7 + jmult_width;
                    Dim8_jmult_width = ptDim8 + jmult_width;
                    Dim0_j_intheend_multiplywidth = ptDim0 + j_intheend_multiplywidth;
                    Dim0_j_inthebegining_multiplywidth = ptDim0 + j_inthebegining_multiplywidth;
                    Dim1_j_intheend_multiplywidth = ptDim1 + j_intheend_multiplywidth;
                    Dim1_j_inthebegining_multiplywidth = ptDim1 + j_inthebegining_multiplywidth;
                    Dim2_j_intheend_multiplywidth = ptDim2 + j_intheend_multiplywidth;
                    Dim2_j_inthebegining_multiplywidth = ptDim2 + j_inthebegining_multiplywidth;
                    Dim3_j_intheend_multiplywidth = ptDim3 + j_intheend_multiplywidth;
                    Dim3_j_inthebegining_multiplywidth = ptDim3 + j_inthebegining_multiplywidth;
                    Dim5_j_intheend_multiplywidth = ptDim5 + j_intheend_multiplywidth;
                    Dim5_j_inthebegining_multiplywidth = ptDim5 + j_inthebegining_multiplywidth;
                    Dim7_j_intheend_multiplywidth = ptDim7 + j_intheend_multiplywidth;
                    Dim7_j_inthebegining_multiplywidth = ptDim7 + j_inthebegining_multiplywidth;
                    Dim8_j_intheend_multiplywidth = ptDim8 + j_intheend_multiplywidth;
                    Dim8_j_inthebegining_multiplywidth = ptDim8 + j_inthebegining_multiplywidth;

                    for (int k = 0; k < height; k++)
                    {
                        // when current cell has no activity. No amplitude value
                        if (*(Dim5_jmult_width + k) == 0)
                        {
                            // THE SPACE ACTIVATION GOES HERE
                            // check if space around is unstable - top/bottom direction. two dimentions only

                            // Dim0/Dim2 - current and maximal energy of a cell

                            // activation condition
                            // check below the current cell if it can activate current cell
                            if (*(Dim5_j_inthebegining_multiplywidth + k) != 0 &&
                                *(Dim2_j_inthebegining_multiplywidth + k) == *(Dim0_j_inthebegining_multiplywidth + k))
                            {
                                // space around is not stable. Something is going on

                                // check if space around can activate current cell.
                                if ((*(Dim2_j_inthebegining_multiplywidth + k) + activationEnergy) < *(Dim8_j_inthebegining_multiplywidth + k))
                                {
                                    // MAIN ACTIVATION RULE
                                    // SET CURRENT ENERGY === MAXIMAL ENERGY
                                    // SET DIRECTION DECREASING
                                    // save for next generation
                                    *(Dim1_jmult_width + k) = 0; //(short) (*(Dim0_j_inthebegining_multiplywidth + k) - activationEnergy);

                                    // maximum energy is the same as current at initial point.
                                    *(Dim4_jmult_width + k) =  (short) (*(Dim2_j_inthebegining_multiplywidth + k) + activationEnergy);

                                    *(Dim7_jmult_width + k) = -1;

                                    // save the given energy amoun for farther calculations.
                                    *(Dim8_jmult_width + k) = *(Dim8_j_inthebegining_multiplywidth + k);
                                    Console.WriteLine("Activation in up direction " + (activationEnergy + *(Dim2_j_inthebegining_multiplywidth + k)));
                                }
                                else
                                {
                                    Console.WriteLine("Finished space activation in up direction j=" + j + " k=" + k);
                                }
                            }
                        }
                        else 
                        {
                            // THE WAVE FLOW GOES HERE
                            //Console.WriteLine("Checking inversion rule state for cell: j=" + j + " k=" + k);
                            //Console.WriteLine("Inversion rule state Current = " + *(Dim0_jmult_width + k)+ " Max=" + (*(Dim2_jmult_width + k) * -1));

                            //if (*(Dim0_jmult_width + k) == (*(Dim2_jmult_width + k) * -1))
                            if (*(Dim0_jmult_width + k) == *(Dim2_jmult_width + k))
                            {
                                // inverting direction here.
                                *(Dim7_jmult_width + k) = (short) (*(Dim5_jmult_width + k) == -1 ? 1 : -1);
                                
                                Console.WriteLine("Max energy before inversion: " + *(Dim2_jmult_width + k));
                                // inverting the maximum energy
                                *(Dim4_jmult_width + k) = (short) (*(Dim2_jmult_width + k) > 0 ? -*(Dim2_jmult_width + k) : *(Dim2_jmult_width + k));// * (*(Dim5_jmult_width + k)));
                                Console.WriteLine("Max energy after inversion: " + *(Dim4_jmult_width + k));
                                //Console.WriteLine("Reversing direction for cell: j=" + j + " k=" + k);
                            }else 

                            // TODO: check one extra step is not needed here
                            if (*(Dim5_jmult_width + k) == -1)
                            {
                                *(Dim1_jmult_width + k) += (short) (*(Dim0_jmult_width + k) + 1);
                                *(Dim4_jmult_width + k) = *(Dim2_jmult_width + k);
                                *(Dim7_jmult_width + k) = *(Dim5_jmult_width + k);
                                Console.WriteLine("Increasing energy for cell: j=" + j + " k=" + k + " energy=" + *(Dim1_jmult_width + k));
                            }
                            else if(*(Dim5_jmult_width + k) == 1)
                            {
                                *(Dim1_jmult_width + k) = (short) (*(Dim0_jmult_width + k) - 1);
                                //Console.WriteLine("Decreasing energy for cell val=" + *(Dim0_jmult_width + k) + " dec=" + (*(Dim0_jmult_width + k) - 1));
                                *(Dim4_jmult_width + k) = *(Dim2_jmult_width + k);
                                *(Dim7_jmult_width + k) = *(Dim5_jmult_width + k);
                                Console.WriteLine("Decreasing energy for cell: j=" + j + " k=" + k + " energy=" + *(Dim1_jmult_width + k));
                            }
                        }



//                            if (*(Dim1_j_inthebegining_multiplywidth + k) != 0 &&
//                                    (*(Dim1_j_inthebegining_multiplywidth + k) == *(Dim0_j_inthebegining_multiplywidth + k)))
//                                {
//                                    // set the MAX amplitude value. Max energy for the cell.
//                                    // it equals ene
//                                    var maxEnergyAndAmplitude =
//                                        (short)(*(Dim0_j_inthebegining_multiplywidth + k) + _spaceDistabilizationConstant);
//
//                                    Console.WriteLine("INIT MAX amplitude " + maxEnergyAndAmplitude);
//                                    // should stop expansion, when there is no more energy to distabilize the space above/below
//                                    if (maxEnergyAndAmplitude <= amplitude)
//                                    {
//                                        *(Dim4_jmult_width + k) = maxEnergyAndAmplitude;
//                                        *(Dim5_jmult_width + k) = maxEnergyAndAmplitude;
//                                    }
//                                }
//                                else if (*(Dim1_j_intheend_multiplywidth + k) != 0 &&
//                                         (*(Dim1_j_intheend_multiplywidth + k) == *(Dim0_j_intheend_multiplywidth + k)))
//                                {
//                                    // set the MAX amplitude value. Max energy for the cell.
//                                    // it equals ene
//                                    var maxEnergyAndAmplitude =
//                                        (short)(*(Dim0_j_intheend_multiplywidth + k) + _spaceDistabilizationConstant);
//
//                                    Console.WriteLine("INIT MAX amplitude " + maxEnergyAndAmplitude);
//                                    // should stop expansion, when there is no more energy to distabilize the space above/below
//                                    if (maxEnergyAndAmplitude <= amplitude)
//                                    {
//                                        *(Dim4_jmult_width + k) = maxEnergyAndAmplitude;
//                                        *(Dim5_jmult_width + k) = maxEnergyAndAmplitude;
//                                    }
////                                    else
////                                    {
////                                        Console.WriteLine("Limit of amplitude.");
////                                    }
//                                }
//                            }
//                        }
//                        // when the cell is active, max amplitude is already set
//                        else 
//                        {
//                            // TODO:
//                            // energy level temporary fix
//                            if (*(Dim0_jmult_width + k) == 1 && *(Dim1_jmult_width + k) == 0)
//                            {
//                                *(Dim0_jmult_width + k) = _spaceDistabilizationConstant;
//
//                                // TODO: Important!!
//                                // fix this later: right offset
//                                //*(Dim2_jmult_width + k) = (short)(*(Dim2_jmult_width + k - 1) - _spaceDistabilizationConstant);
//                            }
//
//                            // copy the amplitude value, for next iterations.
//                            *(Dim4_jmult_width + k) = *(Dim0_jmult_width + k);
//                            // recalculate it's energy
//                            //Console.WriteLine("Max amplitude of current oscillator: " + *(Dim4_jmult_width + k));
//                            var calculatedEnergy = (short)Math.Round(*(Dim4_jmult_width + k) * Math.Cos(_phase * _ruleIteration + (*(Dim2_jmult_width + k) + _pahseDelayKoef)));
//                            
//                            //Console.WriteLine("Energy calculated: " + calculatedEnergy);
//                            *(Dim5_jmult_width + k) = calculatedEnergy;
//                        }

                        // make particle visible to observer
                        if (*(Dim5_jmult_width + k) != 0 && (*(Dim2_jmult_width + k) - *(Dim0_jmult_width + k) < visibilityDuration))
                        {
                            *(SdlPositionInTheScreenBuffer + jmult_width + k) = *(colorsT + 3);
                        }
                        // the opposit side
//                        else if (*(Dim5_jmult_width + k) == 0 && *(Dim4_jmult_width + k) != 0)
//                        {
//                            *(SdlPositionInTheScreenBuffer + jmult_width + k) = *(colorsT + 3);
//                        }
                        else
                        {
                            *(SdlPositionInTheScreenBuffer + jmult_width + k) = *(colorsT + 11);
                        }


//                        //short currentOffset = (short)Math.Round(amplitude * Math.Cos(0.02 * _ruleIteration) + *(Dim2_jmult_width + k));
//                        short currentENERGYofParticleBelow = (short)Math.Round(amplitude * Math.Cos(_phase * _ruleIteration + (*(Dim2_j_inthebegining_multiplywidth + k) * _pahseDelayKoef)));
//                        short currentENERGYofParticleAbove = (short)Math.Round(amplitude * Math.Cos(_phase * _ruleIteration + (*(Dim2_j_intheend_multiplywidth + k)) * _pahseDelayKoef));
//                        short currentENERGYofThisCELL = (short)Math.Round(amplitude * Math.Cos(_phase * _ruleIteration + (*(Dim2_jmult_width + k) * _pahseDelayKoef)));
//
//                        bool activeParticleIsBelow = *(Dim0_j_inthebegining_multiplywidth + k) > 0
//                            // check that offset was changed
//                                                     && *(Dim1_j_inthebegining_multiplywidth + k) != currentENERGYofParticleBelow;
//
//                        bool activeParticleIsAbove = *(Dim0_j_intheend_multiplywidth + k) > 0
//                            // check that offset was changed
//                                                     && *(Dim1_j_intheend_multiplywidth + k) != currentENERGYofParticleAbove;
//
//                        if (activeParticleIsBelow
//                            // check that pointer has to be moved UP
//                            // from BOTOM to TOP direction
//                            && *(Dim3_j_inthebegining_multiplywidth + k) > 0)
//                        {
//                            *(Dim4_jmult_width + k) = 2;
//                            Console.WriteLine("Current energy is: " + currentENERGYofThisCELL);
//                            Console.WriteLine("Current energy Below is: " + currentENERGYofParticleBelow);
//
//                            if (*(Dim0_j_inthebegining_multiplywidth + k) == 1)
//                            {
//                                //Console.WriteLine("First movement of a particle");
//                                // this is the initial state of the particle, save information about _phase displacement
//                                *(Dim8_jmult_width + k) = (short)j;
//                                //Console.WriteLine("J is equal to: " + (short)j);
//                                //*(Dim8_jmult_width + k) = *(Dim2_j_inthebegining_multiplywidth + k);
//                            }
//                            else
//                            {
//                                *(Dim8_jmult_width + k) = *(Dim2_j_inthebegining_multiplywidth + k);
//                            }
//
//                            *(Dim5_jmult_width + k) = currentENERGYofParticleBelow;
//
//                            // change direction of movement rule, if particle is at the top or at the bottom
//                            // REVERSE of the movement
//                            // TODO: error here: when particle is in the middle, the energy is maximum, it's equal to amplitude of motion
//                            // TODO: do not reverse the direction when particle is in the middle
//                            if (currentENERGYofParticleBelow == amplitude)// || currentENERGYofParticleBelow == -amplitude
//                            {
//                                *(Dim6_jmult_width + k) = 0;
//                            }
//                            else
//                            {
//                                *(Dim6_jmult_width + k) = 1;
//                            }
//                            Console.WriteLine("Phase displacement: " + *(Dim8_jmult_width + k));
//                        }
//
//                        // look down for a cell which is exactly above the current OR in the very bottom
//                        // if it is active, and offset was changed for it, then move pointer to the current cell position
//                        else if (activeParticleIsAbove
//                            // check that pointer has to be moved DOWN
//                            && *(Dim3_j_intheend_multiplywidth + k) <= 0)
//                        {
//                            *(Dim4_jmult_width + k) = 2;
//                            Console.WriteLine("Current energy is: " + currentENERGYofThisCELL);
//                            Console.WriteLine("Current energy Above is: " + currentENERGYofParticleAbove);
//                            //Console.WriteLine("Start _phase: " + *(Dim2_j_intheend_multiplywidth + k));
//                            //Console.WriteLine("Current currentOffsetOfAbove is equal to : " + currentENERGYofParticleAbove);
//
//                            if (*(Dim0_j_intheend_multiplywidth + k) == 1)
//                            {
//                                //Console.WriteLine("First movement of a particle");
//                                // this is the initial state of the particle, save information about _phase displacement
//                                *(Dim8_jmult_width + k) = (short)j;
//                                //Console.WriteLine("J is equal to: " + (short)j);
//                                //*(Dim8_jmult_width + k) = *(Dim2_j_intheend_multiplywidth + k);
//                            }
//                            else
//                            {
//                                *(Dim8_jmult_width + k) = *(Dim2_j_intheend_multiplywidth + k);
//                            }
//
//                            *(Dim5_jmult_width + k) = currentENERGYofParticleAbove;
//
//                            // change direction of movement rule, if particle is at the top or at the bottom
//                            // REVERSE of the movement
//                            if (currentENERGYofParticleAbove == -amplitude) // currentENERGYofParticleAbove == amplitude ||
//                            {
//                                *(Dim6_jmult_width + k) = 1;
//                            }
//                            else
//                            {
//                                *(Dim6_jmult_width + k) = 0;
//                            }
//                            Console.WriteLine("Phase displacement: " + *(Dim8_jmult_width + k));
//                        }
//
//                        else if (*(Dim0_jmult_width + k) > 0 && *(Dim1_jmult_width + k) != currentENERGYofThisCELL)
//                        {
//                            *(Dim4_jmult_width + k) = 0;
//                        }
//                        else
//                        {
//                            *(Dim4_jmult_width + k) = *(Dim0_jmult_width + k);
//                            *(Dim6_jmult_width + k) = *(Dim3_jmult_width + k);
//                            *(Dim5_jmult_width + k) = *(Dim1_jmult_width + k);
//                            *(Dim8_jmult_width + k) = *(Dim2_jmult_width + k);
//                        }
//
//                        if (*(Dim4_jmult_width + k) > 0)
//                        {
//                            *(SdlPositionInTheScreenBuffer + jmult_width + k) = *(colorsT + 3);
//                        }
//                        else
//                        {
//                            *(SdlPositionInTheScreenBuffer + jmult_width + k) = *(colorsT + 11);
//                        }
                    }
                }

                // Dim 4 <----> Dim 0 visibility of a particle. 
                // bigger than zero - visible, othervise - not visible
                IntPtr numArray = Dim0;
                Dim0 = Dim1;
                Dim1 = numArray;

                // Dim 5 <----> Dim 1 stores previous calculated ENERGY of a cell. 
                // Time step - 1 energy level
                // Potential energy of a cell, re-calculated each iteration
                numArray = Dim2;
                Dim2 = Dim4;
                Dim4 = numArray;

                // Dim 8 <----> Dim 2 _phase displacement. 
                // Stores information about initial _phase of a particle oscillation
//                numArray = Dim3;
//                Dim3 = Dim6;
//                Dim6 = numArray;

                // Dim 6 <----> Dim 3 direction of particle motion
                // UPside or DOWN
                numArray = Dim5;
                Dim5 = Dim7;
                Dim7 = numArray;

                // increasing rule iterations counter
                _ruleIteration++;
            }
        }

        #region -- Old implementation --
        public void Test_OldCode(ref IntPtr Dim0, ref IntPtr Dim1, ref IntPtr Dim2, ref IntPtr Dim3, ref IntPtr Dim4,
                         ref IntPtr Dim5,
                         ref IntPtr Dim6, ref IntPtr Dim7, ref IntPtr Dim8,
                         ref IntPtr Dim9, ref IntPtr Dim10, int iterationsCount, int height, int width,
                         IntPtr SdlScreenPixelBuffer, IntPtr colors)
        {
            height_1 = height - 1;
            width_1 = width - 1;

            int amplitude = 40;
            // 2 * 3.14 * 0.09 = 0.5652
            double phase = 0.2;
            //Console.WriteLine("Current offset = " + currentOffset.ToString());
            UInt32* SdlPositionInTheScreenBuffer = (UInt32*)SdlScreenPixelBuffer;
            UInt32* colorsT = (UInt32*)colors;
            short* ptDim0 = (short*)Dim0,
                   ptDim1 = (short*)Dim1,
                   ptDim2 = (short*)Dim2,
                   ptDim3 = (short*)Dim3,
                   ptDim4 = (short*)Dim4,
                   ptDim5 = (short*)Dim5,
                   ptDim6 = (short*)Dim6,
                   ptDim7 = (short*)Dim7,
                   ptDim8 = (short*)Dim8,
                   ptDim9 = (short*)Dim9;
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
                    Dim3_jmult_width = ptDim3 + jmult_width;
                    Dim4_jmult_width = ptDim4 + jmult_width;
                    Dim5_jmult_width = ptDim5 + jmult_width;
                    Dim6_jmult_width = ptDim6 + jmult_width;
                    Dim7_jmult_width = ptDim7 + jmult_width;
                    Dim8_jmult_width = ptDim8 + jmult_width;
                    Dim0_j_intheend_multiplywidth = ptDim0 + j_intheend_multiplywidth;
                    Dim0_j_inthebegining_multiplywidth = ptDim0 + j_inthebegining_multiplywidth;
                    Dim1_j_intheend_multiplywidth = ptDim1 + j_intheend_multiplywidth;
                    Dim1_j_inthebegining_multiplywidth = ptDim1 + j_inthebegining_multiplywidth;
                    Dim2_j_intheend_multiplywidth = ptDim2 + j_intheend_multiplywidth;
                    Dim2_j_inthebegining_multiplywidth = ptDim2 + j_inthebegining_multiplywidth;
                    Dim3_j_intheend_multiplywidth = ptDim3 + j_intheend_multiplywidth;
                    Dim3_j_inthebegining_multiplywidth = ptDim3 + j_inthebegining_multiplywidth;
                    Dim7_j_intheend_multiplywidth = ptDim7 + j_intheend_multiplywidth;
                    Dim7_j_inthebegining_multiplywidth = ptDim7 + j_inthebegining_multiplywidth;

                    for (int k = 0; k < height; k++)
                    {
                        //k_inthebegining = k == 0 ? height_1 : k - 1;
                        //k_intheend = k == height_1 ? 0 : k + 1;

                        // look down for a cell which is exactly below the current
                        // if it is active, and offset was changed for it, then move pointer to the current cell position
                        /*if (*(Dim0_jmult_width + k + width) == 1
                            // check that offset was changed
                            && *(Dim1_jmult_width + k + width) != currentOffset
                            // check that pointer has to be moved UP
                            && *(Dim3_jmult_width + k + width) <= 0)
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


                        // look down for a cell which is exactly below the current OR in the very top
                        // if it is active, and offset was changed for it, then move pointer to the current cell position
                        else*/
                        
                        //short currentOffset = (short)Math.Round(amplitude * Math.Cos(0.02 * _ruleIteration) + *(Dim2_jmult_width + k));
                        short currentENERGYofParticleBelow = (short)Math.Round(amplitude * Math.Cos(phase * _ruleIteration + (*(Dim2_j_inthebegining_multiplywidth + k) * _pahseDelayKoef)));
                        short currentENERGYofParticleAbove = (short)Math.Round(amplitude * Math.Cos(phase * _ruleIteration + (*(Dim2_j_intheend_multiplywidth + k)) * _pahseDelayKoef));
                        short currentENERGYofThisCELL = (short)Math.Round(amplitude * Math.Cos(phase * _ruleIteration + (*(Dim2_jmult_width + k) * _pahseDelayKoef)));

                        bool activeParticleIsBelow = *(Dim0_j_inthebegining_multiplywidth + k) > 0
                                                     // check that offset was changed
                                                     && *(Dim1_j_inthebegining_multiplywidth + k) != currentENERGYofParticleBelow;

                        bool activeParticleIsAbove = *(Dim0_j_intheend_multiplywidth + k) > 0
                                                     // check that offset was changed
                                                     && *(Dim1_j_intheend_multiplywidth + k) != currentENERGYofParticleAbove;

                        if (activeParticleIsBelow
                            // check that pointer has to be moved UP
                            // from BOTOM to TOP direction
                            && *(Dim3_j_inthebegining_multiplywidth + k) > 0)
                        {
                            *(Dim4_jmult_width + k) = 2;
                            Console.WriteLine("Current energy is: " + currentENERGYofThisCELL);
                            Console.WriteLine("Current energy Below is: " + currentENERGYofParticleBelow);

                            if (*(Dim0_j_inthebegining_multiplywidth + k) == 1)
                            {
                                //Console.WriteLine("First movement of a particle");
                                // this is the initial state of the particle, save information about _phase displacement
                                *(Dim8_jmult_width + k) = (short)j;
                                //Console.WriteLine("J is equal to: " + (short)j);
                                //*(Dim8_jmult_width + k) = *(Dim2_j_inthebegining_multiplywidth + k);
                            }
                            else
                            {
                                *(Dim8_jmult_width + k) = *(Dim2_j_inthebegining_multiplywidth + k);
                            }

                            *(Dim5_jmult_width + k) = currentENERGYofParticleBelow;
                            
                            // change direction of movement rule, if particle is at the top or at the bottom
                            // REVERSE of the movement
                            // TODO: error here: when particle is in the middle, the energy is maximum, it's equal to amplitude of motion
                            // TODO: do not reverse the direction when particle is in the middle
                            if (currentENERGYofParticleBelow == amplitude)// || currentENERGYofParticleBelow == -amplitude
                            {
                                *(Dim6_jmult_width + k) = 0;
                            }
                            else
                            {
                                *(Dim6_jmult_width + k) = 1;
                            }
                            Console.WriteLine("Phase displacement: " + *(Dim8_jmult_width + k));
                        }

                        // look down for a cell which is exactly above the current
                        // if it is active, and offset was changed for it, then move pointer to the current cell position
                        /*else if (*(Dim0_jmult_width + k - width) == 1
                            // check that offset was changed
                            && *(Dim1_jmult_width + k - width) != currentOffset
                            // check that pointer has to be moved DOWN
                            && *(Dim3_jmult_width + k - width) > 0)
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
                        }*/

                        // look down for a cell which is exactly above the current OR in the very bottom
                        // if it is active, and offset was changed for it, then move pointer to the current cell position
                        else if (activeParticleIsAbove
                            // check that pointer has to be moved DOWN
                            && *(Dim3_j_intheend_multiplywidth + k) <= 0)
                        {
                            *(Dim4_jmult_width + k) = 2;
                            Console.WriteLine("Current energy is: " + currentENERGYofThisCELL);
                            Console.WriteLine("Current energy Above is: " + currentENERGYofParticleAbove);
                            //Console.WriteLine("Start _phase: " + *(Dim2_j_intheend_multiplywidth + k));
                            //Console.WriteLine("Current currentOffsetOfAbove is equal to : " + currentENERGYofParticleAbove);

                            if (*(Dim0_j_intheend_multiplywidth + k) == 1)
                            {
                                //Console.WriteLine("First movement of a particle");
                                // this is the initial state of the particle, save information about _phase displacement
                                *(Dim8_jmult_width + k) = (short)j;
                                //Console.WriteLine("J is equal to: " + (short)j);
                                //*(Dim8_jmult_width + k) = *(Dim2_j_intheend_multiplywidth + k);
                            }
                            else
                            {
                                *(Dim8_jmult_width + k) = *(Dim2_j_intheend_multiplywidth + k);
                            }

                            *(Dim5_jmult_width + k) = currentENERGYofParticleAbove;

                            // change direction of movement rule, if particle is at the top or at the bottom
                            // REVERSE of the movement
                            if (currentENERGYofParticleAbove == -amplitude) // currentENERGYofParticleAbove == amplitude ||
                            {
                                *(Dim6_jmult_width + k) = 1;
                            }
                            else
                            {
                                *(Dim6_jmult_width + k) = 0;
                            }
                            Console.WriteLine("Phase displacement: " + *(Dim8_jmult_width + k));
                        }

                        else if (*(Dim0_jmult_width + k) > 0 && *(Dim1_jmult_width + k) != currentENERGYofThisCELL)
                        {
                            *(Dim4_jmult_width + k) = 0;
                        }
                        else
                        {
                            *(Dim4_jmult_width + k) = *(Dim0_jmult_width + k);
                            *(Dim6_jmult_width + k) = *(Dim3_jmult_width + k);
                            *(Dim5_jmult_width + k) = *(Dim1_jmult_width + k);
                            *(Dim8_jmult_width + k) = *(Dim2_jmult_width + k);
                        }

                        if (*(Dim4_jmult_width + k) > 0)
                        {
                            *(SdlPositionInTheScreenBuffer + jmult_width + k) = *(colorsT + 3);
                        }
                        else
                        {
                            *(SdlPositionInTheScreenBuffer + jmult_width + k) = *(colorsT + 11);
                        }
                    }
                }

                // Dim 4 <----> Dim 0 visibility of a particle. 
                // bigger than zero - visible, othervise - not visible
                IntPtr numArray = Dim0;
                Dim0 = Dim4;
                Dim4 = numArray;

                // Dim 5 <----> Dim 1 stores previous calculated ENERGY of a cell. 
                // Time step - 1 energy level
                // Potential energy of a cell, re-calculated each iteration
                numArray = Dim1;
                Dim1 = Dim5;
                Dim5 = numArray;

                // Dim 8 <----> Dim 2 _phase displacement. 
                // Stores information about initial _phase of a particle oscillation
                numArray = Dim2;
                Dim2 = Dim8;
                Dim8 = numArray;

                // Dim 6 <----> Dim 3 direction of particle motion
                // UPside or DOWN
                numArray = Dim3;
                Dim3 = Dim6;
                Dim6 = numArray;

                // increasing rule iterations counter
                _ruleIteration++;
            }
        }

        #endregion

        #region ITestableModel Members

        public void Show(ref IntPtr Dim0, ref IntPtr Dim1, ref IntPtr Dim2, ref IntPtr Dim3, ref IntPtr Dim4, ref IntPtr Dim5, ref IntPtr Dim6, ref IntPtr Dim7, ref IntPtr Dim8, ref IntPtr Dim9, ref IntPtr Dim10, int height, int width, IntPtr SdlScreenPixelBuffer, IntPtr colors)
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
                   ptDim7 = (short*)Dim7,
                   ptDim8 = (short*)Dim8;
            for (int j = 0; j < width; j++)
            {
                jmult_width = j * width;
                Dim4_jmult_width = ptDim4 + jmult_width;
                Dim5_jmult_width = ptDim5 + jmult_width;

                for (int k = 0; k < height; k++)
                {
                    // make particle visible to observer
                    if (Math.Abs(*(Dim5_jmult_width + k)) > 0 && (*(Dim4_jmult_width + k) == *(Dim5_jmult_width + k)))
                    {
                        *(SdlPositionInTheScreenBuffer + jmult_width + k) = *(colorsT + 3);
                    }
                    // the opposit side
                    else if (*(Dim5_jmult_width + k) == 0 && *(Dim4_jmult_width + k) != 0)
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
            get { return "WaveSample"; }
        }
        #endregion

        public override string ToString()
        {
            return "WaveSample";
        }

        #region -- Old code --


        //*(Dim0_jmult_width + k + width) = 0;
        //*(Dim6_jmult_width + k) = *(Dim3_jmult_width + k);
        //*(Dim5_jmult_width + k) = *(Dim1_jmult_width + k);
        /*else if (*(Dim0_jmult_width + k) == 1 && *(Dim1_jmult_width + k) == currentOffset)
                        {
                            *(Dim4_jmult_width + k) = *(Dim0_jmult_width + k);
                            *(Dim6_jmult_width + k) = *(Dim3_jmult_width + k);
                            *(Dim5_jmult_width + k) = *(Dim1_jmult_width + k);
                        }*/
        //if (goToNextIteration)
        //{

        //}
                            //if (*(Dim1_jmult_width + k - width) == currentOffset)
                            //{
                            //    *(Dim4_jmult_width + k) = *(Dim0_jmult_width + k);
                            //}
                            //else
                            //{
                            //*(Dim4_jmult_width + k) = *(Dim0_jmult_width + k);
                            //}

        //*(Dim0_jmult_width + k - width) = 0;
        //*(Dim4_jmult_width + k) = *(Dim0_jmult_width + k);
        /*if (*(Dim1_jmult_width + k) != currentOffset && *(Dim0_jmult_width + k) == 1)
                        {
                            Console.WriteLine("Current offset stored: " + *(Dim1_jmult_width + k));
                            //*(Dim4_jmult_width + k) = 1;
                            // cursor offset from zero position

                            goToNextIteration = true;
                            *(Dim0_jmult_width + k) = 0;
                            *(Dim4_jmult_width + k) = 0;
                            // direction of the motion
                            if (*(Dim3_jmult_width + k) > 0)
                            {
                                *(Dim4_jmult_width + k + width) = 1;
                                *(Dim5_jmult_width + k + width) = currentOffset;
                                Console.WriteLine("Current offset == A OR -A " + (currentOffset == amplitude || currentOffset == -amplitude).ToString());
                                if (currentOffset == amplitude || currentOffset == -amplitude)
                                {
                                    *(Dim6_jmult_width + k + width) = 0;
                                }
                                else
                                {
                                    *(Dim6_jmult_width + k + width) = 1;
                                }

                                // color current and new cell
                                //*(SdlPositionInTheScreenBuffer + jmult_width + k) = *(colorsT + 11);

                                // color new cell
                                *(SdlPositionInTheScreenBuffer + jmult_width + k + width) = *(colorsT + 3);
                            }
                            else
                            {
                                *(Dim4_jmult_width + k - width) = 1;
                                *(Dim5_jmult_width + k - width) = currentOffset;
                                Console.WriteLine("Current offset == A OR -A " + (currentOffset == amplitude || currentOffset == -amplitude).ToString());
                                if (currentOffset == amplitude || currentOffset == -amplitude)
                                {
                                    *(Dim6_jmult_width + k - width) = 1;
                                }
                                else
                                {
                                    *(Dim6_jmult_width + k - width) = 0;
                                }

                                // color current cell
                                //*(SdlPositionInTheScreenBuffer + jmult_width + k) = *(colorsT + 11);

                                // color new cell
                                *(SdlPositionInTheScreenBuffer + jmult_width + k - width) = *(colorsT + 3);
                            }
                        }
                        else
                        {
                            *(Dim6_jmult_width + k) = *(Dim3_jmult_width + k);
                            *(Dim5_jmult_width + k) = *(Dim1_jmult_width + k);
                            *(Dim4_jmult_width + k) = *(Dim0_jmult_width + k);
                            //*(Dim5_jmult_width + k) = *(Dim1_jmult_width + k);
                            // color current cell as active
                            //*(SdlPositionInTheScreenBuffer + jmult_width + k) = *(colorsT + 3);
                        }*/


        #endregion
    }
}
