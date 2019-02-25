namespace SpeedRacing
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<Car> cars = new List<Car>();

            for (int i = 0; i < n; i++)
            {
                string[] currCar = Console.ReadLine().Split().ToArray();

                string model = currCar[0];
                double fualAmount = double.Parse(currCar[1]);
                double fualCosumation = double.Parse(currCar[2]);

                cars.Add(new Car(model, fualAmount, fualCosumation));
            }

            string[] drive = Console.ReadLine().Split().ToArray();

            while (drive[0] != "End")
            {

                string modelDriving = drive[1];
                int km = int.Parse(drive[2]);
                Car car = cars.First(x => x.Model == modelDriving);

                if (!car.CalculateFuel(km))
                {
                    Console.WriteLine("Insufficient fuel for the drive");
                }

                drive = Console.ReadLine().Split().ToArray();
            }

            foreach (var car in cars)
            {
                Console.WriteLine($"{car.Model} {car.FuelAmount:f2} {car.DistanceTravel}");
            }
        }
    }
}
