namespace IdotF
{
    public sealed class EndIf
    {
        public bool MatchedCase { get; } = true;
        internal static EndIf Instance { get; } = new EndIf();
        internal EndIf()
        {
            
        }
    }
}
