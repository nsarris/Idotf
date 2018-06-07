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

        public static DeferredIfWithInput<Tin> FDeferred<Tin>(bool condition, Action<Tin> action)
        {
            return new DeferredIfWithInput<Tin>(condition, action);
        }

        public static DeferredIfWithInput<Tin> FDeferred<Tin>(Func<bool> condition, Action<Tin> action)
        {
            return new DeferredIfWithInput<Tin>(condition, action);
        }

        public static DeferredIfWithInput<Tin, Tout> FDeferred<Tin,Tout>(bool condition, Func<Tin, Tout> action)
        {
            return new DeferredIfWithInput<Tin, Tout>(condition, action);
        }

        public static DeferredIfWithInput<Tin, Tout> FDeferred<Tin, Tout>(Func<bool> condition, Func<Tin, Tout> action)
        {
            return new DeferredIfWithInput<Tin, Tout>(condition, action);
        }
    }
}
