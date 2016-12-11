using System;
using System.Collections.Generic;
using System.Linq;
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

            var user2 = (name: "Bill Gates", age: 61);

            // varで代入すると同じタプルに
            var user3 = user2;

            // 微妙に違う形式ならキャストしてくれる
            (string full, int age) user4 = user2;

            (string name, double age) user5 = user2;

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

        var Throw式()
        {
            bool b;
            int i = b ? 1 : throw new Exception("ありえない"); 
        }

    }
}
