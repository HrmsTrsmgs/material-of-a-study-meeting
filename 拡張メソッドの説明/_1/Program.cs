using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1
{
    static class ObjectExtensions
    {
        public static void WrittenAaLine(this object instanse)
        {
            Console.WriteLine(instanse);
        }
    }

    class Program
    {


        static void Main(string[] args)
        {
            "".WrittenAaLine();

            1.WrittenAaLine();
        }
    }
}
