namespace _04._Raw_Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    public class Program
    {


        public class Car
        {
            public string Model { set; get; }
            public int EngineSpeed { set; get; }
            public int EnginePower { set; get; }
            public int CargoWeight { set; get; }
            public string CargoType { set; get; }
        }
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<Car> cars = new List<Car>();

            for (int i = 0; i < n; i++)
            {
                string[] car = Console.ReadLine().Split().ToArray();

                cars.Add(new Car()
                {
                    Model = car[0],
                    EngineSpeed = int.Parse(car[1]),
                    EnginePower = int.Parse(car[2]),
                    CargoWeight = int.Parse(car[3]),
                    CargoType = car[4],
                });
            }
       
            string command = Console.ReadLine();

            if (command == "fragile")
            {
                foreach (var car in cars.Where(x => x.CargoType == command).Where(y => y.CargoWeight < 1000))
                {
                    Console.WriteLine($"{car.Model}");
                }
            }
            else if (command == "flamable")
            {
                foreach (var car in cars.Where(x => x.CargoType == command).Where(y => y.EnginePower > 250))
                {
                    Console.WriteLine($"{car.Model}");
                }
            }
        }
    }
}
