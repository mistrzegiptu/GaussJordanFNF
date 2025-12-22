using GaussJordanFNF.operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoataNormalForm
{
    internal class FoataNormalForm
    {
        private readonly string _wordLabel = "w";
        public List<HashSet<IOperation>> _form = [];

        public void AddGroup(HashSet<IOperation> group)
        {
            _form.Add(group);
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append($"FNF([{_wordLabel}])=");

            foreach (var group in _form)
            {
                sb.Append('[');
                foreach (var label in group)
                {
                    sb.Append(label);
                }

                sb.Append(']');
            }

            return sb.ToString();
        }
    }
}
