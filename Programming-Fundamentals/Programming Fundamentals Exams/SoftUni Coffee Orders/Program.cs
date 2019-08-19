using System;
using System.Collections.Generic;
using System.Linq;

namespace SoftUni_Coffee_Orders
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<decimal> priceOrder = new List<decimal>();
            decimal total = 0;

            for (int i = 0; i < n; i++)
            {
                decimal price = decimal.Parse(Console.ReadLine());

                string[] date = Console.ReadLine()
                    .Split("/".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                decimal capsules = decimal.Parse(Console.ReadLine());

                int days = DateTime.DaysInMonth(int.Parse(date[2]), int.Parse(date[1]));

                decimal curr = days * price * capsules;
                priceOrder.Add(curr);

                total += curr;
            }

            foreach (var price in priceOrder)
            {
                Console.WriteLine($"The price for the coffee is: ${price:f2}");
            }
            Console.WriteLine($"Total: ${total:f2}");
        }
    }
}
