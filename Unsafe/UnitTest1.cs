using NuGet.Frameworks;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Unsafe;

public class UnitTest1
{
    [Fact]
    public void ƒ|ƒCƒ“ƒ^()
    {
        int i = 0;
        unsafe
        {
            int* p = &i;
            *p = 20;
        }
        Assert.Equal(20, i);
    }

    [Fact]
    public void fix()
    {
        var array = new int[20];

        unsafe
        {
            fixed (int* start = array)
            {
                int* p = start;
                for (int i = 0; i < array.Length; i++)
                {
                    *(p++) = i;
                }
            }
        }
        Assert.Equal(0, array[0]);
        Assert.Equal(1, array[1]);
        Assert.Equal(2, array[2]);
        Assert.Equal(3, array[3]);
        Assert.Equal(4, array[4]);
        Assert.Equal(5, array[5]);
        Assert.Equal(6, array[6]);
        Assert.Equal(7, array[7]);
        Assert.Equal(8, array[8]);
        Assert.Equal(9, array[9]);
        Assert.Equal(10, array[10]);
        Assert.Equal(11, array[11]);
        Assert.Equal(12, array[12]);
        Assert.Equal(13, array[13]);
        Assert.Equal(14, array[14]);
        Assert.Equal(15, array[15]);
        Assert.Equal(16, array[16]);
        Assert.Equal(17, array[17]);
        Assert.Equal(18, array[18]);
        Assert.Equal(19, array[19]);
    }

    [Fact]
    public unsafe void •¶Žš—ñ()
    {
        var str = "12345";
        var str2 = "     ";

        fixed (char* start = str)
        fixed (char* start2 = str2)
        {
            char* p = start;
            char* p2 = start2;
            while ((*(p2++) = *(p++)) != '\0') ;
        }

        Assert.Equal("12345", str2);
    }

    [Fact]
    public unsafe void •¶Žš—ñ2()
    {
        var str = "12345";
        var str2 = "abcde";
        var otherstr = "abcde";
        var otherstr2 = "abc" + "de";
        var otherstr3 = "abcdf".Replace("f", "e");

        fixed (char* start = str)
        fixed (char* start2 = str2)
        {
            char* p = start;
            char* p2 = start2;
            while ((*(p2++) = *(p++)) != '\0') ;
        }

        Assert.Equal("12345", otherstr);
        Assert.Equal("12345", otherstr2);
        Assert.NotEqual("12345", otherstr3);
    }

    [Fact]
    public unsafe void stackalloc_()
    {
        int* array = stackalloc int[20];
        int* p = array;
        for (int i = 0; i < 20; i++)
        {
            *(p++) = i;
        }

        Assert.Equal(0, array[0]);
        Assert.Equal(1, array[1]);
        Assert.Equal(2, array[2]);
        Assert.Equal(3, array[3]);
        Assert.Equal(4, array[4]);
        Assert.Equal(5, array[5]);
        Assert.Equal(6, array[6]);
        Assert.Equal(7, array[7]);
        Assert.Equal(8, array[8]);
        Assert.Equal(9, array[9]);
        Assert.Equal(10, array[10]);
        Assert.Equal(11, array[11]);
        Assert.Equal(12, array[12]);
        Assert.Equal(13, array[13]);
        Assert.Equal(14, array[14]);
        Assert.Equal(15, array[15]);
        Assert.Equal(16, array[16]);
        Assert.Equal(17, array[17]);
        Assert.Equal(18, array[18]);
        Assert.Equal(19, array[19]);
    }

    [Fact]
    public void Ref()
    {
        int i = 3;
        ref int ii = ref i;

        ii = 4;

        Assert.Equal(4, i);
    }

    [Fact]
    public void Span()
    {
        Span<int> span = stackalloc int[10];

        var span2 = span[1..5];
    }
}