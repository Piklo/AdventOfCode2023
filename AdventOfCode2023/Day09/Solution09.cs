namespace AdventOfCode2023.Day09;

public static class Solution09
{
    public static long SolveP1(string data)
    {
        var res = 0L;
        var histories = ParseInput(data);

        foreach (var history in histories)
        {
            var nextValue = PredictNextValue(history);
            res += nextValue;
        }

        return res;
    }

    public static long SolveP2(string data)
    {
        var res = 0L;
        var histories = ParseInput(data);

        foreach (var history in histories)
        {
            var nextValue = PredictPreviousValue(history);
            res += nextValue;
        }

        return res;
    }

    private static int[][] ParseInput(string data)
    {
        var lines = data.Split('\n', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
        var parsed = new int[lines.Length][];

        for (var i = 0; i < lines.Length; i++)
        {
            var line = lines[i];
            var values = line.Split();
            var parsedValues = new int[values.Length];
            parsed[i] = parsedValues;

            for (var j = 0; j < values.Length; j++)
            {
                var value = int.Parse(values[j]);
                parsedValues[j] = value;
            }
        }

        return parsed;
    }

    private static int PredictNextValue(int[] array)
    {
        var differencesStack = GetDifferencesStack(array);

        var next = 0;
        while (differencesStack.Count > 0)
        {
            var differences = differencesStack.Pop();
            next += differences[^1];
        }

        return next;
    }

    private static int PredictPreviousValue(int[] array)
    {
        var differencesStack = GetDifferencesStack(array);

        var next = 0;
        while (differencesStack.Count > 0)
        {
            var differences = differencesStack.Pop();
            next = differences[0] - next;
        }

        return next;
    }

    private static Stack<int[]> GetDifferencesStack(int[] array)
    {
        var differencesStack = new Stack<int[]>();
        differencesStack.Push(array);

        var differences = GetDifferences(array);
        differencesStack.Push(differences);

        while (differences.Any(difference => difference != 0))
        {
            differences = GetDifferences(differences);
            differencesStack.Push(differences);
        }

        return differencesStack;
    }

    private static int[] GetDifferences(int[] array)
    {
        var differences = new int[array.Length - 1];

        for (var i = 0; i < array.Length - 1; i++)
        {
            differences[i] = array[i + 1] - array[i];
        }

        return differences;
    }
}
