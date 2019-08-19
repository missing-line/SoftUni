using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;


namespace Pokemon_Evolution
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> line = Console.ReadLine()
                .Split("-> ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                .ToList();
            Dictionary<string, List<KeyValuePair<string, int>>> pokemon = new Dictionary<string, List<KeyValuePair<string, int>>>();
            while (string.Join("", line) != "wubbalubbadubdub")
            {
                if (line.Count > 1)
                {
                    string name = line[0];
                    string type = line[1];
                    int n = int.Parse(line[2]);
                    if (!pokemon.ContainsKey(name))
                    {
                        pokemon.Add(name, new List<KeyValuePair<string, int>>());
                        pokemon[name].Add(new KeyValuePair<string, int>(type, n));                      
                    }
                    else
                    {
                        pokemon[name].Add(new KeyValuePair<string, int>(type,n));
                    }
                }
                else
                {
                    string currPokemeon = line[0];
                    foreach (var poke in pokemon)
                    {
                        if (poke.Key == currPokemeon)
                        {
                            Console.WriteLine($"# {poke.Key}");
                            foreach (var inner in poke.Value)
                            {
                                Console.WriteLine($"{inner.Key} <-> {inner.Value}");
                            }
                        }                       
                    }
                }

                line = Console.ReadLine()
                .Split("-> ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                .ToList();
            }
            foreach (var poke in pokemon)
            {
                Console.WriteLine($"# {poke.Key}");
                foreach (var inner in poke.Value.OrderByDescending(x=>x.Value))
                {
                    Console.WriteLine($"{inner.Key} <-> {inner.Value}");
                }
            }
        }
    }
}
