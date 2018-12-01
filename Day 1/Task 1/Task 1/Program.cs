using System;
using System.Linq;

namespace Task_1
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

        public static int CalculateFrequency(string input) =>
            input.Split(' ')
                 .Select(int.Parse)
                 .Sum();
    }
}
