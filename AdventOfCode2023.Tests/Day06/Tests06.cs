using AdventOfCode2023.Day06;

namespace AdventOfCode2023.Tests.Day06;

public static class Tests06
{
    private const string Example = """
        Time:      7  15   30
        Distance:  9  40  200
        """;

    [Fact]
    public static void TestExampleP1()
    {
        var res = Solution06.SolveP1(Example);

        Assert.Equal(288, res);
    }

    [Fact]
    public static void TestP1()
    {
        var res = Solution06.SolveP1(Input06.Data);

        Assert.Equal(220320, res);
    }

    [Fact]
    public static void TestExampleP2()
    {
        var res = Solution06.SolveP2(Example);

        Assert.Equal(71503, res);
    }

    [Fact]
    public static void TestP2()
    {
        var res = Solution06.SolveP2(Input06.Data);

        Assert.Equal(34454850, res);
    }
}
