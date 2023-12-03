using System.Text.RegularExpressions;

namespace AdventOfCode2023.Day03;

public static partial class Solution03
{
    [GeneratedRegex("\\d+")]
    private static partial Regex GetNumbersRegex();

    public static int SolveP1(string data)
    {
        var sum = 0;
        var numbers = GetNumbers(data);

        foreach (var number in numbers)
        {
            if (number.AdjacentSymbols.Count != 0)
            {
                sum += number.Value;
            }
        }

        return sum;
    }

    public static int SolveP2(string data)
    {
        var sum = 0;
        var numbers = GetNumbers(data);
        var numbersPerSymbol = new Dictionary<Symbol, List<Number>>();

        foreach (var number in numbers)
        {
            foreach (var symbol in number.AdjacentSymbols)
            {
                if (!numbersPerSymbol.TryGetValue(symbol, out var list))
                {
                    list = [];
                    numbersPerSymbol.Add(symbol, list);
                }

                list.Add(number);
            }
        }

        foreach (var (key, list) in numbersPerSymbol)
        {
            if (key.Value != '*' || list.Count != 2)
            {
                continue;
            }

            sum += list[0].Value * list[1].Value;
        }

        return sum;
    }

    private record Number(int Value, HashSet<Symbol> AdjacentSymbols);

    private readonly record struct Symbol(char Value, int LineNumber, int Index);

    private static List<Number> GetNumbers(string data)
    {
        var regex = GetNumbersRegex();
        var lines = data.Split('\n', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
        var numbers = new List<Number>();

        for (int i = 0; i < lines.Length; i++)
        {
            var line = lines[i];

            var matches = regex.Matches(line);

            for (var j = 0; j < matches.Count; j++)
            {
                var match = matches[j];
                var number = ParseMatch(lines, i, match);
                numbers.Add(number);
            }
        }

        return numbers;
    }

    private static Number ParseMatch(string[] lines, int lineIndex, Match match)
    {
        var symbols = new HashSet<Symbol>();
        var value = int.Parse(match.Value);
        var number = new Number(value, symbols);

        var startIndex = match.Index - 1;
        var endIndex = match.Index + match.Length + 1;

        AddAdjacentSymbols(lines, lineIndex - 1, startIndex, endIndex, symbols);
        AddAdjacentSymbols(lines, lineIndex, startIndex, endIndex, symbols);
        AddAdjacentSymbols(lines, lineIndex + 1, startIndex, endIndex, symbols);

        return number;
    }

    private static void AddAdjacentSymbols(string[] lines, int lineIndex, int startIndex, int endIndex, HashSet<Symbol> list)
    {
        if (lineIndex < 0 || lineIndex >= lines.Length)
        {
            return;
        }

        var line = lines[lineIndex];
        var start = Math.Max(0, startIndex);
        var end = Math.Min(line.Length, endIndex);

        for (int i = start; i < end; i++)
        {
            var c = line[i];

            if ((c >= '0' && c <= '9') || c == '.')
            {
                continue;
            }

            var symbol = new Symbol(c, lineIndex, i);
            list.Add(symbol);
        }
    }
}
