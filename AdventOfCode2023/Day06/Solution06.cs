using System.Text.RegularExpressions;

namespace AdventOfCode2023.Day06;

public static partial class Solution06
{
    public static long SolveP1(string data)
    {
        var count = 1L;

        var races = GetRaces(data);

        foreach (var race in races)
        {
            var winningWays = GetWinningWays(race);
            count *= winningWays;
        }

        return count;
    }

    public static long SolveP2(string data)
    {
        var race = GetRaceP2(data);

        var count = GetWinningWays(race);

        return count;
    }

    private readonly record struct Race(long Time, long Distance);

    [GeneratedRegex("\\d+")]
    private static partial Regex ValuesRegex();

    private static Race[] GetRaces(ReadOnlySpan<char> data)
    {
        var newlineIndex = data.IndexOf('\n');
        var timesLine = data[..newlineIndex].Trim();
        var distancesLine = data[newlineIndex..].Trim();

        var count = ValuesRegex().Count(timesLine);
        var races = new Race[count];

        var timesEnumerator = ValuesRegex().EnumerateMatches(timesLine);
        var distancesEnumerator = ValuesRegex().EnumerateMatches(distancesLine);
        for (var i = 0; i < count && timesEnumerator.MoveNext() && distancesEnumerator.MoveNext(); i++)
        {
            var time = long.Parse(timesLine[timesEnumerator.Current.Index..(timesEnumerator.Current.Index + timesEnumerator.Current.Length)]);
            var distance = long.Parse(distancesLine[distancesEnumerator.Current.Index..(distancesEnumerator.Current.Index + distancesEnumerator.Current.Length)]);

            races[i] = new Race(time, distance);
        }

        return races;
    }

    private static Race GetRaceP2(ReadOnlySpan<char> data)
    {
        var newlineIndex = data.IndexOf('\n');
        var timesLine = data[..newlineIndex].Trim();
        var distancesLine = data[newlineIndex..].Trim();

        var time = 0L;
        var distance = 0L;

        foreach (var c in timesLine)
        {
            if (c >= '0' && c <= '9')
            {
                time = (time * 10) + c - '0';
            }
        }

        foreach (var c in distancesLine)
        {
            if (c >= '0' && c <= '9')
            {
                distance = (distance * 10) + c - '0';
            }
        }

        var race = new Race(time, distance);
        return race;
    }

    private static long GetWinningWays(Race race)
    {
        var count = 0L;

        for (var i = 1L; i < race.Time; i++)
        {
            // release after i milliseconds
            // speed = i
            var remainingTime = race.Time - i;
            var distanceTravelled = remainingTime * i;
            if (distanceTravelled > race.Distance)
            {
                count++;
            }
        }

        return count;
    }
}
