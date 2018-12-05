using System;
using System.Linq;
using System.Text;

namespace Task_1
{
    public class Program
    {
        static void Main(string[] args)
        {
            var input = Input.input;
            var result = Task2(input);
            Console.WriteLine($"Reduced string {result.Length}");
            Console.ReadKey();
        }

        public static string Task1(string s) =>
            Reduce(s);

        public static string Task2(string input)
        {
            return "abcdefghijklmnopqrstuvwxyz"
            .Select(c => new string(input.Where(x => char.ToLower(x) != char.ToLower(c)).ToArray()))
            .Select(y => Reduce(y))
            .OrderBy(x => x.Length)
            .First();
        }

        public static string Reduce(string s)
        {
            int redutionsMade = 1;
            var polymer = s;
            while (redutionsMade > 0)
            {
                redutionsMade = 0;
                var sb = new StringBuilder();
                char? previous = null;
                foreach (var curr in polymer)
                {
                    if (!previous.HasValue) { previous = curr; continue; }
                    if (WouldReact(curr, previous.Value))
                    { redutionsMade++; previous = null; continue; }
                    sb.Append(previous.Value);
                    previous = curr;
                }
                if (previous.HasValue) { sb.Append(previous.Value); }
                polymer = sb.ToString();
            }
            return polymer;
        }

        public static bool WouldReact(char a, char b) =>
            char.ToLower(a) == char.ToLower(b) &&
            ((char.IsUpper(a)) ? char.IsLower(b) : char.IsUpper(b));
    }
}
