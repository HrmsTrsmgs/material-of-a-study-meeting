using System;
using Xunit;

namespace TestProject1
{
    public static class ObjectExtensions
    {
        public static void WriteLineToConsole(this object self)
        {
            Console.WriteLine(self.ToString());
        }
    }


    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            "".WriteLineToConsole();
            1.WriteLineToConsole();
        }
    }
}