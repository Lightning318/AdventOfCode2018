using System;
using System.Collections.Generic;
using System.Linq;

namespace Task_2
{
    public static class Program
    {
        static void Main(string[] args)
        {
            var input = "+1 +1 +1";

            Console.WriteLine($"Input: ${input}");
            Console.WriteLine($"Frequency: {CalculateFrequency(input)}");
            Console.ReadKey();
        }

        public static int CalculateFrequency(string input)
        {
            var frequency = 0;
            var triedValues = new HashSet<int>();
        
            var changes = input.Split(' ')
                               .Select(int.Parse)
                               .ToCircularEnumerable()
                               .GetEnumerator();
        
            while(!triedValues.Contains(frequency))
            {
                triedValues.Add(frequency);
                changes.MoveNext();
                frequency += changes.Current;
            }
            return frequency;
        }

        public static IEnumerable<T> ToCircularEnumerable<T>(this IEnumerable<T> changes)
        {
            while (true)
            {
                foreach (var i in changes)
                {
                    yield return i;
                }
            }
        }
    }
}
