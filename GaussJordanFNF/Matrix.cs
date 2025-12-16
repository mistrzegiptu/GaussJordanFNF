using System;
using System.Collections.Generic;
using System.Text;

namespace GaussJordanFNF
{
    internal class Matrix
    {
        public double[,] Data { get; private set; }

        public Matrix(double[,] data) 
        { 
            Data = data;
        }
    }
}
