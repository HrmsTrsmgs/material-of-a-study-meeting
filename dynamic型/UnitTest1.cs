using Microsoft.CSharp.RuntimeBinder;
using System;
using System.Dynamic;
using Xunit;

namespace dynamic型
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            dynamic d = "abc";
            var l = d.Length;
            Assert.Equal(3, l);
        }


        [Fact]
        public void Test2()
        {
            dynamic d = "123";

            var i = int.Parse(d);

            Assert.Equal(123, i);
        }

        [Fact]
        public void Test3()
        {
            dynamic d = "abc";
            int l = d.Length;
            Assert.Equal(3, l);
        }

        [Fact]
        public void Test4()
        {
            dynamic d = "abc";
            Assert.Throws<RuntimeBinderException>(() =>
            {
                var l = d.Count;
            });
        }

        [Fact]
        public void Test5()
        {
            dynamic d = "abc";
            Assert.Throws<RuntimeBinderException>(() =>
            {
                string l = d.Length;
            });
        }

        [Fact]
        public void Test6()
        {
            dynamic e = new ExpandoObject();

            e.Name = "ABC";
            e.Age = 43;   
            Assert.Equal("ABC", e.Name);
            Assert.Equal(43, e.Age);
        }

        public class A
        {
            public int Id { get; set; }
            public DateTime UpdateTime { get; set; }
        }

        public class B
        {
            public string Name { get; set; }
            public DateTime UpdateTime { get; set; }
        }

        void Stamp(dynamic row)
        { 
            row.UpdateTime = DateTime.Now;
        }

        [Fact]
        public void Test7()
        {
            A a = new A();
            B b = new B();

            Stamp(a);
            Stamp(b);
        }

        public T Average<T>(T left, T right)
        {
            return ((dynamic?)left + (dynamic?)right) / 2;
        }


        [Fact]
        public void Test8()
        {
            int i = Average(1, 3);
            float f = Average(1.3f, 1.5f);

            Assert.Equal(2, i);
            Assert.Equal(1.4f, f);
        }

    }
}