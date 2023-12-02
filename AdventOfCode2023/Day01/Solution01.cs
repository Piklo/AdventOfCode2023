using System.Buffers;
using System.Collections.Frozen;

namespace AdventOfCode2023.Day01;

public static class Solution01
{
    private const string Zero = "zero";
    private const string One = "one";
    private const string Two = "two";
    private const string Three = "three";
    private const string Four = "four";
    private const string Five = "five";
    private const string Six = "six";
    private const string Seven = "seven";
    private const string Eight = "eight";
    private const string Nine = "nine";

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

    public static int SolveP1(ReadOnlySpan<char> data)
    {
        var sum = 0;
        var linesCount = data.Count('\n') + 1;
        var destination = ArrayPool<Range>.Shared.Rent(linesCount);

        try
        {
            ReadOnlySpan<Range> destinationSpan = destination.AsSpan()[..linesCount];
            data.Split(destination, '\n', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);

            foreach (var range in destinationSpan)
            {
                var line = data[range.Start..range.End];
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

    public static int SolveP2(ReadOnlySpan<char> data)
    {
        var sum = 0;
        var linesCount = data.Count('\n') + 1;
        var destination = ArrayPool<Range>.Shared.Rent(linesCount);

        try
        {
            ReadOnlySpan<Range> destinationSpan = destination.AsSpan()[..linesCount];
            data.Split(destination, '\n', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);

            foreach (var range in destinationSpan)
            {
                var line = data[range.Start..range.End];
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

    public static int SolveP2V2(ReadOnlySpan<char> data)
    {
        var sum = 0;
        var linesCount = data.Count('\n') + 1;
        var destination = ArrayPool<Range>.Shared.Rent(linesCount);

        try
        {
            ReadOnlySpan<Range> destinationSpan = destination.AsSpan()[..linesCount];
            data.Split(destination, '\n', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);

            foreach (var range in destinationSpan)
            {
                var line = data[range.Start..range.End];
                var firstDigit = FindFirstNumer(line);
                var lastDigit = FindLastNumer(line);

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

    public static int FindFirstNumer(ReadOnlySpan<char> data)
    {
        while (data.Length > 0)
        {
            var firstChar = data[0];
            if (firstChar >= '0' && firstChar <= '9')
            {
                return firstChar - '0';
            }
            else if (data.Length >= Zero.Length && data[..Zero.Length].SequenceEqual(Zero))
            {
                return 0;
            }
            else if (data.Length >= One.Length && data[..One.Length].SequenceEqual(One))
            {
                return 1;
            }
            else if (data.Length >= Two.Length && data[..Two.Length].SequenceEqual(Two))
            {
                return 2;
            }
            else if (data.Length >= Three.Length && data[..Three.Length].SequenceEqual(Three))
            {
                return 3;
            }
            else if (data.Length >= Four.Length && data[..Four.Length].SequenceEqual(Four))
            {
                return 4;
            }
            else if (data.Length >= Five.Length && data[..Five.Length].SequenceEqual(Five))
            {
                return 5;
            }
            else if (data.Length >= Six.Length && data[..Six.Length].SequenceEqual(Six))
            {
                return 6;
            }
            else if (data.Length >= Seven.Length && data[..Seven.Length].SequenceEqual(Seven))
            {
                return 7;
            }
            else if (data.Length >= Eight.Length && data[..Eight.Length].SequenceEqual(Eight))
            {
                return 8;
            }
            else if (data.Length >= Nine.Length && data[..Nine.Length].SequenceEqual(Nine))
            {
                return 9;
            }

            data = data[1..];
        }

        return -1;
    }

    public static int FindLastNumer(ReadOnlySpan<char> data)
    {
        while (data.Length > 0)
        {
            var firstChar = data[^1];
            if (firstChar >= '0' && firstChar <= '9')
            {
                return firstChar - '0';
            }
            else if (data.Length >= Zero.Length && data[(data.Length - Zero.Length)..].SequenceEqual(Zero))
            {
                return 0;
            }
            else if (data.Length >= One.Length && data[(data.Length - One.Length)..].SequenceEqual(One))
            {
                return 1;
            }
            else if (data.Length >= Two.Length && data[(data.Length - Two.Length)..].SequenceEqual(Two))
            {
                return 2;
            }
            else if (data.Length >= Three.Length && data[(data.Length - Three.Length)..].SequenceEqual(Three))
            {
                return 3;
            }
            else if (data.Length >= Four.Length && data[(data.Length - Four.Length)..].SequenceEqual(Four))
            {
                return 4;
            }
            else if (data.Length >= Five.Length && data[(data.Length - Five.Length)..].SequenceEqual(Five))
            {
                return 5;
            }
            else if (data.Length >= Six.Length && data[(data.Length - Six.Length)..].SequenceEqual(Six))
            {
                return 6;
            }
            else if (data.Length >= Seven.Length && data[(data.Length - Seven.Length)..].SequenceEqual(Seven))
            {
                return 7;
            }
            else if (data.Length >= Eight.Length && data[(data.Length - Eight.Length)..].SequenceEqual(Eight))
            {
                return 8;
            }
            else if (data.Length >= Nine.Length && data[(data.Length - Nine.Length)..].SequenceEqual(Nine))
            {
                return 9;
            }

            data = data[..(data.Length - 1)];
        }

        return -1;
    }
}
