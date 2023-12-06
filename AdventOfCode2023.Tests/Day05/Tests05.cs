using AdventOfCode2023.Day05;

namespace AdventOfCode2023.Tests.Day05;

public static class Tests05
{
    private const string Example = """
        seeds: 79 14 55 13

        seed-to-soil map:
        50 98 2
        52 50 48

        soil-to-fertilizer map:
        0 15 37
        37 52 2
        39 0 15

        fertilizer-to-water map:
        49 53 8
        0 11 42
        42 0 7
        57 7 4

        water-to-light map:
        88 18 7
        18 25 70

        light-to-temperature map:
        45 77 23
        81 45 19
        68 64 13

        temperature-to-humidity map:
        0 69 1
        1 0 69

        humidity-to-location map:
        60 56 37
        56 93 4
        """;

    [Fact]
    public static void TestExampleP1()
    {
        var res = Solution05.SolveP1(Example);

        Assert.Equal(35, res);
    }

    [Fact]
    public static void TestP1()
    {
        var res = Solution05.SolveP1(Input05.Data);

        Assert.Equal(462648396, res);
    }

    [Fact]
    public static void TestExampleP2()
    {
        var res = Solution05.SolveP2(Example);

        Assert.Equal(46, res);
    }

    //[Fact]
    //public static void TestP2()
    //{
    //    var res = Solution05.SolveP2(Input05.Data);

    //    Assert.Equal(-1, res);
    //}
}
