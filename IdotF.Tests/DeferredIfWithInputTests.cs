using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdotF.Tests
{
    [TestFixture]
    public class DeferredIfWithInputTests
    {
        [Test]
        public void TestFunc([Range(0, 8)] int trueCase)
        {
            var testBase =
                trueCase == 0 ?
                    I.FDeferred(() => trueCase == 0, (int x) => x) :
                    I.FDeferred(trueCase == 1, (int x) => x);

            testBase = testBase
               .ElseIf(trueCase == 2, 2)
               .ElseIf(trueCase == 3, (int x) => x)
               .ElseIf(() => trueCase == 4, 4)
               .ElseIf(() => trueCase == 5, (int x) => x)
               ;

            DeferredIfResult<int> r = null;
            if (trueCase == 7 || trueCase == 4)
                r = testBase
                    .Else(7)
                    .Execute(trueCase);
            else if (trueCase != 8)
                r = testBase
                    .Else((int x) => trueCase)
                    .Execute(trueCase);
            else
                r = testBase
                    .Execute(trueCase);

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
        public void TestAction([Range(0, 5)] int trueCase)
        {
            int runCase = -1;
            int input = -1;

            var testBase =
                trueCase == 0 ?
                I.FDeferred(() => trueCase == 0, (int x) => { runCase = trueCase; input = x; }) :
                I.FDeferred(trueCase == 1, (int x) => { runCase = trueCase; input = x; });

            testBase = testBase
               .ElseIf(trueCase == 2, (int x) => { runCase = trueCase; input = x; })
               .ElseIf(() => trueCase == 3, (int x) => { runCase = trueCase; input = x; });

            var r =
                trueCase == 3 || trueCase == 5?
                testBase.Execute(trueCase) :
                testBase.Else((int x) => { runCase = 4; input = x; })
                .Execute(trueCase);


            if (r.MatchedCase)
            {
                Assert.IsTrue(input == trueCase);
                Assert.IsTrue(trueCase == runCase);
            }
            else
                Assert.IsTrue(trueCase == 5);
        }

        [Test]
        public void TestExtensionFunc([Range(0, 1)] int trueCase)
        {
            Func<bool> init = () => trueCase == 0;

            var r =
                (trueCase == 0 ?
                    init.DeferredIf((int x) => x) :
                    (trueCase == 1).DeferredIf((int x) => x))
                .Execute(trueCase);

            Assert.IsTrue(r.MatchedCase);
            Assert.IsTrue(r.Result == trueCase);
        }

        [Test]
        public void TestExtensionAction([Range(0, 1)] int trueCase)
        {
            int runCase = 0;

            Func<bool> init = () => trueCase == 0;

            var r =
                (trueCase == 0 ?
                init.DeferredIf((int x) => { runCase = 0; }) :
                (trueCase == 1).DeferredIf((int x) => { runCase = 1; }))
                .Execute(45);

            Assert.IsTrue(r.MatchedCase);
            Assert.IsTrue(runCase == trueCase);
        }
    }
}
