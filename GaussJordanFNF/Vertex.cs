using GaussJordanFNF.operations;

namespace FoataNormalForm
{
    internal class Vertex
    {
        public int Id { get; }
        public IOperation Data { get; }
        private readonly List<Vertex> _connectedVertices;
        private readonly List<Vertex> _incomingVertices;

        public List<Vertex> ConnectedVertices => [.._connectedVertices];
        public List<Vertex> IncomingVertices => [.._incomingVertices];

        public Vertex(int id, IOperation data)
        {
            Id = id;
            Data = data;
            _connectedVertices = [];
            _incomingVertices = [];
        }

        public void ConnectVertex(Vertex vertex)
        {
            _connectedVertices.Add(vertex);
            vertex._incomingVertices.Add(this);
        }

        public void Remove()
        {
            foreach (var vertex in ConnectedVertices)
            {
                vertex._incomingVertices.Remove(this);
            }
        }
    }
}
