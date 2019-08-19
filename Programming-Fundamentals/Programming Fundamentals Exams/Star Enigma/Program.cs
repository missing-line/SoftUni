using System;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Star_Enigma
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, List<string>> printing = new Dictionary<string, List<string>>();
            printing.Add("A", new List<string>());
            printing.Add("D", new List<string>());

            int key = 0;

            List<string> planets = new List<string>();

            string pattern = @"[sStTaArR]";

            for (int i = 0; i < n; i++)
            {
                string decrypt = "";
                string curr = "";

                string line = Console.ReadLine();
                MatchCollection match = Regex.Matches(line, pattern);

                foreach (Match letter in match)
                {
                    decrypt += letter;
                }
                key = decrypt.Length;
                curr = FindMsg(line, key);
                planets.Add(curr);
            }
            for (int i = 0; i < planets.Count; i++)
            {
                string pattern1 = @"@([a-zA-Z]+)[^:!@\->]*:[^@\-!:>]*?(\d+)[^:!@\->]*?![^@\-!:>]*?([A|D])[^@\-!:>]*?![^@\-!:>]*?->[^:!\->@]*?(\d+)";
                Match matchF = Regex.Match(planets[i], pattern1);
                if (matchF.Success)
                {
                    string planetF = matchF.Groups[1].Value;

                    int population = int.Parse(matchF.Groups[2].Value);

                    string type = matchF.Groups[3].Value;

                    int soldiers = int.Parse(matchF.Groups[4].Value);

                    if (printing.ContainsKey(type))
                    {
                        printing[type].Add(planetF);
                    }
                }
            }          
            foreach (var kvp in printing.OrderBy(x => x.Key))
            {
                if (kvp.Key == "A")
                {
                    Console.WriteLine($"Attacked planets: {kvp.Value.Count}");                 
                }
                else
                {
                    Console.WriteLine($"Destroyed planets: {kvp.Value.Count}");                 
                }
                foreach (var Inner in kvp.Value.OrderBy(x=>x))
                {
                    Console.WriteLine($"-> {Inner}");
                }
            }
        }
        static string FindMsg(string curr, int n)
        {
            string find = "";
            for (int i = 0; i < curr.Length; i++)
            {
                find += (char)(curr[(int)i] - n);
            }
            return find;
        }
    }
}
