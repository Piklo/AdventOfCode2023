using AdventOfCode2023.Day13;

namespace AdventOfCode2023.Tests.Day13;

public static class Tests13
{
    private const string Example = """
        #.##..##.
        ..#.##.#.
        ##......#
        ##......#
        ..#.##.#.
        ..##..##.
        #.#.##.#.

        #...##..#
        #....#..#
        ..##..###
        #####.##.
        #####.##.
        ..##..###
        #....#..#
        """;

    [Fact]
    public static void TestExampleP1()
    {
        var res = Solution13.SolveP1(Example);

        Assert.Equal(405, res);
    }

    [Fact]
    public static void TestP1()
    {
        var res = Solution13.SolveP1(Input13.Data);

        Assert.Equal(43614, res);
    }
}
