using AdventOfCode2023.Day07;

namespace AdventOfCode2023.Tests.Day07;

public static class Tests07
{
    private const string Example = """
        32T3K 765
        T55J5 684
        KK677 28
        KTJJT 220
        QQQJA 483
        """;

    [Fact]
    public static void TestExampleP1()
    {
        var res = Solution07.SolveP1(Example);

        Assert.Equal(6440, res);
    }

    [Fact]
    public static void TestP1()
    {
        var res = Solution07.SolveP1(Input07.Data);

        Assert.Equal(247961593, res);
    }

    [Fact]
    public static void TestExampleP2()
    {
        var res = Solution07.SolveP2(Example);

        Assert.Equal(5905, res);
    }

    [Fact]
    public static void TestP2()
    {
        var res = Solution07.SolveP2(Input07.Data);

        Assert.Equal(248750699, res);
    }
}
