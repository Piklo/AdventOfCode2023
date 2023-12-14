using System.Text;
using System.Text.RegularExpressions;

namespace AdventOfCode2023.Day12;

public static partial class Solution12
{
    public static int SolveP1(string data)
    {
        var res = 0;

        var lines = data.Split('\n', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);

        foreach (var line in lines)
        {
            var lineCount = GetLineArrangementsCount(line);
            res += lineCount;
        }

        return res;
    }

    public static int SolveP2(string data)
    {
        var res = 0;

        var lines = data.Split('\n', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);

        foreach (var line in lines)
        {
            var lineCount = GetLineArrangementsCount(Unfold(line));
            res += lineCount;
        }

        return res;
    }

    private static int GetLineArrangementsCount(string line)
    {
        var parts = line.Split(' ');
        var springConditions = parts[0];
        var groups = parts[1].Split(',').Select(int.Parse).ToArray();

        var springsArray = springConditions.ToCharArray();

        var count = ModifyArray(springsArray, groups);

        return count;
    }

    private static int ModifyArray(char[] springs, int[] groups, int index = 0)
    {
        if (index >= springs.Length)
        {
            if (IsLegal(springs, groups))
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        if (springs[index] != '?')
        {
            return ModifyArray(springs, groups, index + 1);
        }

        var count = 0;

        springs[index] = '#';
        count += ModifyArray(springs, groups, index + 1);
        springs[index] = '.';
        count += ModifyArray(springs, groups, index + 1);
        springs[index] = '?';

        return count;
    }

    private static bool IsLegal(char[] springs, int[] groups)
    {
        var matches = GetSpringGroups().EnumerateMatches(springs);
        var index = 0;
        foreach (var match in matches)
        {
            if (index >= groups.Length || match.Length != groups[index])
            {
                return false;
            }

            index++;
        }

        if (index != groups.Length)
        {
            return false;
        }

        return true;
    }

    [GeneratedRegex("#+")]
    private static partial Regex GetSpringGroups();

    private static string Unfold(string s)
    {
        var builder = new StringBuilder();

        var parts = s.Split(' ');
        var springConditions = parts[0];
        var groups = parts[1];

        for (var i = 0; i < 5; i++)
        {
            builder.Append(springConditions);
            builder.Append('?');
        }

        builder.Remove(builder.Length - 1, 1); // remove last question mark

        builder.Append(' ');

        for (var i = 0; i < 5; i++)
        {
            builder.Append(groups);
            builder.Append(',');
        }

        builder.Remove(builder.Length - 1, 1); // remove last comma

        var str = builder.ToString();

        return str;
    }
}
