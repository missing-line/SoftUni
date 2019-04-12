namespace Number_War
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    public class Program
    {
        static void Main(string[] args)
        {
            List<string> fistPlayer = Console.ReadLine()
                .Split()
                .ToList();

            List<string> secondPlayer = Console.ReadLine()
                .Split()
                .ToList();

            Queue<string> queueFirstPlayer = new Queue<string>(fistPlayer);

            Queue<string> queueSecondPlayer = new Queue<string>(secondPlayer);

            int count = 0;

            while (queueFirstPlayer.Count != 0 && queueSecondPlayer.Count != 0)
            {
                if (count > 200000)
                {
                    if (queueFirstPlayer.Count > queueSecondPlayer.Count)
                    {
                        Console.WriteLine($"First player wins after 1000000 turns");
                    }
                    else if (queueFirstPlayer.Count < queueSecondPlayer.Count)
                    {
                        Console.WriteLine($"Second player wins after 1000000 turns");
                    }
                    else
                    {
                        Console.WriteLine($"Draw after {count} turns");
                    }

                    return;
                }
                count++;

                List<string> first = new List<string>();
                List<string> second = new List<string>();

                string firstPlayerCard = queueFirstPlayer.Dequeue();
                string secondPlayerCard = queueSecondPlayer.Dequeue();

                first.Add(firstPlayerCard);
                second.Add(secondPlayerCard);

                int cardValueFirstPlayer = int.Parse(firstPlayerCard.Substring(0, firstPlayerCard.Length - 1));
                int cardValueSecondPlayer = int.Parse(secondPlayerCard.Substring(0, secondPlayerCard.Length - 1));

                if (cardValueFirstPlayer == cardValueSecondPlayer)
                {

                    while (queueFirstPlayer.Count > 0 && queueSecondPlayer.Count > 0)
                    {

                        int valueFirst = GetThreeCards(queueFirstPlayer, first);
                        int valueSecond = GetThreeCards(queueSecondPlayer, second);

                        if (valueFirst == valueSecond)
                        {
                            continue;
                        }
                        else if (valueFirst > valueSecond)
                        {
                            AddingCardsToWinner(first, second, queueFirstPlayer);
                        }
                        else
                        {
                            AddingCardsToWinner(first, second, queueSecondPlayer);
                        }
                        break;
                    }
                }
                else if (cardValueFirstPlayer > cardValueSecondPlayer)
                {
                    AddingOnlyTwoCarsd(firstPlayerCard, secondPlayerCard, queueFirstPlayer);
                }
                else if (cardValueFirstPlayer < cardValueSecondPlayer)
                {
                    AddingOnlyTwoCarsd(firstPlayerCard, secondPlayerCard, queueSecondPlayer);
                }
            }

            if (queueFirstPlayer.Count == 0 && queueSecondPlayer.Count == 0)
            {
                Console.WriteLine($"Draw after {count} turns");
            }
            else if (queueSecondPlayer.Count == 0)
            {
                Console.WriteLine($"First player wins after {count} turns");
            }
            else if (queueFirstPlayer.Count == 0)
            {
                Console.WriteLine($"Second player wins after {count} turns");

            }
        }


        private static void AddingOnlyTwoCarsd(string firstPlayerCard, string secondPlayerCard, Queue<string> queuePlayer)
        {
            List<string> allCards = new List<string>();
            allCards.Add(firstPlayerCard);
            allCards.Add(secondPlayerCard);

            foreach (var card in allCards.OrderByDescending(c => int.Parse(c.Substring(0, c.Length - 1)))
                .ThenByDescending(c => c[c.Length - 1]))
            {
                queuePlayer.Enqueue(card);
            }
        }

        private static void AddingCardsToWinner(List<string> first, List<string> second, Queue<string> queuePlayer)
        {
            List<string> allCards = new List<string>();
            allCards.AddRange(first);
            allCards.AddRange(second);

            foreach (var card in allCards.OrderByDescending(c => int.Parse(c.Substring(0, c.Length - 1)))
                .ThenByDescending(c => c[c.Length - 1]))
            {
                queuePlayer.Enqueue(card);
            }
        }

        private static int GetThreeCards(Queue<string> queueFirstPlayer, List<string> player)
        {
            int value = 0;
            for (int i = 0; i < 3; i++)
            {
                string currCard = queueFirstPlayer.Dequeue();
                player.Add(currCard);
                char ch = currCard[currCard.Length - 1];
                int index = char.ToUpper(ch) - 64;
                value += index;
            }
            return value;
        }
    }
}
