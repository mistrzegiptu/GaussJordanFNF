using GaussJordanFNF.operations;

namespace GaussJordanFNF
{
    internal static class GaussJordanExtension
    {
        public static List<IOperation> GaussJordanOperations(this EquationMatrix matrix)
        {
            List<IOperation> operations = new List<IOperation>();
            int n = matrix.Data.GetLength(0);

            for (int i = 0; i < n - 1; i++)
            {
                for(int j = i + 1; j < n; j++)
                {
                    operations.Add(new FindCommonMulOperation(i, j));
                    
                    for(int k = i; k <= n; k++)
                    {
                        operations.Add(new MulElementOperation(i, k, j));
                        operations.Add(new SubtractRowsOperation(i, k, j));
                    }
                }
            }

            return operations;
        }

        public static void NormalizeMatrix(this EquationMatrix matrix)
        {
            int n = matrix.Data.GetLength(0);
            for (int i = 0; i < n; i++)
            {
                var pivot = matrix.Data[i, i];
                if (pivot == 0.0)
                    throw new InvalidOperationException($"Cannot normalize row {i}, pivot element is zero.");
                for (int j = i; j < n; j++)
                {
                    matrix.Data[i, j] /= pivot;
                }
                matrix.Results[i] /= pivot;
            }

            for (int i = n - 1; i >= 0; i--)
            {
                for (int j = 0; j < i; j++)
                {
                    var factor = matrix.Data[j, i];
                    if (factor == 0.0)
                        continue;

                    for (int k = i; k < n; k++)
                        matrix.Data[j, k] -= factor * matrix.Data[i, k];

                    matrix.Results[j] -= factor * matrix.Results[i];

                    matrix.Data[j, i] = 0.0;
                }
            }
        }
    }
}