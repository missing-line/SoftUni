using System;
using System.Collections.Generic;
using System.Linq;

namespace SoftUni_Karaoke
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> participant = Console.ReadLine()
                .Split(", ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                .ToList();
            List<string> songs = Console.ReadLine().Trim()              
                .Split(",".ToCharArray())
                .ToList();
            List<string> karaoke = Console.ReadLine()
               .Split(",".ToCharArray())
               .ToList();
            for (int i = 0; i < songs.Count; i++)
            {
                songs[i] = songs[i].Trim();
            }
            Dictionary<string, List<string>> result = new Dictionary<string, List<string>>();
            while (karaoke[0] != "dawn")
            {
                string name = karaoke[0].Trim();
                string song = karaoke[1].Trim();
                string awards = karaoke[2].Trim();
                if (participant.Contains(name) && songs.Contains(song))
                {
                    if (!result.ContainsKey(name))
                    {
                        result.Add(name, new List<string>() { awards });
                    }
                    else if (result.ContainsKey(name) && !result[name].Contains(awards))
                    {
                        result[name].Add(awards);
                    }
                }
                karaoke = Console.ReadLine()
               .Split(",".ToCharArray())
               .ToList();
            }
            if (result.Count() == 0)
            {
                Console.WriteLine("No awards");
                return;
            }
            foreach (var award in result.OrderByDescending(x=>x.Value.Count()).ThenBy(l=>l.Key))
            {
               
                Console.WriteLine($"{award.Key}: {award.Value.Count()} awards");
                foreach (var inner in award.Value.OrderBy(z=>z))
                {
                    Console.WriteLine($"--{inner}");
                }
            }
           
        }
    }
}
