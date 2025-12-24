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
            return $"C({I+1}, {J+1}, {K+1})";
        }

        public bool IsDependent(IRelatable other)
        {
            if(other is FindCommonMulOperation o)
            {
                if (o.I == J && I + 1 == o.I && (K + 1 == o.K || K == o.K))
                    return true;
            }
            else if(other is MulElementOperation meo)
            {
                if(meo.I == I + 1 && meo.J == J && meo.K == K + 1)
                    return true;
            }
            else if(other is SubtractRowsOperation sro)
            {
                if (sro.I == I + 1 && sro.J == J && sro.K == K)
                    return true;
            }

            return false;
        }
    }
}
