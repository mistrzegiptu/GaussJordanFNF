using GaussJordanFNF.operations;
using System;
using System.Collections.Generic;
using System.Text;

namespace GaussJordanFNF
{
    internal static class GaussJordanExtension
    {
        public static List<IOperation> GaussJordanOperations(this EquationMatrix matrix)
        {
            List<IOperation> operations = new List<IOperation>();

            for (int i = 0; i < matrix.Data.GetLength(0) - 1; i++)
            {
                for(int j = i + 1; j < matrix.Data.GetLength(0); j++)
                {
                    operations.Add(new FindCommonMulOperation(i, j));
                    
                    for(int k = i; k <= matrix.Data.GetLength(1); k++)
                    {
                        operations.Add(new MulElementOperation(i, k, j));
                        operations.Add(new SubtractRowsOperation(i, k, j));
                    }
                }
            }

            return operations;
        }
    }
}