using AdventOfCode2023.Day01;

namespace AdventOfCode2023.Tests.Day01;

public sealed class Tests01
{
    [Fact]
    public void TestExampleP1()
    {
        const string example = """
            1abc2
            pqr3stu8vwx
            a1b2c3d4e5f
            treb7uchet
            """;

        var res = Solution01.SolveP1(example);

        Assert.Equal(12 + 38 + 15 + 77, res);
    }

    [Fact]
    public void TestP1()
    {
        var res = Solution01.SolveP1(Input01.Data);

        Assert.Equal(55447, res);
    }

    [Fact]
    public void TestExampleP2()
    {
        const string example = """
            two1nine
            eightwothree
            abcone2threexyz
            xtwone3four
            4nineeightseven2
            zoneight234
            7pqrstsixteen
            """;

        var res = Solution01.SolveP2(example);

        Assert.Equal(29 + 83 + 13 + 24 + 42 + 14 + 76, res);
    }

    [Fact]
    public void TestP2()
    {
        var res = Solution01.SolveP2(Input01.Data);

        Assert.Equal(54706, res);
    }

    [Fact]
    public void TestExampleP2V2()
    {
        const string example = """
            two1nine
            eightwothree
            abcone2threexyz
            xtwone3four
            4nineeightseven2
            zoneight234
            7pqrstsixteen
            """;

        var res = Solution01.SolveP2V2(example);

        Assert.Equal(29 + 83 + 13 + 24 + 42 + 14 + 76, res);
    }

    [Fact]
    public void TestP2V2()
    {
        var res = Solution01.SolveP2V2(Input01.Data);

        Assert.Equal(54706, res);
    }
}
