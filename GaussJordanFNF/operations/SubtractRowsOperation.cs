using System;
using System.Collections.Generic;
using System.Text;

namespace GaussJordanFNF.operations
{
    internal class SubtractRowsOperation : IOperation
    {
        public int I { get; }
        public int J { get; }
        public int K { get; }

        public SubtractRowsOperation(int i, int j, int k)
        {
            I = i;
            J = j;
            K = k;
        }

        public void Execute(EquationMatrix matrix)
        {
            throw new NotImplementedException();
        }
    }
}
