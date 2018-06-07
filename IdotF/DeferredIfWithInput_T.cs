using System;
using System.Collections.Generic;
using System.Linq;

namespace IdotF
{
    public sealed class DeferredIfWithInput<Tin, Tout>
    {
        private readonly List<CaseWithInput<Tin, Tout>> cases;

        public DeferredIfWithInput(bool condition, Func<Tin, Tout> func)
        {
            cases = new List<CaseWithInput<Tin, Tout>>();
            if (condition) cases.Add(new CaseWithInput<Tin, Tout>(func));
        }

        public DeferredIfWithInput(Func<bool> condition, Func<Tin, Tout> func)
        {
            cases = new List<CaseWithInput<Tin, Tout>> { new CaseWithInput<Tin, Tout>(condition, func) };
        }

        internal DeferredIfWithInput(IEnumerable<CaseWithInput<Tin, Tout>> cases, CaseWithInput<Tin, Tout> nextCase)
        {
            this.cases = cases.ToList();
            this.cases.Add(nextCase);
        }

        internal DeferredIfWithInput(IEnumerable<CaseWithInput<Tin, Tout>> cases)
        {
            this.cases = cases.ToList();
        }


        public DeferredIfWithInput<Tin, Tout> ElseIf(bool condition, Func<Tin, Tout> func)
        {
            return
                condition ?
                    new DeferredIfWithInput<Tin, Tout>(cases, new CaseWithInput<Tin, Tout>(func)) :
                    new DeferredIfWithInput<Tin, Tout>(cases);
        }

        public DeferredIfWithInput<Tin, Tout> ElseIf(Func<bool> condition, Func<Tin, Tout> func)
        {
            return new DeferredIfWithInput<Tin, Tout>(cases, new CaseWithInput<Tin, Tout>(condition, func));
        }

        public DeferredIfWithInput<Tin, Tout> ElseIf(bool condition, Tout result)
        {
            return
                condition ?
                    new DeferredIfWithInput<Tin, Tout>(cases, new CaseWithInput<Tin, Tout>(result)) :
                    new DeferredIfWithInput<Tin, Tout>(cases);
        }

        public DeferredIfWithInput<Tin, Tout> ElseIf(Func<bool> condition, Tout result)
        {
            return new DeferredIfWithInput<Tin, Tout>(cases, new CaseWithInput<Tin, Tout>(condition, result));
        }

        public DeferredEndIfWithInput<Tin, Tout> Else(Func<Tin, Tout> func)
        {
            return new DeferredEndIfWithInput<Tin, Tout>(cases, new CaseWithInput<Tin, Tout>(func));
        }

        public DeferredEndIfWithInput<Tin, Tout> Else(Tout result)
        {
            return new DeferredEndIfWithInput<Tin, Tout>(cases, new CaseWithInput<Tin, Tout>(result));
        }

        public DeferredIfResult<Tout> Execute(Tin input)
        {
            return Execute(input, cases);
        }

        internal static DeferredIfResult<Tout> Execute(Tin input, IEnumerable<CaseWithInput<Tin, Tout>> cases)
        {
            foreach (var item in cases)
            {
                if (item.Condition == null || item.Condition())
                {
                    return new DeferredIfResult<Tout>(item.GetResult(input));
                }
            }
            return DeferredIfResult<Tout>.NotMatchedInstance;
        }
    }
}
