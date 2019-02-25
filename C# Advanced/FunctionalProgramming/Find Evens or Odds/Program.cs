namespace Find_Evens_or_Odds
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    public class Program
    {
        public static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            string evenOrOdd = Console.ReadLine();

            Predicate<int> pred = n => n % 2 == 0;

            List<int> result = new List<int>();

            Enumerable.Range(numbers[0], numbers[1] - numbers[0] + 1)
               .Where(x => evenOrOdd == "even" ? pred(x) : !pred(x))
                .ToList()
                .ForEach(result.Add);
            Console.WriteLine(string.Join(" ", result));
        }
    }
}
