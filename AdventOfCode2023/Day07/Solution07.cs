namespace AdventOfCode2023.Day07;

public static class Solution07
{
    public static int SolveP1(string data)
    {
        var res = 0;
        var hands = ParseInput(data);

        Array.Sort(hands, (hand1, hand2) =>
        {
            var handTypeStrength1 = GetHandTypeStrength(GetHandTypeP1(hand1));
            var handTypeStrength2 = GetHandTypeStrength(GetHandTypeP1(hand2));
            if (handTypeStrength1 != handTypeStrength2)
            {
                return handTypeStrength1.CompareTo(handTypeStrength2);
            }

            for (var i = 0; i < hand1.Cards.Length && i < hand2.Cards.Length; i++)
            {
                var card1Strength = GetCardStrengthP1(hand1.Cards[i]);
                var card2Strength = GetCardStrengthP1(hand2.Cards[i]);

                if (card1Strength != card2Strength)
                {
                    return card1Strength.CompareTo(card2Strength);
                }
            }

            return 0;
        });

        for (var i = 0; i < hands.Length; i++)
        {
            Hand hand = hands[i];

            res += hand.Bid * (i + 1);
        }

        return res;
    }

    public static int SolveP2(string data)
    {
        var res = 0;
        var hands = ParseInput(data);

        Array.Sort(hands, (hand1, hand2) =>
        {
            var handTypeStrength1 = GetHandTypeStrength(GetHandTypeP2(hand1));
            var handTypeStrength2 = GetHandTypeStrength(GetHandTypeP2(hand2));
            if (handTypeStrength1 != handTypeStrength2)
            {
                return handTypeStrength1.CompareTo(handTypeStrength2);
            }

            for (var i = 0; i < hand1.Cards.Length && i < hand2.Cards.Length; i++)
            {
                var card1Strength = GetCardStrengthP2(hand1.Cards[i]);
                var card2Strength = GetCardStrengthP2(hand2.Cards[i]);

                if (card1Strength != card2Strength)
                {
                    return card1Strength.CompareTo(card2Strength);
                }
            }

            return 0;
        });

        for (var i = 0; i < hands.Length; i++)
        {
            Hand hand = hands[i];

            res += hand.Bid * (i + 1);
        }

        return res;
    }

    private readonly record struct Hand(string Cards, int Bid);

    private static Hand[] ParseInput(string data)
    {
        var lines = data.Split('\n', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
        var res = new Hand[lines.Length];

        for (var i = 0; i < lines.Length; i++)
        {
            var line = lines[i];
            var parts = line.Split(' ');
            var cards = parts[0];
            var bid = int.Parse(parts[1]);
            var hand = new Hand(cards, bid);
            res[i] = hand;
        }

        return res;
    }

    private enum HandType
    {
        None,
        FiveOfAKind,
        FourOfAKind,
        FullHouse,
        ThreeOfAKind,
        TwoPair,
        OnePair,
        HighCard,
    }

    private static HandType GetHandTypeP1(Hand hand)
    {
        var counts = new Dictionary<char, int>();

        foreach (var card in hand.Cards)
        {
            if (!counts.TryGetValue(card, out var value))
            {
                counts[card] = 0;
            }

            counts[card] = ++value;
        }

        return GetHandType(counts);
    }

    private static HandType GetHandTypeP2(Hand hand)
    {
        var counts = new Dictionary<char, int>();

        foreach (var card in hand.Cards)
        {
            if (!counts.TryGetValue(card, out var value))
            {
                counts[card] = 0;
            }

            counts[card] = ++value;
        }

        if (counts.Count > 1 && counts.Remove('J', out var jokerValue))
        {
            var maxKey = default(char);
            var maxValue = 0;

            foreach (var (key, value) in counts)
            {
                if (value > maxValue)
                {
                    maxValue = value;
                    maxKey = key;
                }
            }

            counts[maxKey] += jokerValue;
        }

        return GetHandType(counts);
    }

    private static HandType GetHandType(Dictionary<char, int> counts)
    {
        if (counts.Count == 1)
        {
            return HandType.FiveOfAKind;
        }
        else if (counts.Count == 2)
        {
            var values = counts.Values.ToArray();
            var first = values[0];

            if (first == 1 || first == 4)
            {
                return HandType.FourOfAKind;
            }

            // else 2 or 3
            return HandType.FullHouse;
        }
        else if (counts.Count == 3)
        {
            var values = counts.Values.ToArray();
            var first = values[0];
            var second = values[1];
            var third = values[2];

            if (first == 3 || second == 3 || third == 3)
            {
                return HandType.ThreeOfAKind;
            }

            return HandType.TwoPair;
        }
        else if (counts.Count == 4)
        {
            return HandType.OnePair;
        }
        else
        {
            return HandType.HighCard;
        }
    }

    private static int GetHandTypeStrength(HandType type) => type switch
    {
        HandType.FiveOfAKind => 6,
        HandType.FourOfAKind => 5,
        HandType.FullHouse => 4,
        HandType.ThreeOfAKind => 3,
        HandType.TwoPair => 2,
        HandType.OnePair => 1,
        HandType.HighCard => 0,
        _ => throw new NotImplementedException($"unknown type = {type}"),
    };

    private static int GetCardStrengthP1(char card) => card switch
    {
        'A' => 13,
        'K' => 12,
        'Q' => 11,
        'J' => 10,
        'T' => 9,
        '9' => 8,
        '8' => 7,
        '7' => 6,
        '6' => 5,
        '5' => 4,
        '4' => 3,
        '3' => 2,
        '2' => 1,
        _ => throw new NotImplementedException($"unknown card = {card}"),
    };

    private static int GetCardStrengthP2(char card) => card switch
    {
        'A' => 13,
        'K' => 12,
        'Q' => 11,
        'T' => 10,
        '9' => 9,
        '8' => 8,
        '7' => 7,
        '6' => 6,
        '5' => 5,
        '4' => 4,
        '3' => 3,
        '2' => 2,
        'J' => 1,
        _ => throw new NotImplementedException($"unknown card = {card}"),
    };
}
