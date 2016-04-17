using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3
{
    class Program
    {
        static IEnumerable<int> GetNumbers()
        {
            for(var i = 1; i <= 100; ++i)
            {
                yield return i;
            }
        }

        static void Main(string[] args)
        {
            foreach (var i in 
                from i in GetNumbers()
                where i % 3 == 1
                select i)
            {
                Console.WriteLine(i);
            }
        }
    }
}
