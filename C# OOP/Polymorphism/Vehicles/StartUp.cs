namespace Vehicles
{
    using System;
    using System.Linq;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            string[] carArgs = Console.ReadLine()
                .Split()
                .ToArray();

            double carQuantity = double.Parse(carArgs[1]);
            double carConsumption = double.Parse(carArgs[2]);

            Vehicle car = new Car(carQuantity, carConsumption);

            string[] truckArgs = Console.ReadLine()
                .Split()
                .ToArray();

            double truckQuantity = double.Parse(truckArgs[1]);
            double truckConsumption = double.Parse(truckArgs[2]);

            Vehicle truck = new Truck(truckQuantity, truckConsumption);

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] arr = Console.ReadLine()
                .Split()
                .ToArray();

                string command = arr[0];
                string type = arr[1];
                double value = double.Parse(arr[2]);

                if (command == "Drive")
                {
                    if (type == "Car")
                    {
                        if (car.Driving(value))
                        {
                            Console.WriteLine($"Car travelled {value} km");
                            continue;
                        }
                        Console.WriteLine("Car needs refueling");
                    }
                    else
                    {
                        if (truck.Driving(value))
                        {
                            Console.WriteLine($"Truck travelled {value} km");
                            continue;
                        }
                        Console.WriteLine("Truck needs refueling");
                    }
                }
                else if (command == "Refuel")
                {
                    if (type == "Car")
                    {
                        car.Refuel(value);
                    }
                    else
                    {
                        truck.Refuel(value);
                    }
                }
            }

            Console.WriteLine($"Car: {car}");
            Console.WriteLine($"Truck: {truck}");
        }
    }
}
