﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CssWriter.Helpers
{
    public static class ExtensionsForCssWriter
    {
        public static CssStatement Css(this string selector, params Func<string, string>[] declarations)
        {
            return Css(new[] { selector }, declarations);
        }

        public static CssStatement Css(this IEnumerable<string> selector, params Func<string, string>[] declarations)
        {
            return new CssStatement
            {
                Selectors = selector.ToArray(),
                Declarations = new Dictionary<string, string> {
                    {"font-size", "12pt" },
                    {"line-height", "10pt" }
                }
            };
        }
    }
}
