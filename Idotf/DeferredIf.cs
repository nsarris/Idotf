using System;
using System.Collections.Generic;
using System.Linq;

namespace IdotF
{
    public sealed class DeferredIf
    {
        private readonly List<Case> cases;

        public DeferredIf(bool condition, Action action)
        {
            cases = new List<Case>();
            if (condition) cases.Add(new Case(action));
        }

        public DeferredIf(Func<bool> condition, Action action)
        {
            cases = new List<Case> { new Case(condition, action) };
        }

        internal DeferredIf(IEnumerable<Case> cases, Case nextCase)
        {
            this.cases = cases.ToList();
            this.cases.Add(nextCase);
        }

        internal DeferredIf(IEnumerable<Case> cases)
        {
            this.cases = cases.ToList();
        }


        public DeferredIf ElseIf(bool condition, Action action)
        {
            return 
                condition ?
                    new DeferredIf(cases, new Case(action)) :
                    new DeferredIf(cases);
        }

        public DeferredIf ElseIf(Func<bool> condition, Action action)
        {
            return new DeferredIf(cases, new Case(condition, action));
        }


        public DeferredEndIf Else(Action action)
        {
            return new DeferredEndIf(cases, new Case(action));
        }

        public DeferredIfResult Execute()
        {
            return Execute(cases);
        }

        internal static DeferredIfResult Execute(IEnumerable<Case> cases)
        {
            foreach (var item in cases)
            {
                if (item.Condition == null || item.Condition())
                {
                    item.Action();
                    return new DeferredIfResult(true);
                }
            }
            return new DeferredIfResult(false);
        }
    }
}
