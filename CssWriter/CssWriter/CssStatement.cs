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
    {Declarations.Keys.First()}: {Declarations.Values.First()}
}}";
        }

        private string CssForSelectors()
        {
            return string.Join(", ", Selectors);
        }
    }
}
