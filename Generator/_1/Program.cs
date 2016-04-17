using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1
{
    class Program
    {
        static IEnumerable<int> GetNumbers()
        {
            yield return 1;
            yield return 3;
            yield return 6;
        }

        static void Main(string[] args)
        {
            foreach(var i in GetNumbers())
            {
                Console.WriteLine(i);
            }   
        }
    }
}
