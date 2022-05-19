using Net5;
using System.Diagnostics.CodeAnalysis;

namespace Null許容型;

public class Class1
{
    public void Func(string str)
    {

    }

    public void 説明1(string str, string? strNullable)
    {
        str = null;

        strNullable = null;

        str = strNullable;
        strNullable = str;

        strNullable = null;

        var old = new Old();

        old.Func(strNullable);
        Func(strNullable);
    }

    public void 説明2(string str, string? strNullable)
    {
        var s2 = strNullable.Split(" ");

        var s3 = strNullable?.Split(" ");

        str = strNullable;

        str = strNullable ?? "";

        str = strNullable ?? throw new InvalidDataException();

        if (strNullable != null)
        {
            str = strNullable;
        }
    }

    public void 説明3(string str, string? strNullable)
    {
        if (strNullable == null) throw new ArgumentNullException(nameof(strNullable));

        str = strNullable;
    }

    private string Name { get; set; }
    private string? Name2 { get; set; }

    private string Name3 { get; set; } = "ABC";

    private string Name4 { get; set; }
    public Class1()
    {
        Name4 = "ABC";
    }

    public void 説明4(string str, string? strNullable)
    {
        if (Uri.TryCreate("http://localhost/", new(), out var uri))
        {
            Uri u = uri;
        }
        else
        {
            Uri u = uri;
        }
    }

    private bool TryAdd(string number1, string number2, [NotNullWhen(true)] out string? result)
    {
        result = null;
        if (!double.TryParse(number1, out var d1)) return false;
        if (!double.TryParse(number2, out var d2)) return false;
        result = (d1 + d2).ToString();
        return true;
    }

    public void 説明5(string number1, string number2)
    {
        if (TryAdd(number1, number2, out var result))
        {
            string r = result;
        }
        else
        {
            string r = result;
        }
    }

    public string? Name5 { get; set; }

    [MemberNotNullWhen(true, nameof(Name5))]
    public bool HasName5 => Name5 != null;

    public void 説明6()
    {
        if (HasName5)
        {
            string name5 = Name5;
        }
        else
        {
            string name5 = Name5;
        }
    }

    [DoesNotReturn]
    public void ThrowException()
    {
        throw new Exception();
    }

    public void 説明7(string? strNullable)
    {
        if (strNullable == null) ThrowException();
        string str = strNullable;
    }
    private string name6;

    [AllowNull]
    public string Name6
    {
        get => name6;
        set => name6 = value ?? "";
    }

    public void 説明8(string? strNullable)
    {
        Name6 = strNullable;
    }
}

