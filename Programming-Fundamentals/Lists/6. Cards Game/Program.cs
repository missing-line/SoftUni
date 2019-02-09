namespace _6._Cards_Game
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    public class Program
    {
        public static void Main(string[] args)
        {
            List<int> first = Console.ReadLine().Split().Select(int.Parse).ToList();
            List<int> second = Console.ReadLine().Split().Select(int.Parse).ToList();

            while (first.Count != 0 && second.Count != 0)
            {
                int firstCard = first[0];
                int secondCard = second[0];
                if (firstCard > secondCard)
                {
                    first.RemoveAt(0);
                    second.RemoveAt(0);

                    first.Add(firstCard);
                    first.Add(secondCard);
                }
                else if (secondCard > firstCard)
                {
                    first.RemoveAt(0);
                    second.RemoveAt(0);

                    second.Add(secondCard);
                    second.Add(firstCard);
                }
                else
                {
                    RemoveCards(first, second);
                }
            }
            if (first.Count > 0)
            {
                Console.WriteLine($"First player wins! Sum: {first.Sum()}");
            }
            else if (second.Count > 0)
            {
                Console.WriteLine($"Second player wins! Sum: {second.Sum()}");
            }
        }
        static void RemoveCards(List<int> first, List<int> second)
        {
            first.RemoveAt(0);
            second.RemoveAt(0);
        }
    }
}
