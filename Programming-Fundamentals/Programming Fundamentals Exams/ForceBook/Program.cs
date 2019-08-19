using System;
using System.Collections.Generic;
using System.Linq;

namespace ForceBook
{
    class Program
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();
            Dictionary<string, string> side = new Dictionary<string, string>();
            Dictionary<string, List<string>> results = new Dictionary<string, List<string>>();
            while (command != "Lumpawaroo")
            {
                if (command.Contains("|"))
                {
                    string[] tokens = command.Split("|");
                    string sides = tokens[0].Trim();
                    string members = tokens[1].Trim();
                    if (!side.ContainsKey(members))
                    {
                        side.Add(members, sides);
                    }
                }
                else if (command.Contains("->"))
                {
                    string[] tokens = command.Split("->");
                    string user = tokens[0].Trim();
                    string sides = tokens[1].Trim();
                    if (!side.ContainsKey(user))
                    {
                        side.Add(user, sides);
                        Console.WriteLine($"{user} joins the {sides} side!");
                    }
                    else if (side.ContainsKey(user) && side[user] != sides)
                    {
                        side[user] = sides;
                        Console.WriteLine($"{user} joins the {sides} side!");
                    }
                }
                command = Console.ReadLine();
            }
            foreach (var kvp in side)
            {
                if (!results.ContainsKey(kvp.Value))
                {
                    results.Add(kvp.Value, new List<string>() { kvp.Key });
                }
                else if (results.ContainsKey(kvp.Value))
                {
                    results[kvp.Value].Add(kvp.Key);
                }
            }
            foreach (var kvp in results)
            {
                kvp.Value.Sort();
            }
            foreach (var kvp in results.OrderByDescending(x=>x.Value.Count).ThenBy(x=>x.Key))
            {
                Console.WriteLine($"Side: {kvp.Key}, Members: {kvp.Value.Count}");
                foreach (var inner in kvp.Value)
                {
                    Console.WriteLine($"! {inner}");
                }
            }
        }
    }
}



