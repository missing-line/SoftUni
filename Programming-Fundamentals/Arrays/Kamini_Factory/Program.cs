namespace Kamini_Factory
{
    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;
    public class Program
    {
        public static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            string[] line = Console.ReadLine().Split("!".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

            List<string> sequance = new List<string>();

            while (string.Join(" ", line) != "Clone them")
            {
                string curr = string.Join("", line);
                if (curr.Length == num)
                {
                    sequance.Add(curr);
                }
                line = Console.ReadLine().Split("!".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            }
            int bestIndex = 0;
            int bestSum = 0;
            int bestLine = 0;
            int bestLenght = 0;
            string pattern = @"[1]{2,}";

            for (int i = 0; i < sequance.Count; i++)
            {
                Match m = Regex.Match(sequance[i], pattern);
                if (m.Success)
                {
                    int startMatch = m.Index;
                    int currLenght = m.Value.Length;
                    int currSum = Sum(sequance[i]);
                    if (bestLenght < currLenght)
                    {
                        bestLenght = currLenght;
                        bestIndex = startMatch;
                        bestSum = currSum;
                        bestLine = i;
                    }
                    else if (bestLenght == currLenght)
                    {
                        if (bestIndex > startMatch)
                        {
                            bestLenght = currLenght;
                            bestIndex = startMatch;
                            bestSum = currSum;
                            bestLine = i;
                        }
                        else if (bestIndex == startMatch)
                        {
                            if (bestSum < currSum)
                            {
                                bestLenght = currLenght;
                                bestIndex = startMatch;
                                bestSum = currSum;
                                bestLine = i;
                            }
                        }

                    }
                }
            }
            if (bestLenght == 0)
            {
                Console.WriteLine($"Best DNA sample {0} with sum: {0}.");
                for (int i = 0; i < sequance[0].Length; i++)
                {
                    Console.Write(sequance[bestLine][i] + " ");
                }
                Console.WriteLine();
                return;
            }
            Console.WriteLine($"Best DNA sample {bestLine + 1} with sum: {bestSum}.");
            for (int i = 0; i < sequance[bestLine].Length; i++)
            {
                if (i == sequance[bestLine].Length - 1)
                {
                    Console.Write(sequance[bestLine][i]);
                    Console.WriteLine();
                    return;
                }
                Console.Write(sequance[bestLine][i] + " ");
            }
            Console.WriteLine();
        }
        public static int Sum(string curr)
        {
            int sum = 0;
            for (int i = 0; i < curr.Length; i++)
            {
                int n = int.Parse(curr[i].ToString());
                sum += n;
            }
            return sum;
        }
    }
}
