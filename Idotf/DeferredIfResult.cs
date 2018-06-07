using System;
using System.Collections.Generic;
using System.Text;

namespace IdotF
{
    public sealed class DeferredIfResult
    {
        public bool MatchedCase { get; }
        internal DeferredIfResult(bool matchedCase)
        {
            MatchedCase = matchedCase;
        }
    }

}
