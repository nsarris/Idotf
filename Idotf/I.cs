using System;

namespace IdotF
{
    public static class I
    {
        public static If F(bool condition, Action action)
        {
            return new If(condition, action);
        }

        public static If F(Func<bool> condition, Action action)
        {
            return new If(condition, action);
        }

        public static If<T> F<T>(bool condition, Func<T> func)
        {
            return new If<T>(condition, func);
        }

        public static If<T> F<T>(Func<bool> condition, Func<T> func)
        {
            return new If<T>(condition, func);
        }


        public static DeferredIf FDeferred(bool condition, Action action)
        {
            return new DeferredIf(condition, action);
        }

        public static DeferredIf FDeferred(Func<bool> condition, Action action)
        {
            return new DeferredIf(condition, action);
        }

        public static DeferredIf<T> FDeferred<T>(bool condition, Func<T> func)
        {
            return new DeferredIf<T>(condition, func);
        }

        public static DeferredIf<T> FDeferred<T>(Func<bool> condition, Func<T> func)
        {
            return new DeferredIf<T>(condition, func);
        }
    }
}
