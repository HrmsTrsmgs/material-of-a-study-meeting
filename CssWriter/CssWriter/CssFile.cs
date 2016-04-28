using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CssWriter
{
    public class CssFile
    {
        public string Path { get; set; }

        public CssFile(string path)
        {
            Path = path;
        }

    }
}
