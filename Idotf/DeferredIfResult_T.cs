
namespace IdotF
{
    public sealed class DeferredIfResult<T>
    {
        internal static DeferredIfResult<T> NotMatchedInstance { get; } = new DeferredIfResult<T>();
        public T Result { get; }
        public bool MatchedCase { get; }
        internal DeferredIfResult()
        {
        }

        internal DeferredIfResult(T result)
        {
            MatchedCase = true;
            Result = result;
        }

        public static implicit operator T(DeferredIfResult<T> instance)
        {
            return instance.Result;
        }
    }
}