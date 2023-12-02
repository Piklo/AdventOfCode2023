using AdventOfCode2023.Day02;

namespace AdventOfCode2023.Tests.Day02;

public sealed class Tests02
{
    [Fact]
    public void TestExampleP1()
    {
        const string input = """
            Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green
            Game 2: 1 blue, 2 green; 3 green, 4 blue, 1 red; 1 green, 1 blue
            Game 3: 8 green, 6 blue, 20 red; 5 blue, 4 red, 13 green; 5 green, 1 red
            Game 4: 1 green, 3 red, 6 blue; 3 green, 6 red; 3 green, 15 blue, 14 red
            Game 5: 6 red, 1 blue, 3 green; 2 blue, 1 red, 2 green
            """;

        var res = Solution02.SolveP1(input, 12, 13, 14);

        Assert.Equal(8, res);
    }

    [Fact]
    public void TestP1()
    {
        var res = Solution02.SolveP1(Input02.Data, 12, 13, 14);

        Assert.Equal(2447, res);
    }

    [Fact]
    public void TestExampleP2()
    {
        const string input = """
            Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green
            Game 2: 1 blue, 2 green; 3 green, 4 blue, 1 red; 1 green, 1 blue
            Game 3: 8 green, 6 blue, 20 red; 5 blue, 4 red, 13 green; 5 green, 1 red
            Game 4: 1 green, 3 red, 6 blue; 3 green, 6 red; 3 green, 15 blue, 14 red
            Game 5: 6 red, 1 blue, 3 green; 2 blue, 1 red, 2 green
            """;

        var res = Solution02.SolveP2(input);

        Assert.Equal(48 + 12 + 1560 + 630 + 36, res);
    }

    [Fact]
    public void TestP2()
    {
        var res = Solution02.SolveP2(Input02.Data);

        Assert.Equal(56322, res);
    }
}
