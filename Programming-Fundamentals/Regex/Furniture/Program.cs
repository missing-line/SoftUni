using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Furniture
{
    class Program
    {
        static void Main(string[] args)
        {
            string line = Console.ReadLine();
            List<string> furnitures = new List<string>();
            double sum = 0;
            string pattern = @">{2}([a-zA-Z]+)<{2}(\d{1,}\.\d+|\d+)!(\d+)";
            while (line != "Purchase")
            {
                Match match = Regex.Match(line, pattern);
                if (match.Success)
                {
                    string furniture = match.Groups[1].Value;
                    furnitures.Add(furniture);
                    sum += (double.Parse(match.Groups[2].Value) * int.Parse(match.Groups[3].Value));
                }
                line = Console.ReadLine();
            }
            Console.WriteLine("Bought furniture:");
            foreach (var currFurniture in furnitures)
            {
                Console.WriteLine(currFurniture);
            }
            Console.WriteLine($"Total money spend: {sum:f2}");
        }
    }
}
