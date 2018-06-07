using System.Collections.Generic;
using System.Linq;

namespace IdotF
{
    public sealed class DeferredEndIfWithInput<Tin, Tout>
    {
        private readonly List<CaseWithInput<Tin, Tout>> cases;

        internal DeferredEndIfWithInput(IEnumerable<CaseWithInput<Tin, Tout>> cases, CaseWithInput<Tin, Tout> nextCase)
        {
            this.cases = cases.ToList();
            this.cases.Add(nextCase);
        }

        public DeferredIfResult<Tout> Execute(Tin input)
        {
            return DeferredIfWithInput<Tin,Tout>.Execute(input, cases);
        }
    }
}
