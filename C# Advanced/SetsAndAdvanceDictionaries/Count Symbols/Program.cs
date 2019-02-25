namespace Count_Symbols
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public class Program
    {
        public static void Main(string[] args)
        {
            string line = Console.ReadLine();

            Dictionary<char, int> countChars = new Dictionary<char, int>();

            for (int i = 0; i < line.Length; i++)
            {
                if (!countChars.ContainsKey(line[i]))
                {
                    countChars.Add(line[i], 0);
                }
                countChars[line[i]]++;
            }

            foreach (var letter in countChars.OrderBy(x => x.Key))
            {
                Console.WriteLine($"{letter.Key}: {letter.Value} time/s");
            }
        }
    }
}
