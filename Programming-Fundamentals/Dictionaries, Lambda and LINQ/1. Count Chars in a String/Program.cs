namespace _1._Count_Chars_in_a_String
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    public class Program
    {
        public static void Main(string[] args)
        {
            string[] line = Console.ReadLine().Split().ToArray();
            Dictionary<char, int> charsCount = new Dictionary<char, int>();

            for (int i = 0; i < line.Length; i++)
            {
                string curr = line[i];
                for (int j = 0; j < curr.Length; j++)
                {
                    if (!charsCount.ContainsKey(curr[j]))
                    {
                        charsCount.Add(curr[j], 1);
                    }
                    else
                    {
                        charsCount[curr[j]]++;
                    }
                }
            }

            foreach (var letter in charsCount)
            {
                Console.WriteLine($"{letter.Key} -> {letter.Value}");
            }
        }
    }
}
