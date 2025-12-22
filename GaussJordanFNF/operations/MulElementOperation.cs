using System;
using System.Collections.Generic;
using System.Text;

namespace GaussJordanFNF.operations
{
    /// <summary>
    /// Represents an B matrix operation.
    /// </summary>
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

        public override string ToString()
        {
            return $"B(I={I+1}, J={J+1}, K={K+1})";
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
                if (meo.I == I && meo.J == J && meo.K == K)
                    return true;
            }
            else if(other is SubtractRowsOperation sro)
            {
                if (sro.J == J)
                    return true;
            }

            return false;
        }
    }
}
