namespace AdventOfCode2023.Day05;

public static class Solution05
{
    public static long SolveP1(string data)
    {
        var minLocation = long.MaxValue;
        var garden = new Garden(data);
        foreach (var seed in garden.SeedValues)
        {
            var location = garden.GetLocation(seed);
            minLocation = Math.Min(minLocation, location);
        }

        return minLocation;
    }

    public static long SolveP2(string data)
    {
        var minLocation = long.MaxValue;
        var garden = new Garden(data);
        for (var i = 0; i < garden.SeedValues.Length; i += 2)
        {
            var seedStart = garden.SeedValues[i];
            var length = garden.SeedValues[i + 1];

            for (var j = 0; j < length; j++)
            {
                var location = garden.GetLocation(seedStart + j);
                minLocation = Math.Min(minLocation, location);
            }
        }

        return minLocation;
    }
}
