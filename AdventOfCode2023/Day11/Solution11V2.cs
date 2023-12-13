namespace AdventOfCode2023.Day11;

public static partial class Solution11
{
    public static long SolveP1V2(ReadOnlySpan<char> data)
    {
        var galaxies = ParseInputV2(data);

        ExpandUniverse(galaxies, 2);

        var res = GetDistances(galaxies);

        return res;
    }

    public static long SolveP2(ReadOnlySpan<char> data)
    {
        var galaxies = ParseInputV2(data);

        ExpandUniverse(galaxies, 1_000_000);

        var res = GetDistances(galaxies);

        return res;

        return res;
    }

    private static (long I, long J)[] ParseInputV2(ReadOnlySpan<char> data)
    {
        var list = new List<(long, long)>(data.Count('#'));
        var i = 0;
        var j = 0;
        foreach (var c in data)
        {
            if (c == '\n')
            {
                i++;
                j = 0;
            }

            if (char.IsWhiteSpace(c))
            {
                continue;
            }

            if (c == '#')
            {
                list.Add((i, j));
            }

            j++;
        }

        return list.ToArray();
    }

    private static void ExpandUniverse((long I, long J)[] galaxies, int timesLarger)
    {
        var minI = galaxies.Select(galaxy => galaxy.I).Min();
        var maxI = galaxies.Select(galaxy => galaxy.I).Max();

        timesLarger--; // minus 1 because we are just incrementing the values, so we already have "1 time"

        Expand(galaxies, timesLarger, 0); // expand i
        Expand(galaxies, timesLarger, 1); // expand j
    }

    private static void Expand((long I, long J)[] galaxies, int timesLarger, int index)
    {
        var min = galaxies.Select(galaxy => GetByIndex(galaxy, index)).Min();
        var max = galaxies.Select(galaxy => GetByIndex(galaxy, index)).Max();

        for (var i = min + 1; i < max; i++)
        {
            if (galaxies.Any(galaxy => GetByIndex(galaxy, index) == i))
            {
                continue;
            }

            for (var j = 0; j < galaxies.Length; j++)
            {
                ref var galaxy = ref galaxies[j];
                if (GetByIndex(galaxy, index) > i)
                {
                    SetByIndex(ref galaxy, index, GetByIndex(galaxy, index) + timesLarger);

                    max = Math.Max(max, GetByIndex(galaxy, index));
                }
            }

            i += timesLarger;
        }
    }

    private static long GetByIndex((long I, long J) galaxy, int index)
    {
        if (index == 0)
        {
            return galaxy.I;
        }
        else if (index == 1)
        {
            return galaxy.J;
        }
        else
        {
            throw new Exception($"unknown index = {index}");
        }
    }

    private static void SetByIndex(ref (long I, long J) galaxy, int index, long value)
    {
        if (index == 0)
        {
            galaxy.I = value;
        }
        else if (index == 1)
        {
            galaxy.J = value;
        }
        else
        {
            throw new Exception($"unknown index = {index}");
        }
    }

    private static long GetDistances((long I, long J)[] galaxyCoordinates)
    {
        var res = 0L;

        for (var i = 0; i < galaxyCoordinates.Length; i++)
        {
            var galaxy1 = galaxyCoordinates[i];
            for (var j = i + 1; j < galaxyCoordinates.Length; j++)
            {
                var galaxy2 = galaxyCoordinates[j];
                var iDiff = Math.Abs(galaxy1.I - galaxy2.I);
                var jDiff = Math.Abs(galaxy1.J - galaxy2.J);

                res += iDiff + jDiff;
            }
        }

        return res;
    }
}