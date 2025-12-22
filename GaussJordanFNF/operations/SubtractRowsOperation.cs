using System;
using System.Collections.Generic;
using System.Text;

namespace GaussJordanFNF.operations
{
    /// <summary>
    /// Represents an C matrix operation.
    /// </summary>
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

        public override string ToString()
        {
            return $"C(I={I+1}, J={J+1}, K={K+1})";
        }

        public bool IsDependent(IOperation other)
        {
            if(other is FindCommonMulOperation o)
            {
                if (o.I == I || o.K == K)
                    return true;
            }
            else if(other is MulElementOperation meo)
            {
                if (meo.J == J)
                    return true;
            }
            else if(other is SubtractRowsOperation sro)
            {
                if (sro.I == I && sro.J == J && sro.K == K)
                    return true;
            }

            return false;
        }
    }
}
