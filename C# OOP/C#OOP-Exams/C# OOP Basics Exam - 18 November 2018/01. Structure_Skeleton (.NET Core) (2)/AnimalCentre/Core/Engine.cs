namespace AnimalCentre.Core
{
    using global::AnimalCentre.Models.Contracts;
    using System;
    using System.Linq;

    public class Engine : IEngine
    {
        private AnimalCentre controller;
        public Engine()
        {
            this.controller = new AnimalCentre();
        }

        public void Run()
        {
            string input;

            while ((input = Console.ReadLine()) != "End")
            {
                string[] data = input
                    .Split()
                    .ToArray();

                string command = data[0];
                string[] execute = data.Skip(1).ToArray();
                try
                {
                    switch (command)
                    {
                        case "RegisterAnimal":
                            Console.WriteLine(this.controller.RegisterAnimal(execute[0], execute[1], int.Parse(execute[2]),
                                int.Parse(execute[3]), int.Parse(execute[4])));
                            break;
                        case "Chip":
                            Console.WriteLine(this.controller.Chip(execute[0], int.Parse(execute[1])));
                            break;
                        case "Vaccinate":
                            Console.WriteLine(this.controller.Vaccinate(execute[0], int.Parse(execute[1])));
                            break;
                        case "Fitness":
                            Console.WriteLine(this.controller.Fitness(execute[0], int.Parse(execute[1])));
                            break;
                        case "DentalCare":
                            this.controller.DentalCare(execute[0], int.Parse(execute[1]));
                            break;
                        case "NailTrim":
                            Console.WriteLine(this.controller.NailTrim(execute[0], int.Parse(execute[1])));
                            break;
                        case "Play":
                            Console.WriteLine(this.controller.Play(execute[0], int.Parse(execute[1])));
                            break;
                        case "Adopt":
                            Console.WriteLine(this.controller.Adopt(execute[0], execute[1]));
                            break;
                        case "History":
                            Console.WriteLine(this.controller.History(execute[0]));
                            break;
                        default:
                            break;
                    }
                }
                catch (Exception e)
                {

                    Console.WriteLine(e.Message);
                }

            }

            Console.WriteLine(this.controller.GetOWners());
        }
    }
}
