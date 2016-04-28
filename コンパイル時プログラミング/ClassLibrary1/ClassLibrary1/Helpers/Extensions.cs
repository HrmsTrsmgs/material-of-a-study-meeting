using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Helpers
{
    public static class CssHelperExtensionMethods
    {
        public static CssStatement Css(this string self, params Expression<Func<string, string>>[] declarations)
        {
            return new CssStatement
            {
                Selectors = new[] { self },
                Declarations = ToDictionary(declarations)
            }; ;
        }

        private static Dictionary<string, string> ToDictionary(Expression<Func<string, string>>[] declarations)
            => declarations.ToDictionary(
                declaration => GetProperty(declaration),
                declaration => GetValue(declaration));

        private static string GetValue(Expression<Func<string, string>> declaration)
            => declaration.Compile().Invoke("");

        private static string GetProperty(Expression<Func<string, string>> declaration)
            => declaration.Parameters.Single().Name.Replace('_', '-');

        public static CssStatement Css(this string[] self, params Expression<Func<string, string>>[] declarations)
        {
            
            return new CssStatement
            {
                Selectors = self,
                Declarations = ToDictionary(declarations)
            };
        }
    }
}
