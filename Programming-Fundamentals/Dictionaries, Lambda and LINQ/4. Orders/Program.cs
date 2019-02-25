namespace _4._Orders
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    public class Program
    {
        public static void Main(string[] args)
        {
            string[] order = Console.ReadLine()
                .Split()
                .ToArray();

            Dictionary<string, double> orders = new Dictionary<string, double>();
            Dictionary<string, double> priceOrder = new Dictionary<string, double>();

            while (string.Join("", order) != "buy")
            {
                string product = order[0];
                double price = double.Parse(order[1]);
                double quantity = double.Parse(order[2]);
                if (!orders.ContainsKey(product))
                {
                    orders.Add(product, quantity);
                    priceOrder.Add(product, price);
                }
                else
                {
                    orders[product] += quantity;
                    priceOrder[product] = price;
                }

                order = Console.ReadLine().Split().ToArray();
            }

            foreach (var single in orders)
            {
                foreach (var price in priceOrder)
                {
                    if (single.Key == price.Key)
                    {
                        Console.WriteLine($"{single.Key} -> {(price.Value * single.Value):f2}");
                        break;
                    }
                }
            }
        }
    }
}
