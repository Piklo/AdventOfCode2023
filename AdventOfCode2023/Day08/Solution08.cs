using System.Collections.Frozen;
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

    public static int SolveP2(string data)
    {
        var steps = 0;

        var map = new Map(data);
        var dictionary = GetDictionary(map);

        var current = map.Nodes.Where(node => node.Value[^1] == 'A').ToArray().AsSpan();

        var sequenceIndex = 0;
        //while (current.Any(node => node.Value[^1] != 'Z'))
        while (AnyNodeNotOnZ(current))
        {
            var instruction = map.Instruction[sequenceIndex];

            for (var i = 0; i < current.Length; i++)
            {
                var node = current[i];
                current[i] = dictionary[instruction == 'L' ? node.Left : node.Right];
            }

            steps++;
            sequenceIndex++;
            if (sequenceIndex >= map.Instruction.Length)
            {
                sequenceIndex = 0;
            }
        }

        return steps;
    }

    private static FrozenDictionary<string, Node> GetDictionary(Map map)
    {
        var dictionary = new Dictionary<string, Node>();

        foreach (var node in map.Nodes)
        {
            dictionary[node.Value] = node;
        }

        return dictionary.ToFrozenDictionary();
    }

    private static bool AnyNodeNotOnZ(ReadOnlySpan<Node> nodes)
    {
        for (var i = 0; i < nodes.Length; i++)
        {
            if (nodes[i].Value[^1] != 'Z')
            {
                return true;
            }
        }

        return false;
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
}
