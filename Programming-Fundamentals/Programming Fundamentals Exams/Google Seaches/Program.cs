using System;

namespace Google_Seaches
{
    class Program
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            int users = int.Parse(Console.ReadLine());
            double perOnePerson = double.Parse(Console.ReadLine());
            double totalMoney = 0;
            for (int i = 1; i <= users; i++)
            {
                int word = int.Parse(Console.ReadLine());
                double currMoney = perOnePerson;
                if (word > 5)
                {
                    continue;
                }
                if (word == 1)
                {
                    currMoney *= 2;
                }
                if (i % 3 == 0)
                {
                    currMoney *= 3;
                }
                totalMoney += currMoney * days;
            }
            Console.WriteLine($"Total money earned for {days} days: {totalMoney:f2}");
        }
    }
}
