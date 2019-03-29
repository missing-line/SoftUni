using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace SoftUni_Bar_Income
{
    class Program
    {
        static void Main(string[] args)
        {
            string line = Console.ReadLine();
            List<string> results = new List<string>();
            double total = 0;
            string pattern = @"^%([A-Z][a-z]+)%[^\|\$\.\%]*?\<([a-zA-Z_0-9]+)\>[^\|\$\.\%]*?\|[^\|\$\.\%]*?(\d+)\|[^\|\$\.\%]*?(\d+\.\d+|\d+)\$$";
            //string pattern = @"^\%([A-Z][a-z]*)\%[^\|\$\.\%]*?\<(\w+)\>[^\|\$\.\%]*?\|[^\|\$\.\%]*?(\d{1,})\|[^\|\$\.\%]*?(\d{1,}\.\d{1,}|\d{1,})\$$";
            while (line != "end of shift")
            {
                Match match = Regex.Match(line,pattern);
                if (match.Success)
                {
                    string name = match.Groups[1].Value;
                    string product = match.Groups[2].Value;
                    int quantity = int.Parse(match.Groups[3].Value);
                    double price = double.Parse(match.Groups[4].Value);
                    string curResult = $"{name}: {product} - {(quantity * price):f2}";
                    results.Add(curResult);
                    total += (quantity * price);
                }
                line = Console.ReadLine();
            }
            foreach (var result in  results)
            {
                Console.WriteLine(result);
            }
            Console.WriteLine($"Total income: {total:f2}");
        }
    }
}
