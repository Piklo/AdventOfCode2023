using System.Diagnostics.CodeAnalysis;

namespace AdventOfCode2023.Day14;

public static class Solution14
{
    public static int SolveP1(string data)
    {
        var rocks = ParseInput(data);

        TiltNorth(rocks);

        var res = CountLoad(rocks);

        return res;
    }

    public static int SolveP2(string data)
    {
        const int cycles = 1_000_000_000;
        var rocks = ParseInput(data);
        var cache = new Dictionary<int, char[][]>();
        var comparer = new CustomComparer();
        var set = new HashSet<char[][]>(comparer);

        for (var i = 0; i < cycles; i++)
        {
            if (set.Contains(rocks))
            {
                foreach (var (k, v) in cache)
                {
                    if (comparer.Equals(rocks, v))
                    {
                        var loopLength = i - k;
                        var endOfTheLoop = ((cycles - i) / loopLength * loopLength) + i;

                        var missingCycles = cycles - endOfTheLoop;
                        var key = k + missingCycles;

                        var valueAtTheEnd = cache[key];
                        var load = CountLoad(valueAtTheEnd);
                        return load;
                    }
                }
            }

            var pre = Copy(rocks);
            set.Add(pre);
            cache.Add(i, pre);

            TiltNorth(rocks);
            TiltWest(rocks);
            TiltSouth(rocks);
            TiltEast(rocks);
        }

        var res = CountLoad(rocks);

        return res;
    }

    private static char[][] ParseInput(string data)
    {
        var lines = data.Split('\n', StringSplitOptions.TrimEntries);
        var rocks = new char[lines.Length][];
        for (var i = 0; i < lines.Length; i++)
        {
            var line = lines[i];
            rocks[i] = line.ToCharArray();
        }

        return rocks;
    }

    private static void TiltNorth(char[][] rocks)
    {
        for (var column = 0; column < rocks[0].Length; column++)
        {
            var top = 0;
            var bottom = 0;
            while (top < rocks.Length && bottom < rocks.Length)
            {
                while (top < rocks.Length && rocks[top][column] != '.')
                {
                    top++;
                }

                if (bottom <= top)
                {
                    bottom = top + 1;
                }

                if (top >= rocks.Length || bottom >= rocks.Length)
                {
                    break;
                }

                if (rocks[bottom][column] == 'O')
                {
                    rocks[top][column] = 'O';
                    rocks[bottom][column] = '.';
                }
                else if (rocks[bottom][column] == '#')
                {
                    top = bottom + 1;
                }

                bottom++;
            }
        }
    }

    private static void TiltSouth(char[][] rocks)
    {
        for (var column = 0; column < rocks[0].Length; column++)
        {
            var top = rocks.Length - 1;
            var bottom = rocks.Length - 1;
            while (bottom >= 0 && top >= 0)
            {
                while (bottom >= 0 && rocks[bottom][column] != '.')
                {
                    bottom--;
                }

                if (bottom <= top)
                {
                    top = bottom - 1;
                }

                if (bottom < 0 || top < 0)
                {
                    break;
                }

                if (rocks[top][column] == 'O')
                {
                    rocks[bottom][column] = 'O';
                    rocks[top][column] = '.';
                }
                else if (rocks[top][column] == '#')
                {
                    bottom = top - 1;
                }

                top--;
            }
        }
    }

    private static void TiltWest(char[][] rocks)
    {
        for (var row = 0; row < rocks[0].Length; row++)
        {
            var left = 0;
            var right = 0;
            while (left < rocks.Length && right < rocks.Length)
            {
                while (left < rocks.Length && rocks[row][left] != '.')
                {
                    left++;
                }

                if (right <= left)
                {
                    right = left + 1;
                }

                if (left >= rocks.Length || right >= rocks.Length)
                {
                    break;
                }

                if (rocks[row][right] == 'O')
                {
                    rocks[row][left] = 'O';
                    rocks[row][right] = '.';
                }
                else if (rocks[row][right] == '#')
                {
                    left = right + 1;
                }

                right++;
            }
        }
    }

    private static void TiltEast(char[][] rocks)
    {
        for (var row = 0; row < rocks[0].Length; row++)
        {
            var left = rocks.Length - 1;
            var right = rocks.Length - 1;
            while (left >= 0 && right >= 0)
            {
                while (left >= 0 && rocks[row][left] != '.')
                {
                    left--;
                }

                if (left <= right)
                {
                    right = left - 1;
                }

                if (left < 0 || right < 0)
                {
                    break;
                }

                if (rocks[row][right] == 'O')
                {
                    rocks[row][left] = 'O';
                    rocks[row][right] = '.';
                }
                else if (rocks[row][right] == '#')
                {
                    left = right - 1;
                }

                right--;
            }
        }
    }

    private static int CountLoad(char[][] rocks)
    {
        var load = 0;

        for (var i = 0; i < rocks.Length; i++)
        {
            var weight = rocks.Length - i;
            for (var j = 0; j < rocks[i].Length; j++)
            {
                if (rocks[i][j] == 'O')
                {
                    load += weight;
                }
            }
        }

        return load;
    }

    private static char[][] Copy(char[][] array)
    {
        var array2 = new char[array.Length][];

        for (var i = 0; i < array.Length; i++)
        {
            array2[i] = [.. array[i]];
        }

        return array2;
    }

    private class CustomComparer : IEqualityComparer<char[][]>
    {
        public bool Equals(char[][]? x, char[][]? y)
        {
            if (x is null && y is null)
            {
                return true;
            }

            if (x is null || y is null || x.Length != y.Length)
            {
                return false;
            }

            for (var i = 0; i < x.Length; i++)
            {
                if (!x[i].SequenceEqual(y[i]))
                {
                    return false;
                }
            }

            return true;
        }

        public int GetHashCode([DisallowNull] char[][] obj)
        {
            var hashcode = default(HashCode);

            foreach (var array in obj)
            {
                foreach (var item in array)
                {
                    hashcode.Add(item);
                }
            }

            var code = hashcode.ToHashCode();

            return code;
        }
    }
}
