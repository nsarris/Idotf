using System;

namespace IdotF
{
    public static class IdotFExtensions
    {
        public static If If(this bool condition, Action action)
        {
            return new If(condition, action);
        }

        public static If<T> If<T>(this bool condition, Func<T> func)
        {
            return new If<T>(condition, func);
        }

        public static If If(this Func<bool> condition, Action action)
        {
            return new If(condition, action);
        }

        public static If<T> If<T>(this Func<bool> condition, Func<T> func)
        {
            return new If<T>(condition, func);
        }

        public static DeferredIf DeferredIf(this bool condition, Action action)
        {
            return new DeferredIf(condition, action);
        }

        public static DeferredIf<T> DeferredIf<T>(this bool condition, Func<T> func)
        {
            return new DeferredIf<T>(condition, func);
        }

        public static DeferredIf DeferredIf(this Func<bool> condition, Action action)
        {
            return new DeferredIf(condition, action);
        }

        public static DeferredIf<T> DeferredIf<T>(this Func<bool> condition, Func<T> func)
        {
            return new DeferredIf<T>(condition, func);
        }

        public static DeferredIfWithInput<Tin> DeferredIf<Tin>(this bool condition, Action<Tin> action)
        {
            return new DeferredIfWithInput<Tin>(condition, action);
        }

        public static DeferredIfWithInput<Tin, Tout> DeferredIf<Tin,Tout>(this bool condition, Func<Tin,Tout> func)
        {
            return new DeferredIfWithInput<Tin, Tout>(condition, func);
        }

        public static DeferredIfWithInput<Tin> DeferredIf<Tin>(this Func<bool> condition, Action<Tin> action)
        {
            return new DeferredIfWithInput<Tin>(condition, action);
        }

        public static DeferredIfWithInput<Tin, Tout> DeferredIf<Tin, Tout>(this Func<bool> condition, Func<Tin,Tout> func)
        {
            return new DeferredIfWithInput<Tin, Tout>(condition, func);
        }
    }
}
