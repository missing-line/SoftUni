namespace Problem_2._Vehicle_Catalogue
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    public class Program
    {
        public static void Main(string[] args)
        {
            List<string> line = Console.ReadLine()
                .Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            List<Vihicle> vihicles = new List<Vihicle>();

            while (line[0] != "End")
            {
                Vihicle curr = new Vihicle();

                curr.Type = char.ToUpper(line[0][0]) + line[0].Substring(1).ToLower();
                curr.Model = line[1];
                curr.Color = line[2];
                curr.Horsepower = double.Parse(line[3]);
                vihicles.Add(curr);

                line = Console.ReadLine()
                .Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                .ToList();
            }
            string type = Console.ReadLine();
            while (type != "Close the Catalogue")
            {
                if (vihicles.Any(x => x.Model == type))
                {
                    Vihicle etx = vihicles.First(z => z.Model == type);
                    Console.WriteLine($"Type: {etx.Type}");
                    Console.WriteLine($"Model: {etx.Model}");
                    Console.WriteLine($"Color: {etx.Color}");
                    Console.WriteLine($"Horsepower: {etx.Horsepower}");
                }
                type = Console.ReadLine();
            }
            if (vihicles.Where(x => x.Type == "Car").Count() > 0)
            {
                double carPower = vihicles.Where(x => x.Type == "Car").Select(x => x.Horsepower).Average();
                Console.WriteLine($"Cars have average horsepower of: {carPower:f2}.");
            }
            else
            {
                Console.WriteLine($"Cars have average horsepower of: 0.00.");
            }
            if (vihicles.Where(x => x.Type == "Truck").Count() > 0)
            {
                double truckPower = vihicles.Where(x => x.Type == "Truck").Select(x => x.Horsepower).Average();
                Console.WriteLine($"Trucks have average horsepower of: {truckPower:f2}.");
            }
            else
            {
                Console.WriteLine($"Trucks have average horsepower of: 0.00.");
            }
        }
        class Vihicle
        {
            public string Type { set; get; }
            public string Model { set; get; }
            public string Color { set; get; }
            public double Horsepower { set; get; }

        }
    }
}
