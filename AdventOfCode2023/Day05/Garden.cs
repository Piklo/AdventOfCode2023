using System.Collections.Immutable;
using System.Text.RegularExpressions;

namespace AdventOfCode2023.Day05;

internal sealed partial class Garden
{
    private const string SeedToSoil = "seed-to-soil";
    private const string SoilToFertilizer = "soil-to-fertilizer";
    private const string FertilizerToWater = "fertilizer-to-water";
    private const string WaterToLight = "water-to-light";
    private const string LightToTemperature = "light-to-temperature";
    private const string TemperatureToHumidity = "temperature-to-humidity";
    private const string HumidityToLocation = "humidity-to-location";

    [GeneratedRegex("(?<=seeds:.*)\\d+")]
    private static partial Regex GetSeedsRegex();

    [GeneratedRegex("^(?<type>.*)(?= map)|^(?<destination>\\d+).(?<source>\\d+).(?<range>\\d+)", RegexOptions.Multiline)]
    private static partial Regex GetMapsRegex();

    public ImmutableArray<long> SeedValues { get; }

    private readonly List<Map> seedToSoil = [];

    private readonly List<Map> soilToFertilizer = [];

    private readonly List<Map> fertilizerToWater = [];

    private readonly List<Map> waterToLight = [];

    private readonly List<Map> lightToTemperature = [];

    private readonly List<Map> temperatureToHumidity = [];

    private readonly List<Map> humidityToLocation = [];

    public Garden(string data)
    {
        SeedValues = GetSeedsRegex().Matches(data).Select(x => long.Parse(x.ValueSpan)).ToImmutableArray();

        var maps = GetMapsRegex().Matches(data);
        var type = string.Empty;
        foreach (var match in (IEnumerable<Match>)maps)
        {
            if (match.Groups["type"].Success)
            {
                type = match.Groups["type"].Value;
            }
            else
            {
                var destination = long.Parse(match.Groups["destination"].ValueSpan);
                var source = long.Parse(match.Groups["source"].ValueSpan);
                var range = long.Parse(match.Groups["range"].ValueSpan);

                var map = new Map(source, destination, range);

                if (type == SeedToSoil)
                {
                    seedToSoil.Add(map);
                }
                else if (type == SoilToFertilizer)
                {
                    soilToFertilizer.Add(map);
                }
                else if (type == FertilizerToWater)
                {
                    fertilizerToWater.Add(map);
                }
                else if (type == WaterToLight)
                {
                    waterToLight.Add(map);
                }
                else if (type == LightToTemperature)
                {
                    lightToTemperature.Add(map);
                }
                else if (type == TemperatureToHumidity)
                {
                    temperatureToHumidity.Add(map);
                }
                else if (type == HumidityToLocation)
                {
                    humidityToLocation.Add(map);
                }
                else
                {
                    throw new NotImplementedException($"unknown type = {type}");
                }
            }
        }
    }

    public long GetLocation(long seed)
    {
        var soil = GetValue(seedToSoil, seed);
        var fertilizer = GetValue(soilToFertilizer, soil);
        var water = GetValue(fertilizerToWater, fertilizer);
        var light = GetValue(waterToLight, water);
        var temperature = GetValue(lightToTemperature, light);
        var humidity = GetValue(temperatureToHumidity, temperature);
        var location = GetValue(humidityToLocation, humidity);

        return location;
    }

    private static long GetValue(List<Map> maps, long key)
    {
        foreach (var map in maps)
        {
            if (map.IsMapped(key, out var res))
            {
                return res;
            }
        }

        return key;
    }

    private readonly record struct Map(long Source, long Destination, long Range)
    {
        public bool IsMapped(long item, out long result)
        {
            if (item < Source || item > Source + Range)
            {
                result = default;
                return false;
            }

            var difference = item - Source;

            result = Destination + difference;
            return true;
        }
    }
}
