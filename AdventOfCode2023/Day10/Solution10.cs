namespace AdventOfCode2023.Day10;

public static class Solution10
{
    public static int SolveP1(string data)
    {
        var lines = data.Split('\n', StringSplitOptions.TrimEntries);

        var (i, j) = GetStartingPosition(lines);

        _ = IsLooped(lines, i, j, i - 1, j, out var length) // north
           || IsLooped(lines, i, j, i + 1, j, out length) // south
           || IsLooped(lines, i, j, i, j + 1, out length) // east
           || IsLooped(lines, i, j, i, j - 1, out length); // west

        return length / 2;
    }

    private static (int I, int J) GetStartingPosition(ReadOnlySpan<string> lines)
    {
        for (var i = 0; i < lines.Length; i++)
        {
            var line = lines[i];
            var index = line.IndexOf('S');

            if (index == -1)
            {
                continue;
            }

            return (i, index);
        }

        return (-1, -1);
    }

    private static bool IsLooped(ReadOnlySpan<string> lines, int startingI, int startingJ, int newI, int newJ, out int length)
    {
        var previousI = startingI;
        var previousJ = startingJ;
        var steps = 0;

        while (newI != startingI || newJ != startingJ)
        {
            var currentI = newI;
            var currentJ = newJ;

            if (!MoveNext(lines, previousI, previousJ, currentI, currentJ, out newI, out newJ))
            {
                // not connected anywhere but to the previous point, therefore there is no loop
                length = default;
                return false;
            }

            previousI = currentI;
            previousJ = currentJ;
            steps++;
        }

        length = steps + 1;
        return true;
    }

    private static bool MoveNext(ReadOnlySpan<string> lines, int previousI, int previousJ, int currentI, int currentJ, out int newI, out int newJ)
    {
        if (currentI - 1 != previousI && IsConnectedNorth(lines, currentI, currentJ))
        {
            newI = currentI - 1;
            newJ = currentJ;
            return true;
        }
        else if (currentI + 1 != previousI && IsConnectedSouth(lines, currentI, currentJ))
        {
            newI = currentI + 1;
            newJ = currentJ;
            return true;
        }
        else if (currentJ - 1 != previousJ && IsConnectedWest(lines, currentI, currentJ))
        {
            newI = currentI;
            newJ = currentJ - 1;
            return true;
        }
        else if (currentJ + 1 != previousJ && IsConnectedEast(lines, currentI, currentJ))
        {
            newI = currentI;
            newJ = currentJ + 1;
            return true;
        }
        else
        {
            newI = default;
            newJ = default;
            return false;
        }
    }

    private static bool IsConnectedNorth(ReadOnlySpan<string> lines, int i, int j)
    {
        return ConnectsNorth(lines, i, j) && ConnectsSouth(lines, i - 1, j);
    }

    private static bool IsConnectedEast(ReadOnlySpan<string> lines, int i, int j)
    {
        return ConnectsEast(lines, i, j) && ConnectsWest(lines, i, j + 1);
    }

    private static bool IsConnectedSouth(ReadOnlySpan<string> lines, int i, int j)
    {
        return ConnectsSouth(lines, i, j) && ConnectsNorth(lines, i + 1, j);
    }

    private static bool IsConnectedWest(ReadOnlySpan<string> lines, int i, int j)
    {
        return ConnectsWest(lines, i, j) && ConnectsEast(lines, i, j - 1);
    }

    private static bool ConnectsNorth(ReadOnlySpan<string> lines, int i, int j)
    {
        if (!IsInbounds(lines, i, j))
        {
            return false;
        }

        var tile = lines[i][j];

        return tile is 'S' or '|' or 'L' or 'J';
    }

    private static bool ConnectsEast(ReadOnlySpan<string> lines, int i, int j)
    {
        if (!IsInbounds(lines, i, j))
        {
            return false;
        }

        var tile = lines[i][j];

        return tile is 'S' or '-' or 'L' or 'F';
    }

    private static bool ConnectsSouth(ReadOnlySpan<string> lines, int i, int j)
    {
        if (!IsInbounds(lines, i, j))
        {
            return false;
        }

        var tile = lines[i][j];

        return tile is 'S' or '|' or '7' or 'F';
    }

    private static bool ConnectsWest(ReadOnlySpan<string> lines, int i, int j)
    {
        if (!IsInbounds(lines, i, j))
        {
            return false;
        }

        var tile = lines[i][j];

        return tile is 'S' or '-' or 'J' or '7';
    }

    private static bool IsInbounds(ReadOnlySpan<string> lines, int i, int j)
    {
        if (i < 0 || j < 0 || i >= lines.Length || j >= lines[i].Length)
        {
            return false;
        }

        return true;
    }
}