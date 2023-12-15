using AdventOfCode2023.Day14;

namespace AdventOfCode2023.Tests.Day14;

public static class Tests14
{
    private const string Example = """
            O....#....
            O.OO#....#
            .....##...
            OO.#O....O
            .O.....O#.
            O.#..O.#.#
            ..O..#O..O
            .......O..
            #....###..
            #OO..#....
            """;

    [Fact]
    public static void TestExampleP1()
    {
        var res = Solution14.SolveP1(Example);

        Assert.Equal(136, res);
    }

    [Fact]
    public static void TestP1()
    {
        var res = Solution14.SolveP1(Input14.Data);

        Assert.Equal(109098, res);
    }

    [Fact]
    public static void TestExampleP2()
    {
        var res = Solution14.SolveP2(Example);

        Assert.Equal(64, res);
    }

    [Fact]
    public static void TestP2()
    {
        var res = Solution14.SolveP2(Input14.Data);

        Assert.Equal(100064, res);
    }
}
