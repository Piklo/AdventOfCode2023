using System.Buffers;

namespace AdventOfCode2023.Day02;

public static class Solution02
{
    public static int SolveP1(ReadOnlySpan<char> data, int maxRed, int maxGreen, int maxBlue)
    {
        var res = 0;

        var linesCount = data.Count('\n') + 1;
        var destination = ArrayPool<Range>.Shared.Rent(linesCount);

        try
        {
            ReadOnlySpan<Range> ranges = destination.AsSpan()[..linesCount];
            data.Split(destination, '\n', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);

            foreach (var range in ranges)
            {
                var line = data[range.Start..range.End];

                var game = ParseGameP1(line);

                if (game.MaxRed <= maxRed && game.MaxGreen <= maxGreen && game.MaxBlue <= maxBlue)
                {
                    res += game.Id;
                }
            }
        }
        finally
        {
            ArrayPool<Range>.Shared.Return(destination);
        }

        return res;
    }

    private static (int Id, int MaxRed, int MaxGreen, int MaxBlue) ParseGameP1(ReadOnlySpan<char> game)
    {
        var colonIndex = game.IndexOf(':');
        var id = int.Parse(game["Game ".Length..game.IndexOf(':')]);
        game = game[(colonIndex + 2)..];

        var maxRed = 0;
        var maxGreen = 0;
        var maxBlue = 0;

        var setsCount = game.Count(';') + 1;
        var setsArray = ArrayPool<Range>.Shared.Rent(setsCount);

        try
        {
            ReadOnlySpan<Range> setRanges = setsArray.AsSpan()[..setsCount];
            game.Split(setsArray, ';', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);

            foreach (var setRange in setRanges)
            {
                var set = game[setRange.Start..setRange.End];
                var valuesCount = set.Count(',') + 1;
                var valuesArray = ArrayPool<Range>.Shared.Rent(valuesCount);

                try
                {
                    ReadOnlySpan<Range> valueRanges = valuesArray.AsSpan()[..valuesCount];
                    set.Split(valuesArray, ',', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);

                    foreach (var valueRange in valueRanges)
                    {
                        var valueSpan = set[valueRange.Start..valueRange.End];
                        var spaceIndex = valueSpan.IndexOf(' ');
                        var value = int.Parse(valueSpan[..spaceIndex]);
                        var color = valueSpan[(spaceIndex + 1)..];
                        if (color.SequenceEqual("red") && maxRed < value)
                        {
                            maxRed = value;
                        }
                        else if (color.SequenceEqual("green") && maxGreen < value)
                        {
                            maxGreen = value;
                        }
                        else if (color.SequenceEqual("blue") && maxBlue < value)
                        {
                            maxBlue = value;
                        }
                    }
                }
                finally
                {
                    ArrayPool<Range>.Shared.Return(valuesArray);
                }
            }
        }
        finally
        {
            ArrayPool<Range>.Shared.Return(setsArray);
        }

        return (id, maxRed, maxGreen, maxBlue);
    }

    public static int SolveP2(ReadOnlySpan<char> data)
    {
        var res = 0;

        var linesCount = data.Count('\n') + 1;
        var destination = ArrayPool<Range>.Shared.Rent(linesCount);

        try
        {
            ReadOnlySpan<Range> ranges = destination.AsSpan()[..linesCount];
            data.Split(destination, '\n', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);

            foreach (var range in ranges)
            {
                var line = data[range.Start..range.End];
                var game = ParseGameP1(line);
                var multiplied = game.MaxRed * game.MaxBlue * game.MaxGreen;
                res += multiplied;
            }
        }
        finally
        {
            ArrayPool<Range>.Shared.Return(destination);
        }

        return res;
    }
}
