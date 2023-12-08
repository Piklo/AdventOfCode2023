using AdventOfCode2023.Day08;

namespace AdventOfCode2023.Tests.Day08;

public static class Tests08
{
    private const string Example1P1 = """
        RL

        AAA = (BBB, CCC)
        BBB = (DDD, EEE)
        CCC = (ZZZ, GGG)
        DDD = (DDD, DDD)
        EEE = (EEE, EEE)
        GGG = (GGG, GGG)
        ZZZ = (ZZZ, ZZZ)
        """;

    private const string Example2P1 = """
        LLR

        AAA = (BBB, BBB)
        BBB = (AAA, ZZZ)
        ZZZ = (ZZZ, ZZZ)
        """;

    private const string ExampleP2 = """
        LLR

        AAA = (BBB, BBB)
        BBB = (AAA, ZZZ)
        ZZZ = (ZZZ, ZZZ)
        """;

    [Fact]
    public static void TestExample1P1()
    {
        var res = Solution08.SolveP1(Example1P1);

        Assert.Equal(2, res);
    }

    [Fact]
    public static void TestExample2P1()
    {
        var res = Solution08.SolveP1(Example2P1);

        Assert.Equal(6, res);
    }

    [Fact]
    public static void TestP1()
    {
        var res = Solution08.SolveP1(Input08.Data);

        Assert.Equal(21797, res);
    }

    [Fact]
    public static void TestExampleP2()
    {
        var res = Solution08.SolveP2(ExampleP2);

        Assert.Equal(6, res);
    }

    //[Fact]
    //public static void TestP2()
    //{
    //    var res = Solution08.SolveP2(Input08.Data);

    //    Assert.Equal(-1, res);
    //}
}
