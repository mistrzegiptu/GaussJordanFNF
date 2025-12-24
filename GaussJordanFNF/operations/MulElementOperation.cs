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
            return $"B({I+1}, {J+1}, {K+1})";
        }

        public bool IsDependent(IRelatable other)
        {
            if(other is SubtractRowsOperation sro)
            {
                if (sro.I == I && sro.J == J && sro.K == K)
                    return true;
            }

            return false;
        }
    }
}
