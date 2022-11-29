using Xunit;

namespace 非同期ストリーム;

public class FileLinesAsyncStream : IAsyncEnumerable<string>
{
    public string Path { get; }
    public FileLinesAsyncStream(string path)
    {
        Path = path;
    }
    public IAsyncEnumerator<string> GetAsyncEnumerator(CancellationToken cancellationToken = default)
        => new FileLinesAsyncEnumerator(Path);

}

public class FileLinesAsyncEnumerator : IAsyncEnumerator<string>
{
    public string Path { get; }
    TextReader? reader;
    CancellationToken cancellationToken;

    public FileLinesAsyncEnumerator(string path, CancellationToken cancellationToken = default)
    {
        Path = path;
        this.cancellationToken = cancellationToken;
    }
    public bool IsClosed { get; private set; } = false;

    public string Current { get; private set; } = "";
    
    public ValueTask DisposeAsync()
    {
        reader?.Close();
        IsClosed = true;
        return ValueTask.CompletedTask;
    }

    public async ValueTask<bool> MoveNextAsync()
    {
        if (cancellationToken.IsCancellationRequested) return false;
        if (reader == null)
        {
            reader = new StreamReader(Path);
        }
        try
        {
            if (((StreamReader)reader).EndOfStream) return false;
            var line = await reader.ReadLineAsync();
            if (line == null) return false;
            Current = line;
            return true;
        }
        catch
        {
            return false;
        }
    }
}

public static class FileInfoExtensions
{
    public static IAsyncEnumerator<string> GetAsyncEnumerator(this FileInfo self)
        => new FileLinesAsyncEnumerator(self.FullName);
}


public class Test
{
    public Test()
    {
        File.WriteAllText("text.txt",
            """
            いろはにほへと
            ちりぬるを
            わがよたれそ
            つねならむ
            うゐのおくやま
            けふこえて
            あさきゆめみし
            ゑひもせす
            """);
    }


    [Fact]
    public async Task 非同期ストリーム()
    {
        var actual = new List<string>();
        var linesReader = new FileLinesAsyncStream("text.txt");

        await foreach(var line in linesReader)
        {
            actual.Add(line);
        }


        Assert.Equal(8, actual.Count);
        Assert.Equal("いろはにほへと", actual[0]);
        Assert.Equal("ちりぬるを", actual[1]);
        Assert.Equal("わがよたれそ", actual[2]);
        Assert.Equal("つねならむ", actual[3]);
        Assert.Equal("うゐのおくやま", actual[4]);
        Assert.Equal("けふこえて", actual[5]);
        Assert.Equal("あさきゆめみし", actual[6]);
        Assert.Equal("ゑひもせす", actual[7]);
    }

    [Fact]
    public async Task FileInfo()
    {
        var actual = new List<string>();

        var file = new FileInfo("text.txt");

        await foreach (var line in file)
        {
            actual.Add(line);
        }


        Assert.Equal(8, actual.Count);
        Assert.Equal("いろはにほへと", actual[0]);
        Assert.Equal("ちりぬるを", actual[1]);
        Assert.Equal("わがよたれそ", actual[2]);
        Assert.Equal("つねならむ", actual[3]);
        Assert.Equal("うゐのおくやま", actual[4]);
        Assert.Equal("けふこえて", actual[5]);
        Assert.Equal("あさきゆめみし", actual[6]);
        Assert.Equal("ゑひもせす", actual[7]);
    }

    async IAsyncEnumerable<string> GetLines(string path)
    {
        using var reader = new StreamReader(path);
        while(true)
        {
            if(reader.EndOfStream) yield break;
            var line = await reader.ReadLineAsync();
            if(line == null) yield break;
            yield return line;
        }
    }

    [Fact]
    public async Task 非同期イテレータ()
    {
        var actual = new List<string>();


        await foreach (var line in GetLines("text.txt"))
        {
            actual.Add(line);
        }


        Assert.Equal(8, actual.Count);
        Assert.Equal("いろはにほへと", actual[0]);
        Assert.Equal("ちりぬるを", actual[1]);
        Assert.Equal("わがよたれそ", actual[2]);
        Assert.Equal("つねならむ", actual[3]);
        Assert.Equal("うゐのおくやま", actual[4]);
        Assert.Equal("けふこえて", actual[5]);
        Assert.Equal("あさきゆめみし", actual[6]);
        Assert.Equal("ゑひもせす", actual[7]);
    }

    [Fact]
    public async Task Disposed()
    {
        var linesReader = new FileLinesAsyncStream("text.txt");
        FileLinesAsyncEnumerator? enumerator = null;
        await using (enumerator = (FileLinesAsyncEnumerator)linesReader.GetAsyncEnumerator())
        {
            Assert.False(enumerator.IsClosed);
        }
        Assert.True(enumerator.IsClosed);
    }
}