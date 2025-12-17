using System;
using System.Collections.Generic;
using System.Text;

namespace GaussJordanFNF.operations
{
    internal class FindCommonMulOperation : IOperation
    {
        public int I { get; }
        public int K { get; }

        public FindCommonMulOperation(int i, int k)
        {
            I = i;
            K = k;
        }

        public void Execute(EquationMatrix matrix)
        {
            throw new NotImplementedException();
        }
    }
}
