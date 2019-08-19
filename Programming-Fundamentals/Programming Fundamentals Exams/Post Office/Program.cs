using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Post_Office
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> line = Console.ReadLine()
                .Split("|".ToCharArray(),StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            List<string> result = new List<string>();
            string pattern1 = @"[#$%*&]([A-Z]+)[#$%*&]";           
            Match fisrtMtach = Regex.Match(line[0],pattern1);
            char[] find = fisrtMtach.Value.ToCharArray();

            string pattern2 = @"(?<capital>6[5-9]|[78][0-9]|90):(?<length>\d{2})";
            MatchCollection match = Regex.Matches(line[1], pattern2);

            foreach (var letter in find)
            {
                int length = int.Parse(match
              .FirstOrDefault(l => (char)int.Parse(l.Groups["capital"].Value) == letter)
              .Groups["length"].Value);

            }

        }
    }
}
//pattern3 = $@"(?<=\s)\b{ch}\S{{{lenght}}}\b";