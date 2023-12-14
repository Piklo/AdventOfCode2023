using AdventOfCode2023.Day12;

namespace AdventOfCode2023.Tests.Day12;

public static class Tests12
{
    private const string Example = """
            ???.### 1,1,3
            .??..??...?##. 1,1,3
            ?#?#?#?#?#?#?#? 1,3,1,6
            ????.#...#... 4,1,1
            ????.######..#####. 1,6,5
            ?###???????? 3,2,1
            """;

    [Fact]
    public static void TestExampleP1()
    {
        var res = Solution12.SolveP1(Example);

        Assert.Equal(21, res);
    }

    [Fact]
    public static void TestP1()
    {
        var res = Solution12.SolveP1(Input12.Data);

        Assert.Equal(7032, res);
    }

    //[Fact]
    //public static void TestExampleP2()
    //{
    //    var res = Solution12.SolveP2(Example);

    //    Assert.Equal(525152, res);
    //}
}
