namespace CarSalesman
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<Engine> engines = new List<Engine>();

            for (int i = 0; i < n; i++)
            {
                string[] arr = Console.ReadLine()
                    .Split(" ".ToCharArray(),StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                string modelEngine = arr[0];
                int powerEngine = int.Parse(arr[1]);
                string displacement = "n/a";
                string efficiency = "n/a";
                if (arr.Length == 3)
                {
                    if (arr[2].Any(x => char.IsDigit(x)))
                    {
                        int number = int.Parse(arr[2]);
                        displacement = number.ToString();
                    }
                    else
                    {
                        efficiency = arr[2];
                    }                  
                }
                else if (arr.Length == 4)
                {
                    int number = int.Parse(arr[2]);
                    displacement = number.ToString();
                    efficiency = arr[3];
                }
                engines.Add(new Engine()
                {
                    Model = modelEngine,
                    Power = powerEngine,
                    Displacement = displacement,
                    Efficiency = efficiency
                });
            }


            int m = int.Parse(Console.ReadLine());

            List<Car> cars = new List<Car>();

            for (int i = 0; i < m; i++)
            {
                string[] arr = Console.ReadLine()
                    .Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                string carModel = arr[0];
                Engine carEngine = engines.FirstOrDefault(x => x.Model == arr[1]);
                string weight = "n/a";
                string color = "n/a";
                if (arr.Length == 3)
                {
                    if (arr[2].Any(x => char.IsDigit(x)))
                    {
                        int number =  int.Parse(arr[2]);
                        weight = number.ToString();
                    }
                    else
                    {
                        color = arr[2];
                    }
                }
                else if (arr.Length == 4)
                {
                    int number = int.Parse(arr[2]);
                    weight = number.ToString();
                    color = arr[3];
                }
                cars.Add(new Car()
                {
                    Model = carModel,
                    Engine = carEngine,
                    Weight = weight,
                    Color = color
                });
            }


            foreach (Car car in cars)
            {
                Console.WriteLine($"{car.Model}:");               
                Console.WriteLine($" {car.Engine.Model}:");
                Console.WriteLine($"    Power: {car.Engine.Power}");
                Console.WriteLine($"    Displacement: {car.Engine.Displacement}");
                Console.WriteLine($"    Efficiency: {car.Engine.Efficiency}");
                Console.WriteLine($" Weight: {car.Weight}");
                Console.WriteLine($" Color: {car.Color}");
            }
        }
    }
}
