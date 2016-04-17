using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4
{
    class Program
    {
        static IEnumerable<int> ZeroToInfinity()
        {
            int i = 0;
            while (true) yield return i++;
        }

        static void Main(string[] args)
        {
            foreach (var i in
                (
                    from i in ZeroToInfinity()
                    let iCube = i * i * i
                    where iCube % 5 == 0
                    select iCube
                ).Take(100))
            {
                Console.WriteLine(i);
            }
        }
    }
}
