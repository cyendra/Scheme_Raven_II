﻿using System.Runtime.InteropServices;

namespace Engine.DataStruct
{
    [StructLayout(LayoutKind.Sequential)]
    public struct Color
    {
        public float Red { get; set; }
        public float Green { get; set; }
        public float Blue { get; set; }
        public float Alpha { get; set; }

        public Color(float r, float g, float b, float a)
            : this()
        {
            Red = r;
            Green = g;
            Blue = b;
            Alpha = a;
        }
    }

}
