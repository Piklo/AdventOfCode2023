using AdventOfCode2023.Day10;

namespace AdventOfCode2023.Tests.Day10;

public static class Tests10
{
    [Fact]
    public static void TestExample1P1()
    {
        const string example = """
            .....
            .S-7.
            .|.|.
            .L-J.
            .....
            """;

        var res = Solution10.SolveP1(example);

        Assert.Equal(4, res);
    }

    [Fact]
    public static void TestExample2P1()
    {
        const string example = """
            ..F7.
            .FJ|.
            SJ.L7
            |F--J
            LJ...
            """;

        var res = Solution10.SolveP1(example);

        Assert.Equal(8, res);
    }

    [Fact]
    public static void TestP1()
    {
        var res = Solution10.SolveP1(Input10.Data);

        Assert.Equal(6640, res);
    }

    //[Fact]
    //public static void TestExample1P2()
    //{
    //    const string example = """
    //        ...........
    //        .S-------7.
    //        .|F-----7|.
    //        .||.....||.
    //        .||.....||.
    //        .|L-7.F-J|.
    //        .|..|.|..|.
    //        .L--J.L--J.
    //        ...........
    //        """;

    //    var res = Solution10.SolveP2(example);

    //    Assert.Equal(4, res);
    //}

    //[Fact]
    //public static void TestExample2P2()
    //{
    //    const string example = """
    //        .F----7F7F7F7F-7....
    //        .|F--7||||||||FJ....
    //        .||.FJ||||||||L7....
    //        FJL7L7LJLJ||LJ.L-7..
    //        L--J.L7...LJS7F-7L7.
    //        ....F-J..F7FJ|L7L7L7
    //        ....L7.F7||L7|.L7L7|
    //        .....|FJLJ|FJ|F7|.LJ
    //        ....FJL-7.||.||||...
    //        ....L---J.LJ.LJLJ...
    //        """;

    //    var res = Solution10.SolveP2(example);

    //    Assert.Equal(8, res);
    //}

    //[Fact]
    //public static void TestExample3P2()
    //{
    //    const string example = """
    //        FF7FSF7F7F7F7F7F---7
    //        L|LJ||||||||||||F--J
    //        FL-7LJLJ||||||LJL-77
    //        F--JF--7||LJLJ7F7FJ-
    //        L---JF-JLJ.||-FJLJJ7
    //        |F|F-JF---7F7-L7L|7|
    //        |FFJF7L7F-JF7|JL---7
    //        7-L-JL7||F7|L7F-7F7|
    //        L.L7LFJ|||||FJL7||LJ
    //        L7JLJL-JLJLJL--JLJ.L
    //        """;

    //    var res = Solution10.SolveP2(example);

    //    Assert.Equal(10, res);
    //}
}
