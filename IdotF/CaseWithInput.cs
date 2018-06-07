using System;

namespace IdotF
{
    internal class CaseWithInput<Tin>
    {
        public Func<bool> Condition { get; }
        public Action<Tin> Action { get; }
        public CaseWithInput(Func<bool> condition, Action<Tin> action)
        {
            Condition = condition;
            Action = action;
        }
        public CaseWithInput(Action<Tin> action)
        {
            Action = action;
        }
    }
}
