//-----------------------------------------------------------------------------
// <copyright file="ITestableModel.cs" company="SemQQQ">
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
    public interface ITestableModel
    {
        string Name { get; }
        int GetCapacity();

        void Test(ref IntPtr Dim0, ref IntPtr Dim1, ref IntPtr Dim2, ref IntPtr Dim3, ref IntPtr Dim4, ref IntPtr Dim5,
                  ref IntPtr Dim6, ref IntPtr Dim7, ref IntPtr Dim8,
                  ref IntPtr Dim9, ref IntPtr Dim10, int iterationsCount, int height, int width,
                  IntPtr SdlScreenPixelBuffer, IntPtr colors);

        void Show(ref IntPtr Dim0, ref IntPtr Dim1, ref IntPtr Dim2, ref IntPtr Dim3, ref IntPtr Dim4, ref IntPtr Dim5,
                  ref IntPtr Dim6, ref IntPtr Dim7, ref IntPtr Dim8,
                  ref IntPtr Dim9, ref IntPtr Dim10, int height, int width,
                  IntPtr SdlScreenPixelBuffer, IntPtr colors);
    }
}
