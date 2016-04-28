using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CssWriter.Helpers
{
    public static class ExtensionsForCssWriter
    {
        public static CssStatement Css(this string selector, params Expression<Func<string, string>>[] declarations)
        {
            return Css(new[] { selector }, declarations);
        }

        public static CssStatement Css(this IEnumerable<string> selector, params Expression<Func<string, string>>[] declarations)
        {
            return new CssStatement
            {
                Selectors = selector.ToArray(),
                Declarations = new Dictionary<string, string> {
                    {declarations[0].Parameters.Single().Name.Replace('_', '-'), "12pt" },
                    {declarations[1].Parameters.Single().Name.Replace('_', '-'), "10pt" }
                }
            };
        }
    }
}
