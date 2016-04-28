using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class CssFile
    {
        private CssStatement cssStatement;

        public CssFile(string filePath)
        {
            Path = filePath;
        }

        public CssFile(string filePath, CssStatement cssStatement) : this(filePath)
        {
            this.cssStatement = cssStatement;
        }

        public string Path { get; private set; }
        public CssStatement[] Statements { get; set; }

        public void Save()
        {
            File.WriteAllText(Path, cssStatement.ToString());
        }
    }
}
