using GaussJordanFNF.operations;
using System.Text;

namespace GaussJordanFNF
{
    internal static class MazurkiewiczGraphExtensions
    {
        public static string ToDotFormat(this MazurkiewiczGraph<IRelatable> graph)
        {
            var sb = new StringBuilder();

            sb.AppendLine("digraph g{");

            foreach (var vertex in graph.Vertices)
            {
                foreach (var neighbourVertex in vertex.ConnectedVertices)
                {
                    sb.AppendLine($"{vertex.Id} -> {neighbourVertex.Id}");
                }
            }

            foreach (var vertex in graph.Vertices)
            {
                sb.AppendLine($"{vertex.Id}[label={vertex.Data}]");
            }

            sb.AppendLine("}");

            return sb.ToString();
        }

        public static FoataNormalForm<IRelatable> ToFoataNormalForm(this MazurkiewiczGraph<IOperation> graph)
        {
            var foataNormalForm = new FoataNormalForm<IRelatable>();

            while (graph.Vertices.Count > 0)
            {
                var unconnectedVertices = graph.Vertices.Where(v => v.IncomingVertices.Count == 0);

                foataNormalForm.AddGroup(unconnectedVertices.Select(v => v.Data).Cast<IRelatable>().ToHashSet());

                graph.RemoveVertices(unconnectedVertices.ToList());
            }

            return foataNormalForm;
        }
    }
}
