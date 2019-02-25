namespace Count_Uppercase_Words
{
    using System;
    using System.Linq;
    public class Program
    {
        public static void Main(string[] args)
        {
            Func<string, bool> upperCase = word => char.IsUpper(word[0]);

            string[] line = Console.ReadLine()
                .Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                .Where(upperCase)
                .ToArray();
            Console.WriteLine(string.Join("\n", line));
        }
    }
}
