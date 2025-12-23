using GaussJordanFNF;
using GaussJordanFNF.operations;

var matrix = InputParser.ParseFile("../../../in.txt");

var operations = matrix.GaussJordanOperations();

var relations = new Relations<IOperation>(operations);

var graph = new MazurkiewiczGraph<IOperation>();
graph.BuildGraph(operations, relations);

var foataNormalForm = graph.ToFoataNormalForm();

var scheduler = new Scheduler(foataNormalForm.Form);

scheduler.ExecuteAll(matrix);

matrix.NormalizeMatrix();

Console.WriteLine(foataNormalForm);

Console.WriteLine(matrix);

File.WriteAllText("../../../out.txt", matrix.ToString());

//Console.WriteLine("Dupa");

