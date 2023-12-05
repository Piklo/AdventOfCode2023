using System.Text.RegularExpressions;

namespace AdventOfCode2023.Day05;

public static partial class Solution05
{
    public static int SolveP1(string data)
    {
        var res = 0;
        var seeds = GetSeeds(data);
        var seedsToSoil = GetSeedToSoilMap(data);
        return res;
    }

    private static int[] GetSeeds(string data)
    {
        var match = GetSeedsRegex().Matches(data);
        var seeds = new int[match.Count];

        for (var i = 0; i < match.Count; i++)
        {
            var seed = int.Parse(match[i].Value);
            seeds[i] = seed;
        }

        return seeds;
    }

    private static Dictionary<int, int> GetSeedToSoilMap(string data)
    {
        var dict = new Dictionary<int, int>();
        var matches = GetSeedToSoilRegex().Matches(data);
        foreach (var match in (IEnumerable<Match>)matches)
        {
            var destination = int.Parse(match.Groups["destination"].ValueSpan);
            var source = int.Parse(match.Groups["source"].ValueSpan);
            var range = int.Parse(match.Groups["range"].ValueSpan);
            for (var i = 0; i < range; i++)
            {
                dict[source + i] = destination + i;
            }
        }

        return dict;
    }

    [GeneratedRegex("(?<=seeds:.*)\\d+")]
    private static partial Regex GetSeedsRegex();

    // copy and paste this regex for other maps
    [GeneratedRegex("(?<=seed-to-soil map:\\s+.*\\s?)^\\s?(?<destination>\\d+).(?<source>\\d+).(?<range>\\d+)\\s?$", RegexOptions.Multiline)]
    private static partial Regex GetSeedToSoilRegex();
}
