using System;

namespace IdotF
{
    public sealed class If
    {
        public bool MatchedCase { get; }

        public If(bool condition, Action action)
        {
            MatchedCase = condition;
            if (condition) action();
        }

        public If(Func<bool> condition, Action action)
            : this(condition(), action)
        {
        }

        internal If(bool matchedCase = true)
        {
            MatchedCase = matchedCase;
        }


        public If ElseIf(bool condition, Action action)
        {
            if (MatchedCase)
                return new If();
            else
            {
                action();
                return new If(condition);
            }
        }

        public If ElseIf(Func<bool> condition, Action action)
        {
            return ElseIf(condition(), action);
        }


        public EndIf Else(Action action)
        {
            if (!MatchedCase)
                action();

            return EndIf.Instance;
        }
    }
}
