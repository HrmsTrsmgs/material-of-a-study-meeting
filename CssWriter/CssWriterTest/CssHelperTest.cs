using CssWriter.Helpers;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CssWriterTest
{
    [TestFixture]
    public class CssHelperTest : AssertionHelper
    {
        [Test]
        public void ヘルパーを使ってCssが組み立てられます()
        {
            var tested =
                "H1".Css(
                    font_size => "12pt",
                    line_height => "10pt");

            Expect(tested.ToString(), Is.EqualTo(
@"H1 {
    font-size: 12pt;
    line-height: 10pt
}"));
        }

        [Test]
        public void Helperを使ったCssの組み立てではセレクターの種類を反映します()
        {
            var tested =
                "H2".Css(
                    font_size => "12pt",
                    line_height => "10pt");

            Expect(tested.ToString(), Is.EqualTo(
@"H2 {
    font-size: 12pt;
    line-height: 10pt
}"));
        }

        [Test]
        public void Helperを使ったCssの組み立てでは複数のセレクターが指定できます()
        {
            var tested =
                new[] { "H1", "H2" }.Css(
                    font_size => "12pt",
                    line_height => "10pt");

            Expect(tested.ToString(), Is.EqualTo(
@"H1, H2 {
    font-size: 12pt;
    line-height: 10pt
}"));
        }

        [Test]
        public void Helperを使ったCssの組み立てでは複数のセレクターを反映します()
        {
            var tested =
                new[] { "H2", "H3" }.Css(
                    font_size => "12pt",
                    line_height => "10pt");

            Expect(tested.ToString(), Is.EqualTo(
@"H2, H3 {
    font-size: 12pt;
    line-height: 10pt
}"));
        }

        [Test]
        public void Helperを使ったCssの組み立てでは特性を反映します()
        {
            var tested =
                "H2".Css(
                    line_height => "12pt",
                    font_size => "10pt");

            Expect(tested.ToString(), Is.EqualTo(
@"H2 {
    line-height: 12pt;
    font-size: 10pt
}"));
        }
    }
}
