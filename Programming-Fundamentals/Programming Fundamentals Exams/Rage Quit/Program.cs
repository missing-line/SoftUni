using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Rage_Quit
{
    class Program
    {
        static void Main(string[] args)
        {
            string line = Console.ReadLine();
            string pattern = @"([^\d]+)(\d+)";
            StringBuilder results = new StringBuilder();
            
            MatchCollection match = Regex.Matches(line, pattern);
            foreach (Match m in match)
            {
                int n = int.Parse(m.Groups[2].Value);
                string curr = m.Groups[1].Value.ToUpper();
                for (int i = 0; i < n; i++)
                {
                    results.Append(curr);
                }
                //results += string.Concat(Enumerable.Repeat(curr, n));   
                 //result += new StringBuilder().Insert(result.Length - 1,$"{curr}", n).ToString();
            }
            //string remove = RemoveDuplicates(results);
            int count = count = results.ToString().Distinct().Count();
            Console.WriteLine($"Unique symbols used: {count}");
            Console.WriteLine(results);
        }
        public static string RemoveDuplicates(string input)
        {
            return new string(input.ToCharArray().Distinct().ToArray());
        }
    }
}
