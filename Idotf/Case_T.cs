using System;

namespace IdotF
{
    internal class Case<T>
    {
        public Func<bool> Condition { get; }
        private Func<T> Func { get; }
        private T Result { get; }

        

        public Case(Func<bool> condition, Func<T> func)
        {
            Condition = condition;
            Func = func;
        }

        public Case(Func<bool> condition, T result)
        {
            Condition = condition;
            Result = result;
        }

        public Case(Func<T> func)
        {
            Func = func;
        }
        public Case(T result)
        {
            Result = result;
        }

        public T GetResult()
        {
            return Func == null ? Result : Func();
        }
    }
}
