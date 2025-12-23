namespace GaussJordanFNF.operations
{
    /// <summary>
    /// Represents an A matrix operation.
    /// </summary>
    internal class FindCommonMulOperation : IOperation
    {
        public int I { get; }
        public int K { get; }

        public FindCommonMulOperation(int i, int k)
        {
            I = i;
            K = k;
        }

        public override string ToString()
        {
            return $"A(I={I+1}, K={K+1})";
        }

        public bool IsDependent(IRelatable other)
        {
            if(other is MulElementOperation meo)
            {
                if (meo.I == I && meo.K == K)
                    return true;
            }
            
            return false;
        }
    }
}
