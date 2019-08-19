using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Snowwhite
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] line = Console.ReadLine()
                 .Split("<:> ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                 .ToArray();
            Dictionary<string, Dictionary<string, int>> dwarf = new Dictionary<string, Dictionary<string, int>>();
            while (string.Join(" ", line) != "Once upon a time")
            {
                string color = line[1];
                string name = line[0];
                int power = int.Parse(line[2]);
                if (!dwarf.ContainsKey(color))
                {
                    dwarf.Add(color, new Dictionary<string, int>());
                    dwarf[color].Add(name, power);
                }
                else if (dwarf.ContainsKey(color))
                {
                    if (dwarf[color].ContainsKey(name))
                    {
                        if (dwarf[color][name] < power)
                        {
                            dwarf[color][name] = power;
                        }
                    }
                    else
                    {
                        dwarf[color].Add(name, power);
                    }
                }
                line = Console.ReadLine()
                .Split("<:> ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                 .ToArray();
            }
            foreach (var colors in dwarf.OrderByDescending(x => x.Value.Count()))
            {
                foreach (var inner in colors.Value.OrderByDescending(v => v.Value))
                {
                    Console.WriteLine($"({colors.Key}) {inner.Key} <-> {inner.Value}");
                }
            }
        }
    }

}
