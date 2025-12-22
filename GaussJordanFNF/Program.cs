// See https://aka.ms/new-console-template for more 

using FoataNormalForm;
using GaussJordanFNF;

var matrix = InputParser.ParseFile("../../../in.txt");

var operations = matrix.GaussJordanOperations();

var relations = new Relations(operations);

foreach (var op in operations)
{
    Console.WriteLine(op);
}

foreach(var rel in relations.DependentOperations)
    Console.WriteLine($"Dependent: {rel.Item1} <-> {rel.Item2}");

var graph = new MazurkiewiczGraph();
graph.BuildGraph(operations, relations);

Console.WriteLine(graph.ToFoataNormalForm());

Console.WriteLine("Dupa");

