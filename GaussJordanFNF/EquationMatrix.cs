using GaussJordanFNF.operations;
using System.Collections.Concurrent;
using System.Text;

namespace GaussJordanFNF
{
    internal class EquationMatrix
    {
        public double[,] Data { get; private set; }
        public double[] Results { get; private set; }
        private readonly double[,] _multipliers;
        private readonly ConcurrentDictionary<(int I, int J, int K), double> _mulProducts;

        public EquationMatrix(double[,] data, double[] results)
        {
            Data = data;
            Results = results;

            var n = Data.GetLength(0);
            _multipliers = new double[n, n];
            _mulProducts = new ConcurrentDictionary<(int, int, int), double>();
        }

        public void Execute(IOperation operation)
        {
            if (operation is FindCommonMulOperation findCommonMul)
            {
                var i = findCommonMul.I;
                var k = findCommonMul.K;

                ValidateRowIndex(i);
                ValidateRowIndex(k);

                var pivot = Data[i, i];
                if (pivot == 0.0)
                    throw new InvalidOperationException($"Pivot element Data[{i},{i}] is zero.");

                _multipliers[i, k] = Data[k, i] / pivot;
            }
            else if (operation is MulElementOperation mulElement)
            {
                var i = mulElement.I;
                var j = mulElement.J;
                var k = mulElement.K;

                ValidateRowIndex(i);
                ValidateRowIndex(k);
                ValidateColumnIndexOrResult(j);

                var multiplier = _multipliers[i, k];

                if (multiplier == 0.0)
                {
                    var pivot = Data[i, i];
                    if (pivot == 0.0)
                        throw new InvalidOperationException($"Pivot element Data[{i},{i}] is zero.");
                    multiplier = Data[k, i] / pivot;
                }

                double product = j < Data.GetLength(1)
                    ? Data[i, j] * multiplier
                    : Results[i] * multiplier;

                _mulProducts[(i, j, k)] = product;
            }
            else if (operation is SubtractRowsOperation subtractRows)
            {
                var i = subtractRows.I;
                var j = subtractRows.J;
                var k = subtractRows.K;

                ValidateRowIndex(i);
                ValidateRowIndex(k);
                ValidateColumnIndexOrResult(j);

                var key = (i, j, k);

                if (!_mulProducts.TryGetValue(key, out var product))
                {
                    var multiplier = _multipliers[i, k];
                    if (multiplier == 0.0)
                    {
                        var pivot = Data[i, i];
                        if (pivot == 0.0)
                            throw new InvalidOperationException($"Pivot element Data[{i},{i}] is zero.");
                        multiplier = Data[k, i] / pivot;
                    }

                    product = j < Data.GetLength(1)
                        ? Data[i, j] * multiplier
                        : Results[i] * multiplier;

                    _mulProducts[key] = product;
                }

                if (j < Data.GetLength(1))
                    Data[k, j] -= product;
                else
                    Results[k] -= product;
            }
            else
                throw new ArgumentNullException(nameof(operation));
        }

        private void ValidateRowIndex(int index)
        {
            if (index < 0 || index >= Data.GetLength(0))
                throw new ArgumentOutOfRangeException(nameof(index), $"Row index {index} is out of range.");
        }

        private void ValidateColumnIndexOrResult(int index)
        {
            if (index < 0 || index > Data.GetLength(1))
                throw new ArgumentOutOfRangeException(nameof(index), $"Column/Result index {index} is out of range.");
        }

        public override string ToString()
        {
            double epsilon = 0.00001;
            var sb = new StringBuilder();
            int n = Data.GetLength(0);

            sb.AppendLine(n.ToString());
            
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (j > 0) 
                        sb.Append(' ');
                    if(Math.Abs(Data[i, j]) < epsilon)
                        sb.Append("0.0");
                    else
                        sb.Append(Data[i, j].ToString(System.Globalization.CultureInfo.InvariantCulture));
                }
                sb.AppendLine();
            }
            for (int i = 0; i < n; i++)
            {
                if (i > 0) 
                    sb.Append(' ');
                if (Math.Abs(Results[i]) < epsilon)
                    sb.Append("0.0");
                else
                    sb.Append(Results[i].ToString(System.Globalization.CultureInfo.InvariantCulture));
            }

            return sb.ToString();
        }
    }
}
