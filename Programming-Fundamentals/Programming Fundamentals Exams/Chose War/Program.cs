using System;
using System.Text.RegularExpressions;

namespace Chose_War
{
    class Program
    {
        static void Main(string[] args)
        {
            string line = Console.ReadLine();
            string patternDigits = @"[\d]";
            int disheshTime = 0;
            int laundryTime = 0;
            int houseTime = 0;           
            while (line != "wife is happy")
            {
                string patternDishes = @"\<([a-z0-9]+)\>";
                Match matchDishesh = Regex.Match(line,patternDishes);
                if (matchDishesh.Success)
                {
                    string dishesh = matchDishesh.Groups[1].Value;
                    MatchCollection match = Regex.Matches(dishesh,patternDigits);
                    foreach (Match i in match)
                    {
                        disheshTime += int.Parse(i.ToString());
                    }
                }
                string patternHouse = @"\[([A-Z0-9]+)\]";
                Match matchHouse = Regex.Match(line, patternHouse);
                if (matchHouse.Success)
                {
                    string house = matchHouse.Groups[1].Value;
                    MatchCollection match = Regex.Matches(house, patternDigits);
                    foreach (Match i in match)
                    {
                        houseTime += int.Parse(i.ToString());
                    }
                }
                string patternLaundry = @"{([^}]+)}";
                Match matchLaundry = Regex.Match(line, patternLaundry);
                if (matchLaundry.Success)
                {
                    string laundry = matchLaundry.Groups[1].Value;
                    MatchCollection match = Regex.Matches(laundry, patternDigits);
                    foreach (Match i in match)
                    {
                        laundryTime += int.Parse(i.ToString());
                    }
                }                
                line = Console.ReadLine();
            }
            Console.WriteLine($"Doing the dishes - {disheshTime} min.");
            Console.WriteLine($"Cleaning the house - {houseTime} min.");
            Console.WriteLine($"Doing the laundry - {laundryTime} min.");
            Console.WriteLine($"Total - {disheshTime + houseTime + laundryTime} min.");
        }
    }
}
