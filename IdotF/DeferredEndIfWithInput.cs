using System.Collections.Generic;
using System.Linq;

namespace IdotF
{
    public sealed class DeferredEndIfWithInput<Tin>
    {
        private readonly List<CaseWithInput<Tin>> cases;

        internal DeferredEndIfWithInput(IEnumerable<CaseWithInput<Tin>> cases, CaseWithInput<Tin> nextCase)
        {
            this.cases = cases.ToList();
            this.cases.Add(nextCase);
        }

        public DeferredIfResult Execute(Tin input)
        {
            return DeferredIfWithInput<Tin>.Execute(input, cases);
        }
    }
}
