using AdventOfCode2023.Day11;

namespace AdventOfCode2023.Tests.Day11;

public static class Tests11
{
    private const string Example = """
            ...#......
            .......#..
            #.........
            ..........
            ......#...
            .#........
            .........#
            ..........
            .......#..
            #...#.....
            """;

    [Fact]
    public static void TestExampleP1()
    {
        var res = Solution11.SolveP1(Example);

        Assert.Equal(374, res);
    }

    [Fact]
    public static void TestP1()
    {
        var res = Solution11.SolveP1(Input11.Data);

        Assert.Equal(9684228, res);
    }

    [Fact]
    public static void TestExampleP1V2()
    {
        var res = Solution11.SolveP1V2(Example);

        Assert.Equal(374, res);
    }

    [Fact]
    public static void TestP1V2()
    {
        var res = Solution11.SolveP1V2(Input11.Data);

        Assert.Equal(9684228, res);
    }

    [Fact]
    public static void TestP2()
    {
        var res = Solution11.SolveP2(Input11.Data);

        Assert.Equal(483844716556, res);
    }
}
