using System;
using System.Collections.Generic;
using System.Linq;

namespace IdotF
{
    public sealed class DeferredIf<T>
    {
        private readonly List<Case<T>> cases;

        public DeferredIf(bool condition, Func<T> func)
        {
            cases = new List<Case<T>>();
            if (condition) cases.Add(new Case<T>(func));
        }

        public DeferredIf(Func<bool> condition, Func<T> func)
        {
            cases = new List<Case<T>> { new Case<T>(condition, func) };
        }

        internal DeferredIf(IEnumerable<Case<T>> cases, Case<T> nextCase)
        {
            this.cases = cases.ToList();
            this.cases.Add(nextCase);
        }

        internal DeferredIf(IEnumerable<Case<T>> cases)
        {
            this.cases = cases.ToList();
        }


        public DeferredIf<T> ElseIf(bool condition, Func<T> func)
        {
            return 
                condition ?
                    new DeferredIf<T>(cases, new Case<T>(func)) :
                    new DeferredIf<T>(cases);
        }

        public DeferredIf<T> ElseIf(Func<bool> condition, Func<T> func)
        {
            return new DeferredIf<T>(cases, new Case<T>(condition, func));
        }

        public DeferredIf<T> ElseIf(bool condition, T result)
        {
            return
                condition ?
                    new DeferredIf<T>(cases, new Case<T>(result)) :
                    new DeferredIf<T>(cases);
        }

        public DeferredIf<T> ElseIf(Func<bool> condition, T result)
        {
            return new DeferredIf<T>(cases, new Case<T>(condition, result));
        }

        public DeferredEndIf<T> Else(Func<T> func)
        {
            return new DeferredEndIf<T>(cases, new Case<T>(func));
        }

        public DeferredEndIf<T> Else(T result)
        {
            return new DeferredEndIf<T>(cases, new Case<T>(result));
        }

        public DeferredIfResult<T> Execute()
        {
            return Execute(cases);
        }

        internal static DeferredIfResult<T> Execute(IEnumerable<Case<T>> cases)
        {
            foreach (var item in cases)
            {
                if (item.Condition == null || item.Condition())
                {
                    return new DeferredIfResult<T>(item.GetResult());
                }
            }
            return DeferredIfResult<T>.NotMatchedInstance;
        }
    }
}
