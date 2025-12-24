using GaussJordanFNF;
using GaussJordanFNF.operations;

var fileName = args.Length == 1 ? args[0] : "case0.txt";

if (!File.Exists(fileName))
    fileName = @"..\..\..\in.txt";

var matrix = InputParser.ParseFile(fileName);

var operations = matrix.GaussJordanOperations();

var relations = new Relations<IOperation>(operations);

var graph = new MazurkiewiczGraph<IOperation>();
graph.BuildGraph(operations, relations);

var graphInDotFormat = graph.ToDotFormat();
var foataNormalForm = graph.ToFoataNormalForm();

var scheduler = new Scheduler(foataNormalForm.Form);

scheduler.ExecuteAll(matrix);

matrix.NormalizeMatrix();

Console.WriteLine(foataNormalForm);

File.WriteAllText("./out.txt", matrix.ToString());
File.WriteAllText("./outputGraphDot.txt", graphInDotFormat);

//Console.WriteLine("Dupa");