using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Bar_Income
{
    class Program
    {
        static void Main(string[] args)
        {//%([A-Z][a-z]+)%[^|$%.]*<(\w+)>[^|$%.]*\|(\d+)\|[^|$%.]*?(\d+|\d+\.\d{1,})\$
            string line = Console.ReadLine();
            string pattern = @"^\%([A-Z][a-z]{1,})\%[^\|\$\.\%]*?\<(\w+)\>[^\|\$\.\%]*?\|[^\|\$\.\%]*?(\d{1,})\|[^\|\$\.\%]*?(\d{1,}\.\d{1,}|\d{1,})\$$";
            string result = "";
            List<string> party = new List<string>();
            double total = 0;
            while (line != "end of shift")
            {
                Match match = Regex.Match(line,pattern);
                if (match.Success)
                {
                    string name = match.Groups[1].Value;
                    string product = match.Groups[2].Value;
                    int quantity = int.Parse(match.Groups[3].Value);
                    double price = double.Parse(match.Groups[4].Value);
                    string digis = ($"{quantity * price:f2}").ToString();
                    total += quantity * price;
                    result = name + ":" + " " + product + " " + "-" + " " + digis;
                    party.Add(result);
                }
                line = Console.ReadLine();
            }
            foreach (var person in party)
            {
                Console.WriteLine(person);
            }
            Console.WriteLine($"Total income: {total:f2}");
        }
    }
}
