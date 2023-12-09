using AdventOfCode2023.Day09;

namespace AdventOfCode2023.Tests.Day09;

public static class Tests09
{
    private const string Example = """
        0 3 6 9 12 15
        1 3 6 10 15 21
        10 13 16 21 30 45
        """;

    [Fact]
    public static void TestExampleP1()
    {
        var res = Solution09.SolveP1(Example);

        Assert.Equal(114, res);
    }

    [Fact]
    public static void TestP1()
    {
        var res = Solution09.SolveP1(Input09.Data);

        Assert.Equal(2174807968, res);
    }

    [Fact]
    public static void TestExampleP2()
    {
        var res = Solution09.SolveP2(Example);

        Assert.Equal(2, res);
    }

    [Fact]
    public static void TestP2()
    {
        var res = Solution09.SolveP2(Input09.Data);

        Assert.Equal(1208, res);
    }
}
