namespace AdventOfCode2023.Day13;

public static class Solution13
{
    public static int SolveP1(string data)
    {
        var res = 0;
        ReadOnlySpan<string> remainingLines = data.Split('\n', StringSplitOptions.TrimEntries);

        while (remainingLines.Length != 0)
        {
            var patternLinesCount = remainingLines.IndexOf(string.Empty);
            if (patternLinesCount == -1)
            {
                patternLinesCount = remainingLines.Length;
            }

            var subspan = remainingLines[..patternLinesCount];
            var horizontalLines = GetHorizontalReflectionLines(subspan);
            var verticalLines = GetVerticalReflectionLines(subspan);

            foreach (var line in horizontalLines)
            {
                res += line.Line1 + 1;
            }

            foreach (var line in verticalLines)
            {
                res += 100 * (line.Line1 + 1);
            }

            if (horizontalLines.Count > 1 || verticalLines.Count > 1)
            {
            }

            if (patternLinesCount != remainingLines.Length)
            {
                remainingLines = remainingLines[(patternLinesCount + 1)..];
            }
            else
            {
                remainingLines = ReadOnlySpan<string>.Empty;
            }
        }

        return res;
    }

    private static List<(int Line1, int Line2)> GetHorizontalReflectionLines(ReadOnlySpan<string> pattern)
    {
        var reflectionLines = new List<(int, int)>();

        for (var i = 0; i < pattern[0].Length - 1; i++)
        {
            if (IsHorizontalLineOfReflection(pattern, i, i + 1))
            {
                reflectionLines.Add((i, i + 1));
            }
        }

        return reflectionLines;
    }

    private static bool IsHorizontalLineOfReflection(ReadOnlySpan<string> pattern, int index1, int index2)
    {
        for (var j = 0; index1 - j >= 0 && index2 + j < pattern[0].Length; j++)
        {
            var column1 = index1 - j;
            var column2 = index2 + j;
            var areEqual = ColumnsEqual(pattern, column1, column2);
            if (!areEqual)
            {
                return false;
            }
        }

        return true;
    }

    private static bool ColumnsEqual(ReadOnlySpan<string> pattern, int column1, int column2)
    {
        for (var i = 0; i < pattern.Length; i++)
        {
            if (pattern[i][column1] != pattern[i][column2])
            {
                return false;
            }
        }

        return true;
    }

    private static List<(int Line1, int Line2)> GetVerticalReflectionLines(ReadOnlySpan<string> pattern)
    {
        var reflectionLines = new List<(int, int)>();

        for (var i = 0; i < pattern.Length - 1; i++)
        {
            if (i + 1 < pattern.Length && IsVerticalLineOfReflection(pattern, i, i + 1))
            {
                reflectionLines.Add((i, i + 1));
            }
        }

        return reflectionLines;
    }

    private static bool IsVerticalLineOfReflection(ReadOnlySpan<string> pattern, int line1, int line2)
    {
        for (var j = 0; line1 - j >= 0 && line2 + j < pattern.Length; j++)
        {
            var row1 = line1 - j;
            var row2 = line2 + j;
            var areEqual = pattern[row1].SequenceEqual(pattern[row2]);
            if (!areEqual)
            {
                return false;
            }
        }

        return true;
    }
}
