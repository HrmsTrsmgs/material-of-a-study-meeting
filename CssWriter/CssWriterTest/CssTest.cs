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

        [Test]
        public void ToStringでセレクタの種類を見分けて出力に反映します()
        {
            var tested = new CssStatement();

            tested.Selectors = new[] { "H2" };

            tested.Declarations = new Dictionary<string, string> { { "font-size", "12pt" } };

            Expect(tested.ToString(), Is.EqualTo(
@"H2 {
    font-size: 12pt
}"));
        }

        [Test]
        public void ToStringで複数のセレクタを出力に反映します()
        {
            var tested = new CssStatement();

            tested.Selectors = new[] { "H1", "H2" };

            tested.Declarations = new Dictionary<string, string> { { "font-size", "12pt" } };

            Expect(tested.ToString(), Is.EqualTo(
@"H1, H2 {
    font-size: 12pt
}"));
        }

        [Test]
        public void ToStringでプロパティの種類を出力に反映します()
        {
            var tested = new CssStatement();

            tested.Selectors = new[] { "H1", "H2" };

            tested.Declarations = new Dictionary<string, string> { { "line-height", "12pt" } };

            Expect(tested.ToString(), Is.EqualTo(
@"H1, H2 {
    line-height: 12pt
}"));
        }

        [Test]
        public void ToStringで値を見て表出力に反映します()
        {
            var tested = new CssStatement();

            tested.Selectors = new[] { "H1", "H2" };

            tested.Declarations = new Dictionary<string, string> { { "line-height", "10pt" } };

            Expect(tested.ToString(), Is.EqualTo(
@"H1, H2 {
    line-height: 10pt
}"));
        }

        [Test]
        public void ToStringで複数の特性を出力に反映します()
        {
            var tested = new CssStatement();

            tested.Selectors = new[] { "H1", "H2" };

            tested.Declarations = new Dictionary<string, string> {
                {"font-size", "12pt" },
                {"line-height", "10pt" }
            };

            Expect(tested.ToString(), Is.EqualTo(
@"H1, H2 {
    font-size: 12pt;
    line-height: 10pt
}"));
        }
    }
}
