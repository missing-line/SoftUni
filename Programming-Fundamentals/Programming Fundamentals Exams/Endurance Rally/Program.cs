using System;
using System.Collections.Generic;
using System.Linq;

namespace Endurance_Rally
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> names = Console.ReadLine()
                .Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                .ToList();
            List<double> zone = Console.ReadLine()
                .Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .ToList();
            List<double> indexes = Console.ReadLine()
                .Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .ToList();
            List<KeyValuePair<string, string>> fuel = new List<KeyValuePair<string, string>>();
            string roadcher = string.Empty;
            string fuelFinish = "";
            for (int i = 0; i < names.Count; i++)
            {
                bool isEmpty = false;
                double curr = (int)names[i][0];
                for (int i1 = 0; i1 < zone.Count; i1++)
                {
                    int currIndex = i1;
                    if (indexes.Any(x => x == currIndex))
                    {
                        curr += zone[i1];
                    }
                    else
                    {
                        curr -= zone[i1];
                    }
                    if (curr <= 0)
                    {
                        curr = i1;
                        roadcher = $"reached {curr.ToString()}";
                        isEmpty = true;
                        break;
                    }
                }
                if (isEmpty)
                {
                    fuel.Add(new KeyValuePair<string, string>(names[i], roadcher));
                }
                else
                {
                    fuelFinish = $"{curr:f2}";
                    fuel.Add(new KeyValuePair<string, string>(names[i], fuelFinish));
                }               
            }
            foreach (var racer in fuel)
            {
                if (racer.Value.Contains("reached"))
                {
                    Console.WriteLine($"{racer.Key} - {racer.Value}");
                }
                else
                {
                    Console.WriteLine($"{racer.Key} - fuel left {racer.Value}");
                }
            }
        }
    }
}
