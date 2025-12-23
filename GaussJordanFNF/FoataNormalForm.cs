using System.Text;

namespace GaussJordanFNF
{
    internal class FoataNormalForm<T> where T : IRelatable
    {
        private readonly string _wordLabel = "w";
        private List<HashSet<T>> _form = [];
        public List<HashSet<T>> Form
        {
            get { return [.. _form]; }
        }


        public void AddGroup(HashSet<T> group)
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
                    sb.Append(", ");
                }
                sb.Remove(sb.Length - 2, 2);

                sb.Append("]\n");
            }

            return sb.ToString();
        }
    }
}
