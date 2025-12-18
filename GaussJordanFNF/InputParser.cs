using GaussJordanFNF;
using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

internal class InputParser
{
    public static EquationMatrix ParseFile(string filePath)
    {
        var lines = File.ReadAllLines(filePath);

        var n = int.Parse(lines.First());
        var matrix = ParseMatrix(lines.Skip(1).Take(n), n);
        var vector = ParseVector(lines.Skip(n + 1).Take(1), n);

        return new EquationMatrix(matrix, vector);
    }

    private static double[,] ParseMatrix(IEnumerable<string> lines, int n)
    {
        var matrix = new double[n, n];

        for (int i = 0; i < n; i++)
            for(int j = 0; j < n; j++)
                matrix[i, j] = double.Parse(lines.ElementAt(i).Split(' ')[j], System.Globalization.CultureInfo.InvariantCulture);

        return matrix;
    }

    private static double[] ParseVector(IEnumerable<string> line, int n)
    {
        var vector = new double[n];

        var parsedLine = line.First().Split(' ').Select(x => double.Parse(x, System.Globalization.CultureInfo.InvariantCulture)).ToList();
        for (int i = 0; i < n; i++)
                vector[i] = parsedLine[i];

        return vector;
    }
}