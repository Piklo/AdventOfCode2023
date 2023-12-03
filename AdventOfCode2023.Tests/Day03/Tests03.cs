using AdventOfCode2023.Day03;

namespace AdventOfCode2023.Tests.Day03;

public sealed class Tests03
{
    private const string ExampleInput = """
            467..114..
            ...*......
            ..35..633.
            ......#...
            617*......
            .....+.58.
            ..592.....
            ......755.
            ...$.*....
            .664.598..
            """;

    [Fact]
    public void TestExampleP1()
    {
        var res = Solution03.SolveP1(ExampleInput);

        Assert.Equal(4361, res);
    }

    [Fact]
    public void TestP1()
    {
        var res = Solution03.SolveP1(Input03.Data);

        Assert.Equal(539433, res);
    }

    [Fact]
    public void TestExampleP2()
    {
        var res = Solution03.SolveP2(ExampleInput);

        Assert.Equal(467835, res);
    }

    [Fact]
    public void TestP2()
    {
        var res = Solution03.SolveP2(Input03.Data);

        Assert.Equal(75847567, res);
    }
}
