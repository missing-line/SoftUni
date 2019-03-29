using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Race
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] peoples = Console.ReadLine()
                .Split(", ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            Dictionary<string, int> race = new Dictionary<string, int>();
            string line = Console.ReadLine();

            while (line != "end of race")
            {
                foreach (var people in peoples)
                {
                    string pattern = $@"[{people}]+";
                    string patternDigits = @"[0-9]+";
                    MatchCollection match = Regex.Matches(line, pattern);
                    string currName = "";
                    foreach (Match letter in match)
                    {
                        currName += letter;
                    }
                    if (currName == people) //!
                    {
                        string currDistance = string.Empty;
                        MatchCollection matchDigts = Regex.Matches(line, patternDigits);
                        foreach (var digit in matchDigts)
                        {
                            currDistance += digit;
                        }
                        int distance = Distance(currDistance);
                        if (race.ContainsKey(currName))
                        {
                            race[currName] += distance;
                        }
                        else
                        {
                            race.Add(currName, distance);
                        }
                    }
                }
                line = Console.ReadLine();
            }
            int count = 1;
            foreach (var racer in race.OrderByDescending(x => x.Value))
            {
                if (count == 1)
                {
                    Console.WriteLine($"{count}st place: {racer.Key}");
                }
                if (count == 2)
                {
                    Console.WriteLine($"{count}nd place: {racer.Key}");
                }
                if (count == 3)
                {
                    Console.WriteLine($"{count}rd place: {racer.Key}");
                }

                count++;
                if (count > 3)
                {
                    break;
                }
            }
        }
        public static int Distance(string digits)
        {
            int sum = 0;
            for (int i = 0; i < digits.Length; i++)
            {
                sum += int.Parse(digits[i].ToString());
            }
            return sum;
        }
    }
}
