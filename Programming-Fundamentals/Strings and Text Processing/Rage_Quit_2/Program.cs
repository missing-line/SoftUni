using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Rage_Quit_2
{
    class Program
    {
        static void Main(string[] args)
        {
            string line = Console.ReadLine();
            string patter = @"([^0-9]+)(\d+)";
            MatchCollection match = Regex.Matches(line, patter);
            StringBuilder results = new StringBuilder();         
            foreach (Match m in match)
            {
                string curr = m.Groups[1].Value.ToUpper();
                int currN = int.Parse(m.Groups[2].Value);
                for (int i = 0; i < currN; i++)
                {
                    results.Append(curr);
                }               
            }
            char[] removeDuplicate = results.ToString().Distinct().ToArray();
            Console.WriteLine($"Unique symbols used: {removeDuplicate.Length}");
            Console.WriteLine(results);
        }
    }
}
