using System;
using System.Collections.Generic;
using System.Linq;

namespace IdotF
{
    public sealed class DeferredIfWithInput<Tin>
    {
        private readonly List<CaseWithInput<Tin>> cases;

        public DeferredIfWithInput(bool condition, Action<Tin> action)
        {
            cases = new List<CaseWithInput<Tin>>();
            if (condition) cases.Add(new CaseWithInput<Tin>(action));
        }

        public DeferredIfWithInput(Func<bool> condition, Action<Tin> action)
        {
            cases = new List<CaseWithInput<Tin>> { new CaseWithInput<Tin>(condition, action) };
        }

        internal DeferredIfWithInput(IEnumerable<CaseWithInput<Tin>> cases, CaseWithInput<Tin> nextCase)
        {
            this.cases = cases.ToList();
            this.cases.Add(nextCase);
        }

        internal DeferredIfWithInput(IEnumerable<CaseWithInput<Tin>> cases)
        {
            this.cases = cases.ToList();
        }


        public DeferredIfWithInput<Tin> ElseIf(bool condition, Action<Tin> action)
        {
            return 
                condition ?
                    new DeferredIfWithInput<Tin>(cases, new CaseWithInput<Tin>(action)) :
                    new DeferredIfWithInput<Tin>(cases);
        }

        public DeferredIfWithInput<Tin> ElseIf(Func<bool> condition, Action<Tin> action)
        {
            return new DeferredIfWithInput<Tin>(cases, new CaseWithInput<Tin>(condition, action));
        }


        public DeferredEndIfWithInput<Tin> Else(Action<Tin> action)
        {
            return new DeferredEndIfWithInput<Tin>(cases, new CaseWithInput<Tin>(action));
        }

        public DeferredIfResult Execute(Tin input)
        {
            return Execute(input, cases);
        }

        internal static DeferredIfResult Execute(Tin input, IEnumerable<CaseWithInput<Tin>> cases)
        {
            foreach (var item in cases)
            {
                if (item.Condition == null || item.Condition())
                {
                    item.Action(input);
                    return new DeferredIfResult(true);
                }
            }
            return new DeferredIfResult(false);
        }
    }
}
