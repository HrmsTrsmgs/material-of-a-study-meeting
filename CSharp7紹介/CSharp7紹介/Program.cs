using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CSharp7紹介
{
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
            参照();
            Throw式();
            ValueTuple();
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
                age: 48,
                academicBackground: new[] { "University of Chicago", "University of Wisconsin-Milwaukee" });

            var user2 = (
                name: (first: "Steven", last: "Ballmer"),
                eMail: "aaa@bb.com",
                age: 60,
                academicBackground: new[] { "Harvard University" });

            user2 = user1;

            user1 = Func();

            Console.WriteLine(user1.name.first);

            var (name3, _, _, _) = user1;

            //Console.WriteLine(_);

            var numbers = (1, 2.0);

            Console.WriteLine(numbers.Item1);
            Console.WriteLine(numbers.Item2);

            Console.WriteLine(name.Item1);
            Console.WriteLine(name.Item2);


            var sevens = (a: 7, b: 7.0, c: "7", d: 7, e: 7.0, f: "7", g: 7);
            var eights = (a: 8, b: 8.0, c: "8", d: 8, e: 8.0, f: "8", g: 8, h: 8.0);
            var nines = (a: 9, b: 9.0, c: "9", d: 9, e: 9.0, f: "9", g: 9, h: 9.0, i:"9");
            var fifteens = (a: 15, b: 15.0, c: "15", d: 15, e: 15.0, f: "15", g: 15, h: 15.0, i: "15", j: 15, k: 15.0, l: "15", m: 15, n: 15.0, o: "15");


            // 変数として分解できます。
            var (first, last) = name;

            Console.WriteLine(first);
            Console.WriteLine(last);

            var user3 = (name: "Bill Gates", age: 61);

            // varで代入すると同じタプルに
            var user4 = user3;

            // 微妙に違う形式ならキャストしてくれる
            (string full, int age) user5 = user3;

            (string name, double age) user6 = user3;

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

        ((string first, string last) name, string eMail, int age, string[] academicBackground) Func()
        {
            return (
                name: (first: "Satya", last: "Nadella"),
                eMail: "yyy@xxx.com",
                age: 48,
                academicBackground: new[] { "University of Chicago", "University of Wisconsin-Milwaukee" });
        }

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
            switch (obj)
            {
                case int n when 0 <= n:
                    // intの場合
                    return Math.Sqrt(n);
                case double d when 0 <= d:
                    // doubleの場合
                    return Math.Sqrt(d);
                case decimal d when 0 < d:
                    // decimalの場合
                    return Math.Sqrt((double)d);
                case string s when double.TryParse(s, out double d):
                    // stringの場合
                    return d;
                default:
                    // その他
                    return null;
            }
        }

        void ローカル関数()
        {
            var f1 = fibonacci(1);
            var f4 = fibonacci(4);
            var f7 = fibonacci(7);

            // 関数ローカルで再起が書ける
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

        public struct Point
        {
            public double X { get; set; }
            public double Y { get; set; }
        }

        private Point location;
        
        public ref Point Location
        {
            get
            {
                return ref location;
            }
        }

        void 参照()
        {
            this.Location.X = 3;
        }

        private string name;

        public string GetName()
        {
            return name;
        }
        public string GetName2() => name;

        public string Name { get; set; }

        public string Name2
        {
            get
            {
                return name;
            }
        }

        public string Name3 => name;

        public string Name4
        {
            get => name;
            set => name = value;
        }

        void 式()
        {
            var n = GetName();
            var n2 = GetName2();
            var n3 = Name;
            var n4 = Name2;
            var n5 = Name3;
            var n6 = Name4;
            Name4 = n;
        }

        void Throw式()
        {
            bool b = true;
            int i = b ? 1 : throw new Exception("ありえない"); 
        }

        async void ValueTuple()
        {
            Task.Run(async () =>
            {
                var s1 = await GetStringAsync();
                var s2 = await GetStringAsync();

                if (s1 == s2)
                {
                    Console.WriteLine(s1);
                }
            }).Wait();
        }


        string _string = null;
        async ValueTask<string> GetStringAsync()
        {
            if(_string == null)
            {
                _string = await (await new HttpClient().GetAsync("http://www.yahoo.co.jp")).Content.ReadAsStringAsync();
            }
            return _string;
        }
    }
}
