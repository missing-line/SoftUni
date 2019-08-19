using System;
using System.Collections.Generic;
using System.Linq;

namespace Hello__France
{
    class Program
    {
        private static double money = 0;
        private static double profit = 0;
        static void Main(string[] args)
        {
            string line = Console.ReadLine();
            money = double.Parse(Console.ReadLine());

            string[] splited = line
                .Split("|".ToCharArray())
                .ToArray();

            var prices = new List<double>();

            for (int i = 0; i < splited.Length; i++)
            {
                var product = splited[i]
                    .Split("->".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string type = product[0];
                double price = double.Parse(product[1]);
                if (IsCorrectPrice(type, price))
                {
                    prices.Add(price);
                }
            }

            for (int i = 0; i < prices.Count; i++)
            {
                double currPercent = (prices[i] * 0.4);
                profit += currPercent;
                prices[i] =(prices[i] + currPercent); 
            }

            Print(prices);
                     
        }

        private static void Print(List<double> prices)
        {
            for (int i = 0; i < prices.Count; i++)
            {
                if (i == prices.Count - 1)
                {
                    Console.WriteLine($"{prices[i]:f2}");
                }
                else
                {
                    Console.Write($"{prices[i]:f2} ");
                }
            }

            Console.WriteLine($"Profit: {profit:f2}");

            if (prices.Sum() + money >= 150)
            {
                Console.WriteLine("Hello, France!");
                return;
            }
            Console.WriteLine("Time to go.");
        }

        private static bool IsCorrectPrice(string type, double price)
        {
            switch (type)
            {
                case "Clothes":
                    if (price <= 50 && money >= price)
                    {
                        money -= price;
                        return true;
                    }
                    return false;
                case "Shoes":
                    if (price <= 35 && money >= price)
                    {
                        money -= price;
                        return true;
                    }
                    return false;
                case "Accessories":
                    if (price <= 20.50 && money >= price)
                    {
                        money -= price;
                        return true;
                    }
                    return false;
                default:
                    return false;
            }
        }
    }
}
