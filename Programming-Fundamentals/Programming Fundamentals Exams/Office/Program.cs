using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;


namespace Post_Office
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> line = Console.ReadLine()
                .Split('|', StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            List<string> result = new List<string>();
            string pattern1 = @"[#$%*&]([A-Z]+)[#$%*&]";
            Match fisrtMtach = Regex.Match(line[0], pattern1);
            char[] find = fisrtMtach.Groups[1].Value.ToCharArray();

            string pattern2 = @"(?<capital>6[5-9]|[78][0-9]|90):(?<length>\d{2})";
            MatchCollection match = Regex.Matches(line[1], pattern2);
            string[] words = line[2].Split();
            foreach (var letter in find)
            {
                int length = int.Parse(match
               .FirstOrDefault(l => (char)int.Parse(l.Groups[1].Value) == letter)
               .Groups[2].Value);
                string pattern3 = $@"^{letter}\S{{{length}}}$";

                foreach (var word in words)
                {
                    if (Regex.IsMatch(word,pattern3))
                    {
                        
                        Console.WriteLine(word);
                        break;
                    }
                }
            }
            
        }
    }
}
//pattern3 = $@"(?<=\s)\b{ch}\S{{{lenght}}}\b";