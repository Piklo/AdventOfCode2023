namespace AdventOfCode2023.Day14;

public static class Solution14
{
    public static int SolveP1(string data)
    {
        var rocks = ParseInput(data);

        while (TiltNorth(rocks))
        {
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

    private static bool TiltNorth(char[][] rocks)
    {
        var movedSomething = false;

        for (var i = 1; i < rocks.Length; i++)
        {
            for (var j = 0; j < rocks[i].Length; j++)
            {
                if (rocks[i][j] == 'O' && rocks[i - 1][j] == '.')
                {
                    rocks[i - 1][j] = 'O';
                    rocks[i][j] = '.';
                    movedSomething = true;
                }
            }
        }

        return movedSomething;
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
}
