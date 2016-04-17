using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5
{
    class Program
    {
        static IEnumerable<long> FibonacciNumbers()
        {
            var i1 = 0l;
            var i2 = 1l;

            yield return i1;
            yield return i2;

            while(true)
            {
                var i3 = i1 + i2;
                i1 = i2;
                i2 = i3;
                yield return i3;
                
            }
        }

        static void Main(string[] args)
        {
            foreach (var i in
                (
                    from i in FibonacciNumbers()
                    where i % 10 == 0
                    select i
                ).Take(5))
            {
                Console.WriteLine(i);
            }
        }
    }
}
