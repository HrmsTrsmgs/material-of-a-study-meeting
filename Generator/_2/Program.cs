using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2
{
    class Program
    {
        static IEnumerable<string> GetNumbers()
        {
            yield return "ABC";
            yield return "DEF";
            yield return "GHI";
        }

        static void Main(string[] args)
        {
            foreach (var i in GetNumbers())
            {
                Console.WriteLine(i);
            }
        }
    }
}
