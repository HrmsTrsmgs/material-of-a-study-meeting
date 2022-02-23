using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProject1.TestExtensions;
using Xunit;

namespace TestProject1
{
    public class UnitTest2
    {
        [Fact]
        public void Test1()
        {
            object? obj = null;
            var isNull = obj.IsNull();

            Assert.True(isNull);
        }

        [Fact]
        public void Test2()
        {
            var isGreater = 3.IsGreaterThan(4);
        }

        [Fact]
        public void Test3()
        {
            var strList = new List<string> { };
            var intList = new List<int> { };

            var strinCsv = strList.ToCsv();

            var intCsv = intList.ToCsv();

            var sumOfSquared = intList.SumOfSquared();
        }
    }
}
