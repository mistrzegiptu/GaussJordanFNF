namespace GaussJordanFNF.operations
{
    internal interface IOperation : IRelatable
    {
        int I { get; }
        int K { get; }

        public void Execute(EquationMatrix matrix)
        {
            matrix.Execute(this);
        }
    }
}
