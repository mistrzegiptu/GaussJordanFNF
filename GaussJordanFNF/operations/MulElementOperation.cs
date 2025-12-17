using System;
using System.Collections.Generic;
using System.Text;

namespace GaussJordanFNF.operations
{
    internal class MulElementOperation : IOperation
    {
        public int I { get; }
        public int J { get; }
        public int K { get; }

        public MulElementOperation(int i, int j, int k)
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
