using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicのList
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = new List<dynamic>();

            list.Add("ABC");
            list.Add(10);

            Console.WriteLine(list[0] + "DEF");
            Console.WriteLine(list[1] * 3);

            list.AddExpando(3);

            list[2].Name = "太郎";
            list[2].Age = 18;

            list[3].Name = "次郎";
            list[3].Age = 17;

            list[4].Name = "三郎";
            list[4].Age = 16;

            for (var i = 2; i <= 4; i++)
            {
                Console.WriteLine(list[i].Name);
                Console.WriteLine(list[i].Age);
            }

            Console.ReadKey();
        }
    }
}
