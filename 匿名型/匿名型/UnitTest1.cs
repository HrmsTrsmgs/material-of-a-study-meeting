using System;
using System.Collections.Generic;
using Xunit;

namespace 匿名型;

public class UnitTest1
{
    [Fact]
    public void Test1()
    {

        var anonymous = new { first = "太郎", last = "山田", age = 22 };

        var anonymous2 = new { first = "花子", last = "鈴木", age = 20 };

        var eq = (anonymous == anonymous2);

        var list = ToSingleList(anonymous);

    }

    IList<T> ToSingleList<T>(T single)
    {
        return new List<T> { single };
    }

    [Fact]
    public void Tuple()
    {
        var tuple = (first: "太郎", last: "山田", age: 22);

        Write(tuple);
    }

    void Write(
        (string first, string last, int age) person
    )
    {
        Console.Write(person.ToString());
    }
}
