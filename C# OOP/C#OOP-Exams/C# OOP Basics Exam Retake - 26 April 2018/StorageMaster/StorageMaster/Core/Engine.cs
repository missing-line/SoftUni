namespace StorageMaster.Core
{
    using StorageMaster.Models.Intefaces;
    using System;
    using System.Linq;

    public class Engine : IEngine
    {
        private StorageController storageController;

        public Engine()
        {
            this.storageController = new StorageController();
        }

        public void Run()
        {
            string input;

            while ((input = Console.ReadLine()) != "END")
            {
                string[] tokens = input
                    .Split()
                    .ToArray();

                string command = tokens[0];
                try
                {
                    switch (command)
                    {
                        case "AddProduct":
                            Console.WriteLine(this.storageController.AddProduct(tokens[1], double.Parse(tokens[2])));
                            break;
                        case "RegisterStorage":
                            Console.WriteLine(this.storageController.RegisterStorage(tokens[1], tokens[2]));
                            break;
                        case "SelectVehicle":
                            Console.WriteLine(this.storageController.SelectVehicle(tokens[1], int.Parse(tokens[2])));
                            break;
                        case "LoadVehicle":
                            string[] names = tokens.Skip(1).ToArray();
                            Console.WriteLine(this.storageController.LoadVehicle(names));
                            break;
                        case "UnloadVehicle":
                            Console.WriteLine(this.storageController.UnloadVehicle(tokens[1], int.Parse(tokens[2])));
                            break;
                        case "GetStorageStatus":
                            Console.WriteLine(this.storageController.GetStorageStatus(tokens[1]));
                            break;
                        case "SendVehicleTo":
                            Console.WriteLine(this.storageController.SendVehicleTo(tokens[1],int.Parse(tokens[2]),tokens[3]));
                            break;
                        default:
                            break;
                    }
                }
                catch (Exception e)
                {

                    Console.WriteLine($"Error: {e.Message}");
                }

            }
                Console.WriteLine(this.storageController.GetSummary());
        }
    }
}

