namespace IdotF
{
    public class EndIf<T>
    {
        public T Result { get; }
        public bool MatchedCase { get; }
        internal EndIf(bool matchedCase, T result)
        {
            MatchedCase = matchedCase;
            Result = result;
        }
        internal EndIf(T result)
        {
            MatchedCase = true;
            Result = result;
        }

        public static implicit operator T(EndIf<T> instance)
        {
            return instance.Result;
        }
    }
}
