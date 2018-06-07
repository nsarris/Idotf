using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdotF.Tests
{
    [TestFixture]
    public class IfTests
    {

        [Test]
        public void TestFunc([Range(0, 8)] int trueCase)
        {
            var testBase =
                trueCase == 0 ?
                    I.F(() => trueCase == 0, () => 0) :
                    I.F(trueCase == 1, () => 1);

            testBase = testBase
               .ElseIf(trueCase == 2, 2)
               .ElseIf(trueCase == 3, () => 3)
               .ElseIf(() => trueCase == 4, 4)
               .ElseIf(() => trueCase == 5, () => 5)
               ;

            EndIf<int> r;
            if (trueCase == 7 || trueCase == 4)
                r = testBase
                    .Else(7);
            else if (trueCase == 8)
                r = testBase;
            else
                r = testBase
                    .Else(() => 6);
            


            if (trueCase == 8)
            {
                Assert.IsFalse(r.MatchedCase);
                new int[] { 0 }.Contains(r);
            }
            else
            {
                Assert.IsTrue(r.MatchedCase);
                Assert.IsTrue(r.Result == trueCase);
            }
        }

        [Test]
        public void TestAction([Range(0, 4)] int trueCase)
        {
            int runCase = 0;

            var testBase =
                trueCase == 0 ?
                I.F(() => trueCase == 0, () => { runCase = 0; }) :
                I.F(trueCase == 1, () => { runCase = 1; });

            var r = testBase
               .ElseIf(trueCase == 2, () => { runCase = 2; })
               .ElseIf(() => trueCase == 3, () => { runCase = 3; })
               .Else(() => { runCase = 4; });

            Assert.IsTrue(r.MatchedCase);
            Assert.IsTrue(trueCase == runCase);
        }

        [Test]
        public void TestExtensionFunc([Range(0, 1)] int trueCase)
        {
            Func<bool> init = () => trueCase == 0;

            var r =
                trueCase == 0 ?
                    init.If(() => 0) :
                    (trueCase == 1).If(() => 1);

            Assert.IsTrue(r.MatchedCase);
            Assert.IsTrue(r.Result == trueCase);
        }

        [Test]
        public void TestExtensionAction([Range(0, 1)] int trueCase)
        {
            int runCase = 0;

            Func<bool> init = () => trueCase == 0;

            var r =
                trueCase == 0 ?
                init.If(() => { runCase = 0; }) :
                (trueCase == 1).If(() => { runCase = 1; });

            Assert.IsTrue(r.MatchedCase);
            Assert.IsTrue(trueCase == runCase); 
        }
    }
}
