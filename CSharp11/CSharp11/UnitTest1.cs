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
    public void �W�F�l���b�N�^���l���Z()
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
    public void �����Ȃ��E�V�t�g���Z�q()
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
    public void ���lIntPtr()
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
    public void �������Ԃ̉��s()
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
    public void ���X�g�p�^�[��()
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
    public void ���\�b�h�O���[�v�̕ϊ�()
    {
        var func = Func;

        var func2 = Func;

        //func.Should().BeSameAs(func2);
        // �����������Ƃ���Ȃ��́H
    }

    [Fact]
    public void �����H�̕����񃊃e����()
    {
        var s = """\'"���낢�돑���܂�""";

        s.Should().Be("\\\'\"���낢�돑���܂�");

        var s2 = """"�u"""�v�������܂��B"""";

        s2.Should().Be("�u\"\"\"�v�������܂��B");

        var s3 = """
            �����s�ŏ����܂��B
            ����͂ɂقւ�
            ����ʂ��
            """;
        s3.Should().Be("�����s�ŏ����܂��B\r\n����͂ɂقւ�\r\n����ʂ��");

        var s4 = @"""@�Ƌ��p�͂ł��܂���""";
        s4.Should().Be("\"@�Ƌ��p�͂ł��܂���\"");

        int i = 3;
        int i2 = 5;
        var s5 = $"""{i + i2}�Ɩ��ߍ��݂��ł��܂�\""";
        s5.Should().Be("8�Ɩ��ߍ��݂��ł��܂�\\");

        $$"""{{{i + i2}}, {{i * i2}}}��$�����₹�܂�"""
            .Should().Be("{8, 15}��$�����₹�܂�");
    }

    struct StructA
    {
        public int I;
        public bool B;
        public string S;
    }

    [Fact]
    public void �\���̂̃t�B�[���h�̊���l������()
    {
        var s = new StructA();

        s.I.Should().Be(0);
        s.B.Should().BeFalse();
        s.S.Should().BeNull();
    }

    [Fact]
    public void string�萔�ł�Span_char�܂���ReadOnlySpan_char�̃p�^�[���}�b�`()
    {
        var str = "��y�͔L�ł���B���͂܂��Ȃ��B";
        switch(str)
        {
            case "��y�͔L�ł���B���͂܂��Ȃ��B":
                break;
            default:
                throw new InvalidOperationException();
        }

        ReadOnlySpan<char> span = str;

        switch (span)
        {
            case "��y�͔L�ł���B���͂܂��Ȃ��B":
                break;
            default:
                throw new InvalidOperationException();
        }

        switch (span[0..8])
        {
            case "��y�͔L�ł���B":
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
    public void UTF8�̕����񃊃e����()
    {
        var u8s = "��y�͔L�ł���"u8;

        u8s.Length.Should().Be(21);

        ReadOnlySpan<byte> s = "���͂܂��Ȃ�"u8;

        var s2 = 
            "�t�͂����ڂ́B"u8 +
            "�₤�₤�����Ȃ�䂭�R���́A"u8 +
            "������������āA���������� "u8 +
            "�_�̂ق������Ȃт�����"u8;

        //var ss = "������������āA���������� "u8;
        //var s3 =
        //    "�t�͂����ڂ́B"u8 +
        //    "�₤�₤�����Ȃ�䂭�R���́A"u8 +
        //    ss +
        //    "�_�̂ق������Ȃт�����"u8;

        var s4 = """
            �t�͂����ڂ́B
            �₤�₤�����Ȃ�䂭�R���́A������������āA���������� �_�̂ق������Ȃт�����
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
    public void �K�{�����o�[()
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