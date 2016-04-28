using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class CssStatement
    {
        public Dictionary<string, string> Declarations { get; set; }
        public string[] Selectors { get; set; }

        public override string ToString()
        {
            return
$@"{SelectorsView()} {{
    {DeclarationCollectionView(Declarations)}
}}";
        }

        string DeclarationCollectionView( Dictionary<string, string> declarations)
        {
            return string.Join(";\r\n    ", declarations.Select(declaration => DeclarationView(declaration)));
        }


        string DeclarationView(KeyValuePair<string, string> declaration)
        {
            return $"{declaration.Key}: {declaration.Value}";
        }

        string SelectorsView()
        {
            return string.Join(", ", Selectors);
        }
    }
}
