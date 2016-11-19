﻿using System;

class Program
{
    static void Main(string[] args)
    {
        new Program().Main();
    }

    void Main()
    {
        タプル();
        Out();
        型スイッチ();
        ローカル関数();
    }

    void タプル()
    {
        // タプルにまとめます
        var name = (first: "Bill", last: "Gates");
        var name2 = (first: "Anders", last: "Hejlsberg");

        name2 = name;

        // .で参照できます
        Console.WriteLine(name.first);
        Console.WriteLine(name.last);

        //複雑なデータ構造も作れます。
        var user1 = (
            name: (first: "Satya", last: "Nadella"),
            eMail: "yyy@xxx.com",
            age: 48, "",
            academicBackground: new[] { "University of Chicago", "University of Wisconsin-Milwaukee" });

        Console.WriteLine(user1.name.first);


        // 変数として分解できます。
        var (first, last) = name;

        Console.WriteLine(first);
        Console.WriteLine(last);

        //swapが簡単に
        (first, last) = (last, first);

        // 戻り値
        var (f, l) = Names("Anders Hejlsberg");
    }

    (string firstName, string lastName) Names(string fullName)
    {
        var names = fullName.Split(' ');

        return (names[0], names[1]);
    }

    //((string first, string last) name, string eMail, int age, string[] academicBackground) Func()
    //{
    //    return (
    //        name: (first: "Satya", last: "Nadella"),
    //        eMail: "yyy@xxx.com",
    //        age: 48, "",
    //        academicBackground: new[] { "University of Chicago", "University of Wisconsin-Milwaukee" });
    //}

    void Out()
    {
        int i = ToInt("123");
    }

    int ToInt(string s)
    {
        if (int.TryParse(s, out int ret))
        {
            return ret;
        }
        else
        {
            return default(int);
        }
    }

    void 型スイッチ()
    {
        Sqrt(10.3m);
    }

    double? Sqrt(object obj)
    {
        switch(obj)
        {
            case int n when 0 <= n:
                return Math.Sqrt(n);
            case double d when 0 <= d:
                return Math.Sqrt(d);
            case decimal d when 0 < d:
                return Math.Sqrt((double)d);
            case string s when double.TryParse(s, out double d):
                return d;
            default:
                return null;
        }
    }

    void ローカル関数()
    {
        var f1 = fibonacci(1);
        var f2 = fibonacci(2);
        var f3 = fibonacci(3);
        var f4 = fibonacci(4);
        var f5 = fibonacci(5);
        var f6 = fibonacci(6);
        var f7 = fibonacci(7);

        int fibonacci(int i)
        {
            switch (i)
            {
                case 0:
                    return 0;
                case 1:
                    return 1;
                default:
                    return fibonacci(i - 1) + fibonacci(i - 2);
            }
        }
    }
}