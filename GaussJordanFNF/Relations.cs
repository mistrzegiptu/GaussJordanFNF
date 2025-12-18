using GaussJordanFNF.operations;
using System;
using System.Collections.Generic;
using System.Text;

namespace GaussJordanFNF
{
    internal class Relations
    {
        private readonly List<IOperation> _operations;
        public List<(IOperation, IOperation)> DependentOperations { get; private set; }

        public Relations(List<IOperation> operations)
        {
            _operations = operations;
            BuildRelations();
        }

        public void BuildRelations()
        {
            DependentOperations = new List<(IOperation, IOperation)>();
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
    }
}
