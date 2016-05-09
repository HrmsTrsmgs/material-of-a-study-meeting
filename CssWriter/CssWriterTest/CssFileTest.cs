using CssWriter;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework.Constraints;
using CssWriter.Helpers;
using System.IO;

namespace CssWriterTest
{
    [TestFixture]
    public class CssFileTest : AssertionHelper
    {
        [SetUp]
        public void SetUp()
        {

            if(File.Exists(@"C:\File1.css"))
            {
                File.Delete(@"C:\File1.css");
            }
        }

        [Test]
        public void 指定したPathがプロパティとして取得できます()
        {
            var tested = new CssFile(@"C:\File1.css");

            Expect(tested.Path, Is.EqualTo(@"C:\File1.css"));

            var tested2 = new CssFile(@"C:\File2.css");

            Expect(tested2.Path, Is.EqualTo(@"C:\File2.css"));
        }

        [Test]
        public void 指定したStatementsがプロパティとして取得できます()
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
