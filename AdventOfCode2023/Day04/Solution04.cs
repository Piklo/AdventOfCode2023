using System.Text.RegularExpressions;

namespace AdventOfCode2023.Day04;

public static partial class Solution04
{
    [GeneratedRegex("(?<=:.*)\\d+(?=.*\\|)")]
    private static partial Regex GetWinningNumbersRegex();

    [GeneratedRegex("(?<=\\|.*)\\d+")]
    private static partial Regex GetNumbersRegex();

    public static int SolveP1(string data)
    {
        var res = 0;
        var cards = data.Split('\n', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
        foreach (var card in cards)
        {
            var parsedCard = ParseCard(card);
            var score = GetWinningScoreP1(parsedCard);
            res += score;
        }

        return res;
    }

    public static int SolveP2(string data)
    {
        var res = 0;
        var cards = data.Split('\n', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
        var parsedCards = new ScratchCard[cards.Length];
        var dict = new Dictionary<ScratchCard, List<ScratchCard>>();

        for (var i = 0; i < cards.Length; i++)
        {
            var card = cards[i];
            var parsedCard = ParseCard(card);
            dict[parsedCard] = [];
            parsedCards[i] = parsedCard;
        }

        for (var i = 0; i < parsedCards.Length; i++)
        {
            var card = parsedCards[i];
            var winningCount = GetWinningCount(card);
            var list = dict[card];

            for (var j = i + 1; j < i + winningCount + 1 && j < parsedCards.Length; j++)
            {
                list.Add(parsedCards[j]);
            }
        }

        var queue = new Queue<ScratchCard>();

        foreach (var card in parsedCards)
        {
            queue.Enqueue(card);
        }

        while (queue.Count > 0)
        {
            res++;
            var card = queue.Dequeue();
            var wonCards = dict[card];
            foreach (var wonCard in wonCards)
            {
                queue.Enqueue(wonCard);
            }
        }

        return res;
    }

    private record ScratchCard(int[] WinningNumbers, int[] Numbers);

    private static ScratchCard ParseCard(string card)
    {
        var winningNumbers = GetWinningNumbersRegex().Matches(card);
        var numbers = GetNumbersRegex().Matches(card);

        var winningArray = new int[winningNumbers.Count];
        var numbersArray = new int[numbers.Count];

        for (var i = 0; i < winningNumbers.Count; i++)
        {
            var number = int.Parse(winningNumbers[i].Value);
            winningArray[i] = number;
        }

        for (var i = 0; i < numbers.Count; i++)
        {
            var number = int.Parse(numbers[i].Value);
            numbersArray[i] = number;
        }

        var scratchCard = new ScratchCard(winningArray, numbersArray);

        return scratchCard;
    }

    private static int GetWinningScoreP1(ScratchCard card)
    {
        var found = GetWinningCount(card);

        if (found == 0)
        {
            return 0;
        }

        var score = 1;
        score <<= found - 1;

        return score;
    }

    private static int GetWinningCount(ScratchCard card)
    {
        var found = 0;
        foreach (var number in card.Numbers)
        {
            if (card.WinningNumbers.Contains(number))
            {
                found++;
            }
        }

        return found;
    }
}
