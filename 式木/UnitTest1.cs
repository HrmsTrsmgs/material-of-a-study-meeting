using System;
using System.Linq.Expressions;
using Xunit;

namespace 式木
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            var result1 = Calculate2((l, r) => l * r, 2, 3);
            var result2 = Calculate2((l, r) => Math.Pow(l, r), 2, 3);
            var result3 = Calculate2((l, r) => Math.Pow(l, r) + l * r, 2, 3);
        }

        double Calculate(Func<double, double, double> func, double left, double right)
        {
            return func(left, right);
            
        }

        double Calculate2(Expression<Func<double, double, double>> expression, double left, double right)
        {
            var func =  expression.Compile();
            return func(left, right);
        }
    }
}