using System;

namespace IdotF
{
    internal class CaseWithInput<Tin, Tout>
    {
        public Func<bool> Condition { get; }
        private Func<Tin, Tout> Func { get; }
        private Tout Result { get; }

        public CaseWithInput(Func<bool> condition, Func<Tin, Tout> func)
        {
            Condition = condition;
            Func = func;
        }

        public CaseWithInput(Func<bool> condition, Tout result)
        {
            Condition = condition;
            Result = result;
        }

        public CaseWithInput(Func<Tin, Tout> func)
        {
            Func = func;
        }
        public CaseWithInput(Tout result)
        {
            Result = result;
        }

        public Tout GetResult(Tin input)
        {
            return Func == null ? Result : Func(input);
        }
    }
}
