using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LINQ
{
    class Class1
    {
        class ClassA
        {
            public int Value { get; set; }
            public ClassA(int value)
            {
                Value = value;
            }
        }

        void Method1()
        {
            var data = new[] { 1, 3, 5, 7, 9 };

            var result =
                from i in data
                where i < 5
                orderby i descending
                select i;

            foreach(var i in result)
            {

            }
        }

        void Method2()
        {
            var data = new[] { 1, 3, 5, 7, 9 };

            var result =
                data
                .Where(i => i < 5)
                .OrderByDescending(i => i);

            foreach (var i in result)
            {

            }
        }

        void Method3()
        {
            var data = new[] { 1, 3, 5, 7, 9 };

            var result =
                (from i in data
                 where i < 5
                 orderby i descending
                 select i)
                .FirstOrDefault();
        }

        void Method4()
        {
            var data = new[] { 1, 3, 5, 7, 9 };

            var result =
                from i in data
                where i < 5
                orderby i descending
                select new ClassA(i);

            foreach(var a in result)
            {

            }
            foreach(var a in result)
            {

            }
        }

        void Method5()
        {
            var data = new[] { 1, 3, 5, 7, 9 };

            var result =
                (from i in data
                where i < 5
                orderby i descending
                select new ClassA(i))
                .ToArray();

            foreach (var a in result)
            {

            }
            foreach (var a in result)
            {

            }
        }

        void Method6()
        {
            var data = new[] { 1, 3, 5, 7, 9 };

            var result =
                from i in data
                where i < 5
                orderby i descending
                select new ClassA(i);

            result = result.ToArray();

            foreach (var a in result)
            {

            }
            foreach (var a in result)
            {

            }
        }
    }
}