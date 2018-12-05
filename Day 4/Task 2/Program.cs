using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Task_2
{
    public static class Program
    {
        static void Main(string[] args)
        {
            var input = Input.input;
            var i = FindGuard(input);

            Console.WriteLine($"Id: {i}");
            Console.ReadKey();
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

        public static IEnumerable<IEnumerable<T>> TakePairs<T>(this IEnumerable<T> items) =>
            items.Zip(items, (second, first) => new[] { first, second });
    }

    public class Observation
    {
        public DateTime Timestamp;
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
