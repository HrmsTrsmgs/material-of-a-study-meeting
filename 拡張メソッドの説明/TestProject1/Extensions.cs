using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject1.TestExtensions
{
    public static class Extensions
    {
        public static bool IsNull(this object? self)
        {
            return self == null;
        }

        public static bool IsGreaterThan(this int self, int other)
        {
            return other < self;
        }

        public static string ToCsv<T>(this IList<T> self)
        {
            return string.Join(",", self);
        }

        public static int SumOfSquared(this IList<int> self)
        {
            return self.Select(it => it * it).Sum();
        }


    }
}
