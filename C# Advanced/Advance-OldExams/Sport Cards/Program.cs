namespace Sport_Cards
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, decimal>> fitness = new Dictionary<string, Dictionary<string, decimal>>();
            string[] arr;

            while (string.Join("", arr = Console.ReadLine().Split(" - ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).ToArray()) != "end")
            {

                if (arr[0] == "check")
                {
                    string checkCard = arr[1];
                    bool checkFitnessCard = CheckingCard(fitness, checkCard);
                    Console.WriteLine(checkFitnessCard ? $"{checkCard} is available!" : $"{checkCard} is not available!");
                }
                else
                {
                    string card = arr[0];
                    string sport = arr[1];
                    decimal price = decimal.Parse(arr[2]);
                    if (!fitness.ContainsKey(card))
                    {
                        fitness.Add(card, new Dictionary<string, decimal>());
                        fitness[card].Add(sport, price);
                    }
                    else if (fitness.ContainsKey(card) && fitness[card].ContainsKey(sport))
                    {
                        fitness[card][sport] = price;
                    }
                    else if (fitness.ContainsKey(card) && !fitness[card].ContainsKey(sport))
                    {
                        fitness[card].Add(sport,price);
                    }
                }
            }

            foreach (var kvp in fitness.OrderByDescending(x => x.Value.Count()))
            {
                Console.WriteLine($"{kvp.Key}:");
                foreach (var inner in kvp.Value.OrderBy(y => y.Key))
                {
                    Console.WriteLine($"  -{inner.Key} - {inner.Value:f2}");
                }
            }
        }

        private static bool CheckingCard(Dictionary<string, Dictionary<string, decimal>> fitness, string checkCard)
        {
            return fitness.ContainsKey(checkCard);
        }
    }
}
