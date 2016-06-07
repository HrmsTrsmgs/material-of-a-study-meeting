using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CssWriter
{
    public class CssFile
    {
        CssStatement cssStatement;

        public string Path { get; private set; }
        public CssStatement[] Statements { get; set; }

        public CssFile(string path)
        {
            Path = path;
        }

        public CssFile(string path, CssStatement cssStatement) : this(path)
        {
            this.cssStatement = cssStatement;
        }

        public void Save()
        {
            File.WriteAllText(Path, cssStatement.ToString());
        }
    }
}
