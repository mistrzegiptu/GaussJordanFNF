using GaussJordanFNF.operations;
using System;
using System.Collections.Generic;
using System.Text;

namespace GaussJordanFNF
{
    internal class Scheduler
    {
        private Queue<HashSet<IOperation>> operationsQueue;
        public Scheduler()
        {
            operationsQueue = new Queue<HashSet<IOperation>>();
        }
        public void EnqueueOperation(HashSet<IOperation> parallelOperations)
        {
            operationsQueue.Enqueue(parallelOperations);
        }
        public void ExecuteAll(EquationMatrix matrix)
        {
            while (operationsQueue.Count > 0)
            {
                var operations = operationsQueue.Dequeue();
                var tasks = new List<Task>();

                foreach (var item in operations)
                {
                    tasks.Add(Task.Run(() => item.Execute(matrix)));
                }

                //Parallel.ForEach(operations, operation =>
                //{
                //    operation.Execute(matrix);
                //});

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
