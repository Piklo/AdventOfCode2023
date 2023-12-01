using System.Buffers;
using System.Collections.Frozen;

namespace AdventOfCode2023.Day01;

public static class Solution01
{
    private static readonly FrozenDictionary<string, int> Numbers = new Dictionary<string, int>()
    {
        { "0", 0 },
        { "zero", 0 },
        { "1", 1 },
        { "one", 1 },
        { "2", 2 },
        { "two", 2 },
        { "3", 3 },
        { "three", 3 },
        { "4", 4 },
        { "four", 4 },
        { "5", 5 },
        { "five", 5 },
        { "6", 6 },
        { "six", 6 },
        { "7", 7 },
        { "seven", 7 },
        { "8", 8 },
        { "eight", 8 },
        { "9", 9 },
        { "nine", 9 },
    }.ToFrozenDictionary();

    public static int SolveP1(string data)
    {
        var span = data.AsSpan();
        var sum = 0;
        var linesCount = span.Count('\n') + 1;
        var destination = ArrayPool<Range>.Shared.Rent(linesCount);

        try
        {
            ReadOnlySpan<Range> destinationSpan = destination.AsSpan()[..linesCount];
            span.Split(destination, '\n', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);

            foreach (var range in destinationSpan)
            {
                var line = span[range.Start..range.End];
                var firstDigit = 0;
                var lastDigit = 0;

                for (int i = 0; i < line.Length; i++)
                {
                    if (char.IsDigit(line[i]))
                    {
                        firstDigit = line[i] - '0';
                        break;
                    }
                }

                for (int i = line.Length - 1; i >= 0; i--)
                {
                    if (char.IsDigit(line[i]))
                    {
                        lastDigit = line[i] - '0';
                        break;
                    }
                }

                var number = (firstDigit * 10) + lastDigit;
                sum += number;
            }
        }
        finally
        {
            ArrayPool<Range>.Shared.Return(destination);
        }

        return sum;
    }

    public static int SolveP2(string data)
    {
        var span = data.AsSpan();
        var sum = 0;
        var linesCount = span.Count('\n') + 1;
        var destination = ArrayPool<Range>.Shared.Rent(linesCount);

        try
        {
            ReadOnlySpan<Range> destinationSpan = destination.AsSpan()[..linesCount];
            span.Split(destination, '\n', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);

            foreach (var range in destinationSpan)
            {
                var line = span[range.Start..range.End];
                var firstDigit = (Index: int.MaxValue, Value: -1);
                var lastDigit = (Index: int.MinValue, Value: -1);

                foreach (var kv in Numbers)
                {
                    var firstIndex = line.IndexOf(kv.Key);

                    if (firstIndex == -1)
                    {
                        continue;
                    }

                    var lastIndex = line.LastIndexOf(kv.Key);

                    if (firstIndex < firstDigit.Index || firstDigit.Value == -1)
                    {
                        firstDigit = (firstIndex, kv.Value);
                    }

                    if (lastIndex > lastDigit.Index || firstDigit.Value == -1)
                    {
                        lastDigit = (lastIndex, kv.Value);
                    }
                }

                var number = (firstDigit.Value * 10) + lastDigit.Value;
                sum += number;
            }
        }
        finally
        {
            ArrayPool<Range>.Shared.Return(destination);
        }

        return sum;
    }
}
