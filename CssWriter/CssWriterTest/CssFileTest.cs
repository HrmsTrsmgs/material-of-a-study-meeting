using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CssWriterTest
{
    [TestFixture]
    public class CssFileTest : AssertionHelper
    {
        [Test]
        public void 指定したPathがプロパティとして取得できます()
        {
            var tested = new CssFile(@"C:\File1.css");

            Expect(tested.Path, Is.EqualTo(@"C:\File1.css"));
        }
    }
}
