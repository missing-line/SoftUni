namespace Auto_Repair_and_Service
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main(string[] args)
        {
            string[] vehicles = Console.ReadLine()
                .Split(" \t".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            Queue<string> queueVehicles = new Queue<string>(vehicles);
            Stack<string> served = new Stack<string>();

            string command = Console.ReadLine();

            while (command != "End")
            {

                if (command == "Service" && queueVehicles.Count() != 0)
                {
                    string servedVehicle = queueVehicles.Dequeue();
                    served.Push(servedVehicle);
                    Console.WriteLine($"Vehicle {servedVehicle} got served.");
                }
                else if (command == "History")
                {
                    Console.WriteLine(string.Join(", ", served.ToArray()));
                }
                else if(command.Contains("CarInfo-"))
                {
                    string checkVehicle = command.Substring(8);
                    if (served.Contains(checkVehicle))
                    {
                        Console.WriteLine("Served.");
                    }
                    else
                    {
                        Console.WriteLine("Still waiting for service.");
                    }
                }
                command = Console.ReadLine();
            }
            if (queueVehicles.Count != 0)
            {
                Console.WriteLine($"Vehicles for service: {string.Join(", ", queueVehicles.ToArray())}");
            }
            Console.WriteLine($"Served vehicles: {string.Join(", ", served.ToArray())}");
        }
    }
}
