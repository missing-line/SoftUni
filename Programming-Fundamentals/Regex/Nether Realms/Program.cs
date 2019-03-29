using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Nether_Realms
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] tokens = Console.ReadLine().Split(", \t".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            var demons = new Dictionary<string, KeyValuePair<double, double>>();
            string patternLetters = @"[^\/\*\.\+\-\d]";
            string patternDigits = @"[-|+]*[\d\.]+";
            for (int i = 0; i < tokens.Length; i++)
            {
                double health = 0;
                double dmg = 0;
                MatchCollection matchLetters = Regex.Matches(tokens[i], patternLetters);
                foreach (Match letter in matchLetters)
                {
                    string curr = letter.Value;
                    health += (int)curr[0];
                }
                MatchCollection matchDigits = Regex.Matches(tokens[i], patternDigits);
                foreach (Match digit in matchDigits)
                {
                    dmg += double.Parse(digit.ToString()); 
                }
                foreach (var symbol in tokens[i])
                {
                    if (symbol.ToString() == "/")
                    {
                        dmg /= 2;
                    }
                    else if (symbol.ToString() == "*")
                    {
                        dmg *= 2;
                    }
                }              
                demons.Add(tokens[i], new KeyValuePair<double, double>(health,dmg));               
            }
            foreach (var demon in demons.OrderBy(x => x.Key))
            {
                Console.WriteLine($"{demon.Key} - {demon.Value.Key} health, {(demon.Value.Value):f2} damage ");
            }
        }
    }
}
