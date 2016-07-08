using System;
using System.Collections.Generic;
//using System.Linq;
using Linq.MyLinq;

namespace LINQ
{
    class Program
    {
        static void Main(string[] args)
        {
            var data = new[] { 3, 2, 7, 5, 1 };

            var result1 =
                from i in data
                select i * i;

            foreach (var item in result1)
            {
            }

            var result2 =
                from i in data
                where i < 6
                select i * i;

            foreach (var item in result2)
            {
            }

            var result3 =
                from i in data
                where i < 4
                orderby i
                select i * i;
            foreach (var item in result3)
            {
            }
        }
    }
}
