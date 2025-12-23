using GaussJordanFNF;

namespace FoataNormalForm
{
    internal class Vertex <T> where T : IRelatable
    {
        public int Id { get; }
        public T Data { get; }
        private readonly List<Vertex<T>> _connectedVertices;
        private readonly List<Vertex<T>> _incomingVertices;

        public List<Vertex<T>> ConnectedVertices => [.._connectedVertices];
        public List<Vertex<T>> IncomingVertices => [.._incomingVertices];

        public Vertex(int id, T data)
        {
            Id = id;
            Data = data;
            _connectedVertices = [];
            _incomingVertices = [];
        }

        public void ConnectVertex(Vertex<T> vertex)
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
