using ClassLibrary1;
using ClassLibrary1.Helpers;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    [TestFixture]
    public class CssFileTest : AssertionHelper
    {
        [Test]
        public void 指定したPathがプロパティとして取得できます()
        {
            var filePath = @"C:\File1.css";
            var tested = new CssFile(filePath);

            Expect(tested.Path, Is.EqualTo(filePath));
        }

        [Test]
        public void Statementsが設定できます()
        {
            var statements = new[] { new CssStatement() };
            var tested = new CssFile(@"C:\File1.css");

            tested.Statements = statements;

            Expect(tested.Statements, Is.SameAs(statements));
        }

        [Test]
        public void SaveでCssの保存ができます()
        {
            var tested = new CssFile(@"C:\File1.css",
                new[] { "H1", "H2" }.Css(
                    font_size => "12pt",
                    line_height => "10pt"));

            tested.Save();

            Expect(File.ReadAllText(@"C:\File1.css"), Is.EqualTo(
@"H1, H2 {
    font-size: 12pt;
    line-height: 10pt
}"));
        }
    }
}
