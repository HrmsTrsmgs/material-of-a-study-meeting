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
                Declarations = declarations.ToDictionary(
                    declaration => GetParameterName(declaration),
                    declaration => GetValue(declaration))
            };
        }

        private static string GetParameterName(Expression<Func<string, string>> declaration)
            => declaration.Parameters.Single().Name.Replace('_', '-');

        private static string GetValue(Expression<Func<string, string>> declaration)
            => declaration.Compile().Invoke("");
    }
}
