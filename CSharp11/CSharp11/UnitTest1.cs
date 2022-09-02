using FluentAssertions;
using System.Numerics;

namespace CSharp11;

public class UnitTest1
{
    class WithTypeAttribute : Attribute
    {
        public WithTypeAttribute(Type type){}
    }

    [WithType(typeof(int))]
    public class ClassA { }


    class WithTypeAttribute<T> : Attribute
    {
    }
    
    [WithType<int>]
    public class ClassB { }

    interface IHasZero
    {
        static abstract int Zero { get; }
    }

    class ClassC : IHasZero
    {
        public static int Zero => 0;
    }

    interface IHasOne<TSelf>  where TSelf : IHasOne<TSelf>
    {
        static abstract TSelf One { get; }
        static abstract TSelf operator +(TSelf self, TSelf other);

        static virtual TSelf AddOne(TSelf other) => other + TSelf.One;
    }

    class ClassD : IHasOne<ClassD>
    {
        public static ClassD One => throw new NotImplementedException();

        public static ClassD operator +(ClassD self, ClassD other)
        {
            throw new NotImplementedException();
        }
    }


    public T OldSum<T>(IEnumerable<T> numbers) where T : notnull
    {
        dynamic sum = 0;
        foreach (T n in numbers)
        {
            sum += n;
        }
        return (T)sum;
    }

    public T Sum<T>(IEnumerable<T> numbers) 
        where T : IAdditionOperators<T, T, T>, IAdditiveIdentity<T, T>
    {
        T sum = T.AdditiveIdentity;
        foreach(T n in numbers)
        {
            sum += n;
        }
        return sum;
    }

    [Fact]
    public void ジェネリック型数値演算()
    {
        OldSum(new[] { 1, 2, 3, 4, 5 })
            .Should().Be(15);
        OldSum(new[] { 1.1, 2.2, 3.3, 4.4, 5.5 })
            .Should().Be(16.5);

        Sum(new[] { 1, 2, 3, 4, 5 })
            .Should().Be(15);
        Sum(new[] { 1.1, 2.2, 3.3, 4.4, 5.5 })
            .Should().Be(16.5);
    }

    [Fact]
    public void 符号なし右シフト演算子()
    {
        string ToBits(int i) => Convert.ToString(i, 2).PadLeft(32, '0');

        var i = 7;

        ToBits(i)
            .Should().Be("00000000000000000000000000000111");
        ToBits(i >> 2)
            .Should().Be("00000000000000000000000000000001");
        ToBits(i >>> 2)
            .Should().Be("00000000000000000000000000000001");

        ToBits(-i)
            .Should().Be("11111111111111111111111111111001");
        ToBits(-i >> 2)
            .Should().Be("11111111111111111111111111111110");
        ToBits(-i >>> 2)
            .Should().Be("00111111111111111111111111111110");
    }

    class ClassE
    {
        public static ClassE operator<<(ClassE self, ClassE other) => throw new NotImplementedException();

        public static ClassE operator+(ClassE self, ClassE other) => throw new NotImplementedException();
        public static ClassE operator checked+(ClassE self, ClassE other) => throw new NotImplementedException();

        public void Func()
        {
            var i = int.MaxValue;
            unchecked
            {
                i++;
                i--;
            }
            checked
            {
                i++;
                i--;
            }
        }
    }

    [Fact]
    public void 数値IntPtr()
    {
        var i = new IntPtr(100);
        var i2 = new IntPtr(200);

        (i - i2)
            .ToInt32().Should().Be(-100);

        var ui = new UIntPtr(1000);
        var ui2 = new UIntPtr(2000);

        (ui + ui2)
            .ToUInt64().Should().Be(3000);

        nint ii = i;
        nuint uii = ui;
    }

    [Fact]
    public void 文字列補間の改行()
    {
        var i = 3;
        $"{
            i * 3
          }".Should().Be("9");

        $@"number:
{
            i * 3
           }".Should().Be("number:\r\n9");
    }

    [Fact]
    public void リストパターン()
    {
        var l = new[] { 1, 2, 3, 4, 5 };

        switch(l)
        {
            case [ 1, 2, 3, 4, 5 ]:
                break;
            default:
                throw new NotSupportedException();
        }

        switch (l)
        {
            case [1, _, 3, _, 5]:
                break;
            default:
                throw new NotSupportedException();
        }

        switch (l)
        {
            case [1, .., 5]:
                break;
            default:
                throw new NotSupportedException();
        }

        switch (l)
        {
            case [1, .., 4, _]:
                break;
            default:
                throw new NotSupportedException();
        }
    }

    int Func(double d)
    {
        throw new NotSupportedException();
    }

    [Fact]
    public void メソッドグループの変換()
    {
        var func = Func;

        var func2 = Func;

        //func.Should().BeSameAs(func2);
        // こういうことじゃないの？
    }

    [Fact]
    public void 未加工の文字列リテラル()
    {
        var s = """\'"いろいろ書けます""";

        s.Should().Be("\\\'\"いろいろ書けます");

        var s2 = """"「"""」も書けます。"""";

        s2.Should().Be("「\"\"\"」も書けます。");

        var s3 = """
            複数行で書けます。
            いろはにほへと
            ちりぬるを
            """;
        s3.Should().Be("複数行で書けます。\r\nいろはにほへと\r\nちりぬるを");

        var s4 = @"""@と共用はできません""";
        s4.Should().Be("\"@と共用はできません\"");

        int i = 3;
        int i2 = 5;
        var s5 = $"""{i + i2}と埋め込みもできます\""";
        s5.Should().Be("8と埋め込みもできます\\");

        $$"""{{{i + i2}}, {{i * i2}}}と$も増やせます"""
            .Should().Be("{8, 15}と$も増やせます");
    }

    struct StructA
    {
        public int I;
        public bool B;
        public string S;
    }

    [Fact]
    public void 構造体のフィールドの既定値初期化()
    {
        var s = new StructA();

        s.I.Should().Be(0);
        s.B.Should().BeFalse();
        s.S.Should().BeNull();
    }

    [Fact]
    public void string定数でのSpan_charまたはReadOnlySpan_charのパターンマッチ()
    {
        var str = "吾輩は猫である。名はまだない。";
        switch(str)
        {
            case "吾輩は猫である。名はまだない。":
                break;
            default:
                throw new InvalidOperationException();
        }

        ReadOnlySpan<char> span = str;

        switch (span)
        {
            case "吾輩は猫である。名はまだない。":
                break;
            default:
                throw new InvalidOperationException();
        }

        switch (span[0..8])
        {
            case "吾輩は猫である。":
                break;
            default:
                throw new InvalidOperationException();
        }
    }

    class WithParameterAttribute : Attribute
    {
        public WithParameterAttribute(string name){}
    }

    [WithParameter("first")]
    void Func2(int first, int second) { }

    [WithParameter(nameof(first))]
    void Func3(int first, int second) { }

    [Fact]
    public void UTF8の文字列リテラル()
    {
        var u8s = "吾輩は猫である"u8;

        u8s.Length.Should().Be(21);

        ReadOnlySpan<byte> s = "名はまだない"u8;

        var s2 = 
            "春はあけぼの。"u8 +
            "やうやう白くなりゆく山ぎは、"u8 +
            "すこしあかりて、紫だちたる "u8 +
            "雲のほそくたなびきたる"u8;

        //var ss = "すこしあかりて、紫だちたる "u8;
        //var s3 =
        //    "春はあけぼの。"u8 +
        //    "やうやう白くなりゆく山ぎは、"u8 +
        //    ss +
        //    "雲のほそくたなびきたる"u8;

        var s4 = """
            春はあけぼの。
            やうやう白くなりゆく山ぎは、すこしあかりて、紫だちたる 雲のほそくたなびきたる
            """;

        //var s5 = $""u8;
    }

    public class ClassF
    {
        public string Name { get; init; } = "";
    }

    public class ClassG
    {
        public required string Name { get; init; }
    }

    [Fact]
    public void 必須メンバー()
    {
        var f = new ClassF { Name = "abc"};

        //f.Name = "def";

        var f2 = new ClassF();
        f2.Name.Should().BeEmpty();

        var g = new ClassG { Name = "abc" };
        //var g2 = new ClassG();
    }
}

file class ClassH
{
}