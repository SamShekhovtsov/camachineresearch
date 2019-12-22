using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using System.Drawing;

namespace CA.UI
{
    public unsafe class UserColorPalette
    {
        //NOTE: !!!!property is not used here to improve performance
        public IntPtr ArrayPointer = IntPtr.Zero;
        private GCHandle colorArrayPinnedHandler;
        public UserColorPalette(Color[] colors)
        {
            if (ArrayPointer == IntPtr.Zero)
            {
                //ArrayArrayPointer = Marshal.AllocHGlobal(colors.Length);
                //Marshal.Copy(colors.ToRGBColorsList(), 0, ArrayArrayPointer, colors.Length);            
                colorArrayPinnedHandler = GCHandle.Alloc(colors.ToRGBColorsList(), GCHandleType.Pinned);
                ArrayPointer = colorArrayPinnedHandler.AddrOfPinnedObject();
            }
        }

        public Color this[int i]
        {
            get
            {
                return Color.FromArgb((int)*((UInt32*)ArrayPointer + i));
            }
            set
            {
                *(((UInt32*)ArrayPointer) + i) = (UInt32)value.ToArgb();
            }
        }

        public void FreePinnedObjects()
        {
            //Marshal.FreeHGlobal(ArrayArrayPointer);
            colorArrayPinnedHandler.Free();
        }
    }

    public static class ColorExtension
    {
        public static UInt32[] ToRGBColorsList(this Color[] colors)
        {
            UInt32[] rgbColors = new UInt32[colors.Length];
            for (int i = 0; i < rgbColors.Length; i++)
            {
                rgbColors[i] = (UInt32)colors[i].ToArgb(); // & 0x00FFFFFF 
            }

            return rgbColors;
        }
    }
}
