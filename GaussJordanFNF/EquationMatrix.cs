using GaussJordanFNF.operations;
using System;
using System.Collections.Generic;
using System.Text;

namespace GaussJordanFNF
{
    internal class EquationMatrix
    {
        public double[,] Data { get; private set; }
        public double[] Results { get; private set; }

        public EquationMatrix(double[,] data, double[] results) 
        { 
            Data = data;
            Results = results;
        }

        public void Execute(IOperation operation)
        {
            if (operation is FindCommonMulOperation findCommonMul)
            {

            }
            else if (operation is MulElementOperation mulElement)
            {

            }
            else if (operation is SubtractRowsOperation subtractRows)
            {

            }
            else
                throw new ArgumentNullException();
        }
    }
}
