using FoataNormalForm;

namespace GaussJordanFNF
{
    internal class MazurkiewiczGraph<T> where T : IRelatable
    {
        private readonly List<Vertex<T>> _vertices = [];

        public List<Vertex<T>> Vertices => [.._vertices];

        public MazurkiewiczGraph(List<Vertex<T>> vertices)
        {
            _vertices = vertices;
        }

        public MazurkiewiczGraph() { }

        public void BuildGraph(List<T> word, Relations<T> relations)
        {
            _vertices.Clear();

            for(int i = 0; i < word.Count; i++)
                _vertices.Add(new Vertex<T>(i, word[i]));

            for (int step = 1; step < word.Count - 1; step++)
            {
                for (int i = 0; i < word.Count; i++)
                {
                    if(i+step >= word.Count)
                        break;

                    if (relations.DependentOperations.Contains((_vertices[i].Data, _vertices[i + step].Data)) &&
                        !AreConnected(_vertices[i], _vertices[i + step]))
                    {
                        _vertices[i].ConnectVertex(_vertices[i + step]);
                    }
                }
            }
        }

        private static bool AreConnected(Vertex<T> vertexA, Vertex<T> vertexB)
        {
            return DfsSearch(vertexA, vertexB, []);
        }

        private static bool DfsSearch(Vertex<T> current, Vertex<T> target, HashSet<Vertex<T>> visited)
        {
            if(visited.Contains(current)) 
                return false;

            if (current == target)
                return true;

            visited.Add(current);

            return current.ConnectedVertices.Any(neighbour => DfsSearch(neighbour, target, visited)); //Who even needs python anymore?
        }

        public void RemoveVertices(List<Vertex<T>> verticesToRemove)
        {
            foreach (var vertex in verticesToRemove)
            {
                vertex.Remove();
                _vertices.Remove(vertex);
            }
        }
    }
}
