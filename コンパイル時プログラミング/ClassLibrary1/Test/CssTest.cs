using ClassLibrary1;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
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
        public void ToStringでセレクタの種類を見分けて表示できます()
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
        public void ToStringで複数のセレクタに対応できます()
        {
            var tested = new CssStatement();

            tested.Selectors = new[] { "H1", "H2" };

            tested.Declarations = new Dictionary<string, string> { { "font-size", "12pt" } };

            Expect(tested.ToString(), Is.EqualTo(
@"H1, H2 {
    font-size: 12pt
}"));
        }

        public void ToStringでプロパティの内容を見て表示します()
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
        public void ToStringで値の内容を見て表示します()
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
        public void ToStringで複数の特性に対応できます()
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
