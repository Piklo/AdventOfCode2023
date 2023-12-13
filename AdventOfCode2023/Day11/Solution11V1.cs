namespace AdventOfCode2023.Day11;

public static partial class Solution11
{
    public static int SolveP1(string data)
    {
        var res = 0;

        var universe = ParseInput(data);
        ExpandUniverse(universe);
        var galaxyCoordinates = GetGalaxyCoordinates(universe);

        for (var i = 0; i < galaxyCoordinates.Count; i++)
        {
            var galaxy1 = galaxyCoordinates[i];
            for (var j = i + 1; j < galaxyCoordinates.Count; j++)
            {
                var galaxy2 = galaxyCoordinates[j];
                var iDiff = Math.Abs(galaxy1.I - galaxy2.I);
                var jDiff = Math.Abs(galaxy1.J - galaxy2.J);

                res += iDiff + jDiff;
            }
        }

        return res;
    }

    private static List<List<char>> ParseInput(string data)
    {
        var res = new List<List<char>>();

        var current = new List<char>();

        foreach (var c in data)
        {
            if (c == '\n')
            {
                res.Add(current);
                current = [];
                continue;
            }
            else if (char.IsWhiteSpace(c))
            {
                continue;
            }

            current.Add(c);
        }

        res.Add(current);

        return res;
    }

    private static void ExpandUniverse(List<List<char>> universe)
    {
        for (var i = 0; i < universe.Count; i++)
        {
            var row = universe[i];
            if (row.All(c => c == '.'))
            {
                universe.Insert(i, [.. row]);
                i++;
            }
        }

        for (var i = 0; i < universe[0].Count; i++)
        {
            var emptyColumn = true;
            for (var j = 0; j < universe.Count; j++)
            {
                if (universe[j][i] != '.')
                {
                    emptyColumn = false;
                    break;
                }
            }

            if (!emptyColumn)
            {
                continue;
            }

            for (var j = 0; j < universe.Count; j++)
            {
                universe[j].Insert(i, '.');
            }

            i++;
        }
    }

    private static List<(int I, int J)> GetGalaxyCoordinates(List<List<char>> universe)
    {
        var list = new List<(int, int)>();

        for (var i = 0; i < universe.Count; i++)
        {
            for (var j = 0; j < universe[i].Count; j++)
            {
                if (universe[i][j] == '#')
                {
                    list.Add((i, j));
                }
            }
        }

        return list;
    }
}
