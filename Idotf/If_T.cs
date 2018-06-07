using System;

namespace IdotF
{
    public class If<T> : EndIf<T>
    {
        internal If(bool condition, T result)
            :base(condition, condition ? result : default)
        {
            
        }

        internal If(T result)
            :base(result)
        {
            
        }

        public If(bool condition, Func<T> func)
            :base(condition, condition ? func() : default)
        {
            
        }

        public If(Func<bool> condition, Func<T> func)
            : this(condition(), func)
        {

        }

        public If<T> ElseIf(bool condition, Func<T> func)
        {
            return MatchedCase ?
                new If<T>(Result) :
                new If<T>(condition, func);
        }

        public If<T> ElseIf(Func<bool> condition, Func<T> func)
        {
            return ElseIf(condition(), func);
        }

        public If<T> ElseIf(bool condition, T result)
        {
            return MatchedCase ?
                new If<T>(Result) :
                new If<T>(condition, result);
        }

        public If<T> ElseIf(Func<bool> condition, T result)
        {
            return ElseIf(condition(), result);
        }

        public EndIf<T> Else(Func<T> func)
        {
            return MatchedCase ?
                new EndIf<T>(Result) :
                new EndIf<T>(func());
        }

        public EndIf<T> Else(T result)
        {
            return MatchedCase ?
                new EndIf<T>(Result) :
                new EndIf<T>(result);
        }
    }
}
