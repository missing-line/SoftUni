using System;

namespace The_Hunting_Games
{
    class Program
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());

            int players = int.Parse(Console.ReadLine());

            double allEnergy = double.Parse(Console.ReadLine());

            double water = double.Parse(Console.ReadLine());

            double food = double.Parse(Console.ReadLine());

           
            double totalWater = days * players * water;
            double totalFood = days * players * food;

            for (int i = 1; i <= days; i++)
            {
                double loseEnergy = double.Parse(Console.ReadLine());

                allEnergy -= loseEnergy;

                if (allEnergy <= 0)
                {
                    Console.WriteLine($"You will run out of energy. You will be left with {totalFood:f2} food and {totalWater:f2} water.");
                    return;
                }
                if (i % 2 == 0)
                {
                    allEnergy += allEnergy * 0.05;
                    totalWater -= totalWater * 0.30;
                }
                if (i % 3 == 0)
                {
                    totalFood -= totalFood / players;
                    allEnergy += allEnergy * 0.10;
                }               
            }
            Console.WriteLine($"You are ready for the quest. You will be left with - {allEnergy:f2} energy!");
        }
    }
}
