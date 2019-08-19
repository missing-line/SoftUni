using System;
using System.Linq;

namespace Softuni_Coffee_Orders_2
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            decimal curPrice = 0;
            decimal total = 0;
            for (int i = 0; i < n; i++)
            {
                decimal price = decimal.Parse(Console.ReadLine());
                string[] date = Console.ReadLine().Split("/".ToCharArray(),StringSplitOptions.RemoveEmptyEntries).ToArray();
                int days = DateTime.DaysInMonth(int.Parse(date[2]), int.Parse(date[1]));
                decimal cap = decimal.Parse(Console.ReadLine());
                curPrice = (days * price * cap);
                Console.WriteLine($"The price for the coffee is: ${curPrice:f2}");
                total += curPrice;
            }
            Console.WriteLine($"Total: ${total:f2}");
        }
    }
}
