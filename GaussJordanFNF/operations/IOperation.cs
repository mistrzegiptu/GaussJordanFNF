using System;
using System.Collections.Generic;
using System.Text;

namespace GaussJordanFNF.operations
{
    internal interface IOperation
    {
        int I { get; }
        int K { get; }

        public Matrix Execute(Matrix matrix);
        public Vector Execute(Vector vector);
    }
}
