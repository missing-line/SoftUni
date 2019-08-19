using System;

namespace Easter_Cozonacs
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            double kgPriceFlour = double.Parse(Console.ReadLine());

            double packEggs = 0.75 * kgPriceFlour;
            double milk = (0.25 * kgPriceFlour) + kgPriceFlour;

            double milkForOneCozonac = milk / 4;

            double priceForOneCozona = milkForOneCozonac + packEggs + kgPriceFlour;

            int index = 0;
            int countOfCozonacs = 0;
            int coutnOfEggs = 0;

            while (true)
            {
                if (budget - priceForOneCozona <= 0)
                {
                    break;
                }

                budget -= priceForOneCozona;
                countOfCozonacs++;
                coutnOfEggs += 3;
                index++;
                if (index == 3)
                {
                    index = 0;
                    coutnOfEggs -= (countOfCozonacs - 2);
                }
            }

            Console.WriteLine($"You made {countOfCozonacs} cozonacs! Now you have {coutnOfEggs} eggs and {budget:f2}BGN left.");
        }
    }
}
