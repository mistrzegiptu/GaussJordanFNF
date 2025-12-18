// See https://aka.ms/new-console-template for more 

using GaussJordanFNF;

var matrix = InputParser.ParseFile("../../../in.txt");

var operations = matrix.GaussJordanOperations();

var relations = new Relations(operations);

foreach (var op in operations)
{
    Console.WriteLine(op);
}
relations.DependentOperations.ForEach(rel =>
{
    Console.WriteLine($"Dependent: {rel.Item1} <-> {rel.Item2}");
});
Console.WriteLine("Dupa");

