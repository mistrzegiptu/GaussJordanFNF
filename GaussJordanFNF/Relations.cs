namespace GaussJordanFNF
{
    internal class Relations<T> where T: IRelatable
    {
        private readonly List<T> _operations;
        public HashSet<(T, T)> DependentOperations { get; private set; } = [];

        public Relations(List<T> operations)
        {
            _operations = operations ?? throw new ArgumentException(nameof(Relations<T>));
            BuildRelations();
        }

        private void BuildRelations()
        {
            DependentOperations = [];

            BuildbasicRelations();
            BuildReflexiveRelations();
            BuildTransitiveRelations();
            BuildSymmetricRelations();
        }
        
        private void BuildbasicRelations()
        {
            for (int i = 0; i < _operations.Count; i++)
            {
                for (int j = i + 1; j < _operations.Count; j++)
                {
                    if (_operations[i].IsDependent(_operations[j]))
                    {
                        DependentOperations.Add((_operations[i], _operations[j]));
                    }
                }
            }
        }

        private void BuildReflexiveRelations()
        {
            foreach (var operation in _operations)
                DependentOperations.Add((operation, operation));
        }

        private void BuildTransitiveRelations()
        {
            foreach(var operation in _operations)
            {
                foreach(var leftOperation in DependentOperations.Where(o => o.Item1.Equals(operation)))
                {
                    foreach (var rightOperation in DependentOperations.Where(o => o.Item1.Equals(leftOperation.Item1)))
                    {
                        DependentOperations.Add((leftOperation.Item1, rightOperation.Item2));
                    }
                }

            }
        }

        private void BuildSymmetricRelations()
        {
            var toAdd = new HashSet<(T, T)>();

            foreach(var operation in DependentOperations)
                toAdd.Add((operation.Item2, operation.Item1));

            DependentOperations.UnionWith(toAdd);
        }
    }
}
