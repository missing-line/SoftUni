namespace _03._Speed_Racing
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    public class Program
    {
        public class Car
        {
            public string Model { set; get; }
            public double Fuel { set; get; }
            public double FuelConsumptionFor1km { set; get; }
            public double Distance { set; get; }
        }
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<Car> cars = new List<Car>();

            for (int i = 0; i < n; i++)
            {
                string[] car = Console.ReadLine().Split().ToArray();

                Car curr = new Car()
                {
                    Model = car[0],
                    Fuel = double.Parse(car[1]),
                    FuelConsumptionFor1km = double.Parse(car[2]),
                    Distance = 0
                };
                cars.Add(curr);
            }

            string driverDistance = Console.ReadLine();

            while (driverDistance != "End")
            {
                string[] driver = driverDistance.
                    Split()
                    .ToArray();

                if (cars.Any(x => x.Model == driver[1]))
                {
                    Car ext = cars.First(x => x.Model == driver[1]);

                    double distanceTraveled = double.Parse(driver[2]) * ext.FuelConsumptionFor1km;

                    if (distanceTraveled <= ext.Fuel)
                    {
                        ext.Fuel -= distanceTraveled;
                        ext.Distance += double.Parse(driver[2]);
                    }
                    else
                    {
                        Console.WriteLine($"Insufficient fuel for the drive");
                    }
                }
                driverDistance = Console.ReadLine();
            }

            foreach (var car in cars)
            {
                Console.WriteLine($"{car.Model} {(car.Fuel):f2} {car.Distance}");
            }
        }
    }
}
