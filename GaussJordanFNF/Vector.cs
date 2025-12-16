using System;
using System.Collections.Generic;
using System.Text;

namespace GaussJordanFNF
{
    internal class Vector
    {
        public double[] Data { get; private set; }

        public Vector(double[] data)
        {
            Data = data;
        }
    }
}
