namespace VehiclesExtension
{
    using System;
    using System.Linq;

    public class Program
    {
        public static void Main(string[] args)
        {
            string[] carArgs = Console.ReadLine()
                .Split()
                .ToArray();

            double carQuantity = double.Parse(carArgs[1]);
            double carConsumption = double.Parse(carArgs[2]);
            double carTankCapacity = double.Parse(carArgs[3]);

            Vehicle car = new Car(carQuantity, carConsumption, carTankCapacity);

            string[] truckArgs = Console.ReadLine()
                .Split()
                .ToArray();

            double truckQuantity = double.Parse(truckArgs[1]);
            double truckConsumption = double.Parse(truckArgs[2]);
            double truckTankCapacity = double.Parse(truckArgs[3]);

            Vehicle truck = new Truck(truckQuantity, truckConsumption, truckTankCapacity);

            string[] buskArgs = Console.ReadLine()
                .Split()
                .ToArray();

            double busQuantity = double.Parse(buskArgs[1]);
            double busConsumption = double.Parse(buskArgs[2]);
            double busTankCapacity = double.Parse(buskArgs[3]);

            Vehicle bus = new Bus(busQuantity, busConsumption, busTankCapacity);

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] arr = Console.ReadLine()
               .Split()
               .ToArray();

                string command = arr[0];
                string type = arr[1];
                double value = double.Parse(arr[2]);

                if (type == "Car")
                {
                    if (command == "Refuel")
                    {
                        if (value <= 0)
                        {
                            Console.WriteLine("Fuel must be a positive number");
                        }
                        else if (car.FuelQuantity + value > car.TankCapacity)
                        {
                            Console.WriteLine($"Cannot fit {value} fuel in the tank");
                        }
                        else
                        {
                            car.Refuel(value);
                        }
                    }
                    else if (command == "Drive")
                    {
                        Console.WriteLine(car.Driving(value));
                    }

                }
                else if (type == "Truck")
                {
                    if (command == "Refuel")
                    {
                        if (value <= 0)
                        {
                            Console.WriteLine("Fuel must be a positive number");
                        }
                        else if (truck.FuelQuantity + value > truck.TankCapacity)
                        {
                            Console.WriteLine($"Cannot fit {value} fuel in the tank");
                        }
                        else
                        {
                            truck.Refuel(value);
                        }
                    }
                    else if (command == "Drive")
                    {
                        Console.WriteLine(truck.Driving(value));
                    }
                }
                else if (type == "Bus")
                {
                    if (command == "Refuel")
                    {
                        if (value <= 0)
                        {
                            Console.WriteLine("Fuel must be a positive number");
                        }
                        else if (bus.FuelQuantity + value > bus.TankCapacity)
                        {
                            Console.WriteLine($"Cannot fit {value} fuel in the tank");
                        }
                        else
                        {
                            bus.Refuel(value);
                        }
                    }
                    else if (command == "Drive")
                    {
                        Console.WriteLine(bus.Driving(value));
                    }
                    else if (command == "DriveEmpty")
                    {
                        bus.FuelConsumption -= 1.4;
                        Console.WriteLine(bus.Driving(value));
                        bus.FuelConsumption += 1.4;

                    }
                }
            }
            Console.WriteLine(car);
            Console.WriteLine(truck);
            Console.WriteLine(bus);
        }
    }
}
