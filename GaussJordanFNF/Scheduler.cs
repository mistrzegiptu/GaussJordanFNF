using GaussJordanFNF.operations;

namespace GaussJordanFNF
{
    internal class Scheduler
    {
        private readonly List<HashSet<IRelatable>> _operationsFoata;
        public Scheduler(List<HashSet<IRelatable>> operationsFoata)
        {
            _operationsFoata = operationsFoata ?? throw new ArgumentException(nameof(Scheduler));
        }

        public void ExecuteAll(EquationMatrix matrix)
        {
            foreach(var parallelOperations in _operationsFoata)
            {
                var tasks = new List<Task>();

                foreach (var item in parallelOperations.Cast<IOperation>())
                {
                    tasks.Add(Task.Run(() => item.Execute(matrix)));
                }

                try
                {
                    Task.WaitAll([.. tasks]);
                }
                catch (AggregateException ae)
                { 
                    throw new InvalidOperationException("Task failed", ae.Flatten());
                }
            }
        }
    }
}
