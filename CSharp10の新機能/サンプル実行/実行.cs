using FluentAssertions;
using System.Runtime.CompilerServices;
using System.Text;
using Xunit;

namespace サンプル実行;

public class 実行
{
    struct Struct1
    {
        public Struct1(int x, int y, int z)
        {
            X = x;
            Y = y;
            Z = z;
        }
        public int X { get; set; }
        public int Y { get; set; }
        public int Z { get; set; }
    }
    record struct RecordStruct1(int X, int Y, int Z);


    [Fact]
    public void レコード構造体()
    {
        var struct1 = new RecordStruct1(1, 2, 3);
        var struct2 = new RecordStruct1(1, 2, 3);

        (struct1 == struct2).Should().BeTrue();

        var (x, y, z) = struct1;

        x.Should().Be(1);
        y.Should().Be(2);
        z.Should().Be(3);

        struct1.ToString().Should().Be("RecordStruct1 { X = 1, Y = 2, Z = 3 }");

        var struct3 = struct1 with { X = 4 };

        struct3.X.Should().Be(4);
        struct3.Y.Should().Be(2);
        struct3.Z.Should().Be(3);
    }

    struct Struct2
    {
        public Struct2()
        {
            X = 1;
            Y = 2;
            Z = 3;
        }
        public int X { get; set; }
        public int Y { get; set; }
        public int Z { get; set; }
    }

    [Fact]
    public void 構造化の機能強化()
    {
        var struct2 = new Struct2();

        var struct3 = struct2 with { X = 4 };

        struct3.X.Should().Be(4);
        struct3.Y.Should().Be(2);
        struct3.Z.Should().Be(3);
    }

    [Fact]
    public void 補完された文字列ハンドラー()
    {
        var (x, y) = (1, 2);

        var str = $"{{ X = {x}, Y = {y} }}";

        // ～C#9では以下と同じ
        var str9 = string.Format("{{ X = {0}, Y = {1} }}", x, y);
        str.Should().Be(str9);

        // C#10～は以下と同じ。

        var handler = new DefaultInterpolatedStringHandler(3, 2);
        handler.AppendLiteral("{ X = ");
        handler.AppendFormatted(x);
        handler.AppendLiteral(", Y = ");
        handler.AppendFormatted(y);
        handler.AppendLiteral(" }");
        var str10 = handler.ToStringAndClear();

        str.Should().Be(str10);
    }

    [Fact]
    public void Const文字列補完()
    {
        const int x = 1;
        const int y = 2;

        var str = $"{{ X = {x}, Y = {y} }}";

        // C#10～は以下と同じ。
        var str10 = "{ X = 1, Y = 2 }";

        str.Should().Be(str10);
    }

    [Fact]
    public void グローバルなusingディレクティブ()
    {
        Regex regex = new(@"^.*$");
    }


    // ファイルスコープの名前空間の宣言

    record Record1(Record2 Inner);
    record Record2(int X);

    [Fact]
    public void 拡張プロパティのパターン()
    {
        var record = new Record1(new(1));
        bool ok1;
        switch (record)
        {
            case { Inner.X: 1 }:
                ok1 = true;
                break;
            default: throw new Exception("想定されていません");
        }
        ok1.Should().BeTrue();

        ok1 = false;
        switch (record)
        {
            case { Inner: { X: 1 } }:
                ok1 = true;
                break;
            default: throw new Exception("想定されていません");
        }
        ok1.Should().BeTrue();

        ok1 = false;
        if (record.Inner.X == 1)
        {
            ok1 = true;
        }
        else
        {
            throw new Exception("想定されていません");
        }
        ok1.Should().BeTrue();
    }

    record Record3(int X)
    {
        public sealed override string ToString() => "{Record}";
    }

    record Record4 : Record3
    {
        public Record4() : base(1) { }
    }



    [Fact]
    public void レコード型でToStringを封印することができる()
    {
        var record3 = new Record3(1);
        record3.ToString().Should().Be("{Record}");
        var record4 = new Record4();
        record4.ToString().Should().Be("{Record}");
    }

    [Fact]
    public void 同じ分解内での代入と宣言()
    {
        var struct1 = new RecordStruct1(1, 2, 3);

        var (x1, y1, z1) = struct1;

        x1.Should().Be(1);
        y1.Should().Be(2);
        z1.Should().Be(3);

        int x2, y2, z2;
        (x2, y2, z2) = struct1;

        x2.Should().Be(1);
        y2.Should().Be(2);
        z2.Should().Be(3);

        // C#10～
        int x3, y3;
        (x3, y3, var z3) = struct1;

        x3.Should().Be(1);
        y3.Should().Be(2);
        z3.Should().Be(3);
    }

    [Fact]
    public async Task メソッドでAsyncMethodBuilder属性を許可する()
    {
        await Task.Delay(1);
    }
    [Fact]
    public async ValueTask メソッドでAsyncMethodBuilder属性を許可する2()
    {
        await Task.Delay(1);
    }

    [Fact]
    [AsyncMethodBuilder(typeof(AsyncValueTaskMethodBuilder))]
    public async ValueTask メソッドでAsyncMethodBuilder属性を許可する3()
    {
        await Task.Delay(1);
    }

    

    [Fact]
    public void CallerArgumentExpression属性()
    {
        string Func(
            int x1,
            int x2,
            [CallerArgumentExpressionAttribute("x1")] string? expression1 = null,
            [CallerArgumentExpressionAttribute("x2")] string? expression2 = null)

            => $"{expression1} = {x1}, {expression2} = {x2}";

        var (x, y, z) = (5, 8, 13);

        Func(x + y + z, x * y * z).Should().Be("x + y + z = 26, x * y * z = 520");
    }

    [Fact]
    public void デリゲートの自然な型()
    {
        Action<int, string> action = (i, str) => Console.WriteLine(str + i);

        Func<int, bool, string> func = (i, b) => $"int:{i}, bool{b}";

        var action2 = (int i, string str) => Console.WriteLine(str + i);
        var func2 = (int i, bool b) => $"int:{i}, bool{b}";
        
        var func3 = 
            (int i1, int i2, int i3, int i4, int i5, int i6, int i7, int i8, int i9,
            int i10, int i11, int i12, int i13, int i14, int i15, int i16, int i17)
            => $@"{i1},{i2},{i3},{i4},{i5},{i6},{i7},{i8},{i9},{i10},
{i11},{i12},{i13},{i14},{i15},{i16},{i17}";

        var action3 = (string value, out int result) => result = int.Parse(value);
    }

    [Fact]
    public void ラムダ式の戻り値の明示()
    {
        var func = int? (int i) => i < 0 ? i : null;
    }

    // ラムダ式の属性


    record IntParser(string Value)
    {
        public bool TryParse(out int result) => int.TryParse(Value, out result);
    }

    [Fact]
    public void 改良された定型的な割り当て()
    {
        // ～C#6

        int i;
        var success = int.TryParse("1", out i);

        i.Should().Be(1);

        // C#7～
        var success2 = int.TryParse("2", out var i2);

        i2.Should().Be(2);


        // C#8～

        string str = "";

        str = null; // 警告

        string? nullable = null;

        if(nullable != null)
        {
            str = nullable;
        }

        IntParser? parser = new IntParser("3");

        if(parser?.TryParse(out var i3) == true)
        {
            Console.WriteLine(i3); // C#10～ 警告なし
        }
    }
}