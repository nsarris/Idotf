using System;

namespace IdotF
{
    internal class Case
    {
        public Func<bool> Condition { get; }
        public Action Action { get; }
        public Case(Func<bool> condition, Action action)
        {
            Condition = condition;
            Action = action;
        }
        public Case(Action action)
        {
            Action = action;
        }
    }
}
