using System.Collections.Generic;
using System.Linq;

namespace IdotF
{
    public sealed class DeferredEndIf<T>
    {
        private readonly List<Case<T>> cases;

        internal DeferredEndIf(IEnumerable<Case<T>> cases, Case<T> nextCase)
        {
            this.cases = cases.ToList();
            this.cases.Add(nextCase);
        }

        public DeferredIfResult<T> Execute()
        {
            return DeferredIf<T>.Execute(cases);
        }
    }
}
