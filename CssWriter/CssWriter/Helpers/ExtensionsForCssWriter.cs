using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CssWriter.Helpers
{
    public static class ExtensionsForCssWriter
    {
        public static CssStatement Css(this string selector, params Func<string, string>[] decdeclarations)
        {
            var ret = new CssStatement();

            ret.Selectors = new[] { "H1" };

            ret.Declarations = new Dictionary<string, string> {
                {"font-size", "12pt" },
                {"line-height", "10pt" }
            };

            return ret;
        }
    }
}
