using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Day_4
{
    public static class Program
    {
        static void Main(string[] args)
        {
            var input = Input.input;
            var i = FindGuardTask2(input);

            Console.WriteLine($"Id: {i}");
            Console.ReadKey();
        }

        public static int FindGuardTask1(string input)
        {
            var x = input.Split('\n', StringSplitOptions.RemoveEmptyEntries)
                .Select(s => new Observation(s))
                .OrderBy(o => o.Timestamp)
                .ToSleepMinutes()
                .OrderByDescending(g => g.Value.Count)
                .First();

            return x.Key * x.Value.MostCommon();
        }

        public static int FindGuardTask2(string input)
        {
            var x = input.Split('\n', StringSplitOptions.RemoveEmptyEntries)
                .Select(s => new Observation(s))
                .OrderBy(o => o.Timestamp)
                .ToSleepMinutes()
                .OrderByDescending(g => g.Value.Count(i => i == g.Value.MostCommon()))
                .First();

            return x.Key * x.Value.MostCommon();
        }

        public static IEnumerable<KeyValuePair<int, List<int>>> ToSleepMinutes(this IEnumerable<Observation> obvs)
        {
            int guardID = -1;
            int startMinute = -1;
            Dictionary<int, List<int>> guardSleepMinutes = new Dictionary<int, List<int>>();

            foreach (var o in obvs)
            {
                switch (o.Type)
                {
                    case Observation.State.newGuard:
                        guardID = o.GuardId.Value;
                        continue;
                    case Observation.State.SleepStarts:
                        startMinute = o.Minute;
                        continue;
                    case Observation.State.SleepEnds:
                        var minutes = guardSleepMinutes.GetValueOrDefault(guardID) ?? new List<int>();
                        minutes.AddRange(Enumerable.Range(startMinute, o.Minute - startMinute));
                        guardSleepMinutes[guardID] = minutes;
                        continue;
                }
            }
            return guardSleepMinutes;
        }

        public static T MostCommon<T>(this IEnumerable<T> items) =>
            items.GroupBy(i => i).OrderByDescending(g => g.Count()).First().Key;

        public static IEnumerable<T> Flatten<T>(this IEnumerable<IEnumerable<T>> items) =>
            items.SelectMany(i => i);
    }

    public class Observation
    {
        public readonly DateTime Timestamp;
        public int Minute { get => Timestamp.Minute; }
        public readonly int? GuardId;
        public readonly State Type;

        public Observation(string s)
        {
            var m = Regex.Match(s, @"\[(?<datetime>.*)\] (?<type>[A-Za-z]+) #?(?<guardId>[0-9]*)");
            Timestamp = DateTime.Parse(m.Groups["datetime"].Value);
            switch (m.Groups["type"].Value)
            {
                case "Guard":
                    Type = State.newGuard;
                    GuardId = int.Parse(m.Groups["guardId"].Value);
                    break;
                case "falls":
                    Type = State.SleepStarts;
                    break;
                case "wakes":
                    Type = State.SleepEnds;
                    break;
            }
        }

        public enum State
        {
            newGuard,
            SleepEnds,
            SleepStarts
        }
    }
}
