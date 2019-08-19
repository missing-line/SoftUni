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
            string pattern1 = @"[^\/\*\.\+\-\d]";
            string pattern2 = @"([-|+]*[\d\.]+)([*\/]*)";           
            string[] line = Console.ReadLine()
                .Split(new char[] { ' ', ',', '\t', '\n' }, StringSplitOptions.RemoveEmptyEntries);
            Array.Sort(line);
            List<string> rs = new List<string>();
            foreach (var lines in line)
            {
                double dmg = 0;
                string damage = "";
                decimal health = 0;
                string result = "";
                MatchCollection match1 = Regex.Matches(lines, pattern1);
                foreach (Match letter in match1)
                {
                    damage += letter.ToString();
                }
                dmg = Dmg(damage);
                MatchCollection match2 = Regex.Matches(lines, pattern2);
                foreach (Match digits in match2)
                {
                    health += decimal.Parse(digits.Groups[1].ToString());
                }
                foreach (var symbol in lines)
                {
                    if (symbol.ToString() == "*")
                    {
                        health *= 2;
                    }
                    else if (symbol.ToString() == "/")
                    {
                        health /= 2;
                    }
                }
                
                result += lines + " " + "-" + " " + dmg.ToString() + " " + "health," +
                     " " + $"{ health:f2}" + " " + "damage";
                rs.Add(result);
            }

            foreach (var word in rs)
            {
                Console.WriteLine(word);
            }
        }
        static double Dmg(string curr)
        {
            double n = 0;
            for (int i = 0; i < curr.Length; i++)
            {
                n += (double)curr[i];
            }
            return n;
        }
    }
}
