using System.Text.RegularExpressions;

namespace AdventOfCode2023.Day08;

public static partial class Solution08
{
    public static int SolveP1(string data)
    {
        var steps = 0;
        var map = new Map(data);
        var dictionary = new Dictionary<string, Node>();

        foreach (var node in map.Nodes)
        {
            dictionary[node.Value] = node;
        }

        var current = dictionary["AAA"];
        var last = dictionary["ZZZ"];

        var sequenceIndex = 0;
        while (current != last)
        {
            var instruction = map.Instruction[sequenceIndex];

            current = dictionary[instruction == 'L' ? current.Left : current.Right];

            steps++;
            sequenceIndex++;
            if (sequenceIndex >= map.Instruction.Length)
            {
                sequenceIndex = 0;
            }
        }

        return steps;
    }

    public static long SolveP2(string data)
    {
        var map = new Map(data);
        var dictionary = new Dictionary<string, Node>();

        foreach (var node in map.Nodes)
        {
            dictionary[node.Value] = node;
        }

        var current = map.Nodes.Where(node => node.Value[^1] == 'A').ToArray().AsSpan();
        Span<int> loopLengths = current.Length <= 1024 ? stackalloc int[current.Length] : new int[current.Length];

        for (var i = 0; i < current.Length; i++)
        {
            var node = current[i];
            var loopLength = 0;
            var sequenceIndex = 0;
            while (node.Value[^1] != 'Z')
            {
                var instruction = map.Instruction[sequenceIndex];

                node = dictionary[instruction == 'L' ? node.Left : node.Right];

                loopLength++;
                sequenceIndex++;
                if (sequenceIndex >= map.Instruction.Length)
                {
                    sequenceIndex = 0;
                }
            }

            loopLengths[i] = loopLength;
        }

        var primeFactors = new Dictionary<int, int>(current.Length);
        foreach (var loopLength in loopLengths)
        {
            var factors = GetPrimeFactors(loopLength);

            foreach (var (number, count) in factors)
            {
                if (!primeFactors.TryGetValue(number, out var currentCount) || currentCount < count)
                {
                    primeFactors[number] = count;
                }
            }
        }

        if (primeFactors.Count == 0)
        {
            return 0;
        }

        var steps = 1L;
        foreach (var (number, count) in primeFactors)
        {
            for (var i = 0; i < count; i++)
            {
                steps *= number;
            }
        }

        return steps;
    }

    private partial class Map
    {
        public string Instruction { get; }

        public Node[] Nodes { get; }

        public Map(string data)
        {
            ReadOnlySpan<string> lines = data.Split('\n', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries).AsSpan();
            Instruction = lines[0];

            lines = lines[1..];
            Nodes = new Node[lines.Length];

            for (var i = 0; i < lines.Length; i++)
            {
                var values = NodeValuesRegex().Matches(lines[i]);
                var value = values[0].Value;
                var left = values[1].Value;
                var right = values[2].Value;

                var node = new Node(value, left, right);
                Nodes[i] = node;
            }
        }

        [GeneratedRegex("\\w+")]
        private static partial Regex NodeValuesRegex();
    }

    private readonly record struct Node(string Value, string Left, string Right);

    private static Dictionary<int, int> GetPrimeFactors(int value)
    {
        var dict = new Dictionary<int, int>();

        while (value % 2 == 0)
        {
            value /= 2;
            if (!dict.TryGetValue(2, out var count))
            {
                dict[2] = 0;
            }

            dict[2] = ++count;
        }

        for (var i = 3; value > 1; i += 2)
        {
            while (value % i == 0)
            {
                if (!dict.TryGetValue(i, out var count))
                {
                    dict[i] = 0;
                }

                value /= i;
                dict[i] = ++count;
            }
        }

        return dict;
    }

    private static bool IsPrime(int value)
    {
        if (value < 2)
        {
            return false;
        }

        if (value < 4)
        {
            return true;
        }

        if (value % 2 == 0)
        {
            return false;
        }

        if (value < 9)
        {
            return true;
        }

        if (value % 3 == 0)
        {
            return false;
        }

        var r = (int)Math.Floor(Math.Sqrt(value));
        var f = 5;
        while (f <= r)
        {
            if (value % f == 0 || value % (f + 2) == 0)
            {
                return false;
            }

            f += 6;
        }

        return true;
    }
}
