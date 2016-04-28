using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CssWriter
{
    public class CssStatement
    {
        public Dictionary<string, string> Declarations { get; set; }
        public string[] Selectors { get; set; }

        public override string ToString()
        {
            return
$@"{CssForSelectors()} {{
    {CssForDelaration(Declarations.First())}
}}";
        }

        private string CssForSelectors()
        {
            return string.Join(", ", Selectors);
        }

        private string CssForDelaration(KeyValuePair<string, string> delaration)
        {
            return $"{delaration.Key}: {delaration.Value}";
        }
    }
}
