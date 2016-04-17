using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6
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
            var _enumratable = GetNumbers();
            var _enumrator = _enumratable.GetEnumerator();

            while(_enumrator.MoveNext())
            {
                Console.WriteLine(_enumrator.Current);
            }
        }
    }
}
