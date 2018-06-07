using System.Collections.Generic;
using System.Linq;

namespace IdotF
{
    public sealed class DeferredEndIf
    {
        private readonly List<Case> cases;

        internal DeferredEndIf(IEnumerable<Case> cases, Case nextCase)
        {
            this.cases = cases.ToList();
            this.cases.Add(nextCase);
        }

        public DeferredIfResult Execute()
        {
            return DeferredIf.Execute(cases);
        }
    }
}
