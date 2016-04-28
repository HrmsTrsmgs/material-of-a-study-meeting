using CssWriter;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CssWriterTest
{
    [TestFixture]
    public class CssTest : AssertionHelper
    {


        [Test]
        public void ToStringで基本的なCSSの出力ができます()
        {
            var tested = new CssStatement();

            tested.Selectors = new[] { "H1" };

            tested.Declarations = new Dictionary<string, string> { { "font-size", "12pt" } };

            Expect(tested.ToString(), Is.EqualTo(
@"H1 {
    font-size: 12pt
}"));
        }
    }
}
