using System;

namespace Spring_Vacation_Trip
{
    class Program
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            double budget = double.Parse(Console.ReadLine());
            int people = int.Parse(Console.ReadLine());
            double fuelPerKm = double.Parse(Console.ReadLine());
            double foodPrice = double.Parse(Console.ReadLine());
            double priceRoom = double.Parse(Console.ReadLine());

            double allFood = people * foodPrice * days;
            double hotel = days * people * priceRoom;

            if (people > 10)
            {
                hotel -= (hotel * 0.25);

            }

            double current = allFood + hotel;

            for (int i = 1; i <= days; i++)
            {
                double distance = double.Parse(Console.ReadLine());
                current += distance * fuelPerKm;
                if (i % 3 == 0 || i % 5 == 0)
                {
                    double addiotional = current * 0.4;
                    current += addiotional;
                }
                if (i % 7 == 0)
                {
                    double discount = current / people;
                    current -= discount;

                }
                if (budget < current)
                {
                    Console.WriteLine($"Not enough money to continue the trip. You need {(current - budget):f2}$ more.");
                    return;
                }
            }
           
            Console.WriteLine($"You have reached the destination. You have {(budget - current):f2}$ budget left.");
        }
    }
}
