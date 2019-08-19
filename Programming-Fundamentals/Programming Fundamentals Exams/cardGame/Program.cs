using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardsGame
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> firstPlayerCards = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            List<int> secondPlayerCards = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            List<int> smallerList = new List<int>();

            while (firstPlayerCards.Count > 0 || secondPlayerCards.Count > 0)
            {
                List<int> firstPlayerNewCards = new List<int>();
                List<int> secondPlayerNewCards = new List<int>();


                if (firstPlayerCards.Count <= secondPlayerCards.Count)
                {
                    smallerList = firstPlayerCards;
                }
                else
                {
                    smallerList = secondPlayerCards;
                }
                for (int i = 0; i < smallerList.Count; i++)
                {
                    if (firstPlayerCards[i] > secondPlayerCards[i])
                    {
                        firstPlayerNewCards.Add(firstPlayerCards[i]);
                        firstPlayerNewCards.Add(secondPlayerCards[i]);
                    }
                    else if (secondPlayerCards[i] > firstPlayerCards[i])
                    {
                        secondPlayerNewCards.Add(secondPlayerCards[i]);
                        secondPlayerNewCards.Add(firstPlayerCards[i]);
                    }
                }
                firstPlayerCards = firstPlayerNewCards;
                secondPlayerCards = secondPlayerNewCards;
            }
            int sum = 0;
            if (firstPlayerCards.Count == 0)
            {
                for (int i = 0; i < secondPlayerCards.Count; i++)
                {
                    sum += secondPlayerCards[i];
                }
                Console.WriteLine($"Second player wins! Sum: {sum}");
            }
            else if (secondPlayerCards.Count == 0)
            {
                for (int i = 0; i < firstPlayerCards.Count; i++)
                {
                    sum += firstPlayerCards[i];
                }
                Console.WriteLine($"First player wins! Sum: {sum}");
            }

        }
    }
}