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
            List<string> manipulated = new List<string>();
            Dictionary<string, List<string>> attackedAndDestruction = new Dictionary<string, List<string>>();
            attackedAndDestruction.Add("A", new List<string>());
            attackedAndDestruction.Add("D", new List<string>());
            string patternt = @"@([a-zA-Z]+)[^:!@\->]*:[^@\-!:>]*?(\d+)[^:!@\->]*?![^@\-!:>]*?([A|D])[^@\-!:>]*?![^@\-!:>]*?->[^:!\->@]*?(\d+)";
            for (int i = 0; i < n; i++)
            {
                string line = Console.ReadLine();
                int count = 0;
                for (int j = 0; j < line.Length; j++)
                {
                    if (line[j] == 'a' || line[j] == 'A' || line[j] == 's' || line[j] == 'S'
                        || line[j] == 't' || line[j] == 'T' || line[j] == 'r' || line[j] == 'R')
                    {
                        count++;
                    }
                }
                manipulated.Add(Decrypt(line, count));
            }

            for (int i = 0; i < manipulated.Count; i++)
            {
                Match match = Regex.Match(manipulated[i], patternt);
                if (match.Success)
                {
                    string planet = match.Groups[1].Value;
                    int population = int.Parse(match.Groups[2].Value);
                    string type = match.Groups[3].Value;
                    int soldiers = int.Parse(match.Groups[4].Value);
                    attackedAndDestruction[type].Add(planet);
                }
            }

            foreach (var planet in attackedAndDestruction)
            {
                if (planet.Key == "A")
                {
                    Console.WriteLine($"Attacked planets: {planet.Value.Count}");
                }
                else
                {
                    Console.WriteLine($"Destroyed planets: {planet.Value.Count}");
                }
                foreach (var inner in planet.Value.OrderBy(x => x))
                {
                    Console.WriteLine($"-> {inner}");
                }
            }
        }
        public static string Decrypt(string token, int count)
        {
            string decrypted = string.Empty;
            for (int i = 0; i < token.Length; i++)
            {
                char ch = (char)((int)token[i] - count);
                decrypted += ch;
            }
            return decrypted;
        }
    }
}
