using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Roli___The_Coder
{
    class Program
    {
        static void Main(string[] args)
        {
            // 80/100
            string pattern = @"(?<ID>\d+)\s+#(?<event>\S+)";
            string pattern1 = @"(\s+@\S+)";
            List<string> keepId = new List<string>();
            string line = Console.ReadLine();
            var result = new Dictionary<string, List<string>>();           
            while (line != "Time for Code")
            {
                Match match = Regex.Match(line,pattern);
                if (match.Success)
                {
                    List<string> even = match.Value
                        .Split("\t \n , \r".ToCharArray(),StringSplitOptions.RemoveEmptyEntries)
                        .ToList();//' ', '\t','\r','\n'
                    string id = even[0];
                    string nameEven = even[1].Trim('#').Trim();
                    if (!keepId.Contains(id))
                    {
                        keepId.Add(id);
                        if (!result.ContainsKey(nameEven))
                        {
                            result.Add(nameEven,new List<string>());
                            MatchCollection m = Regex.Matches(line,pattern1);
                            foreach (Match name in m)
                            {
                                string curr = name.Value.Trim();
                                if (!result[nameEven].Contains(curr))
                                {
                                    result[nameEven].Add(curr);
                                }
                            }
                        }
                    }
                    else if (keepId.Contains(id))
                    {
                        if (result.ContainsKey(nameEven))
                        {
                            MatchCollection m = Regex.Matches(line, pattern1);
                            foreach (Match name in m)
                            {
                                string curr = name.Value.Trim();
                                if (!result[nameEven].Contains(curr))
                                {
                                    result[nameEven].Add(curr);
                                }
                            }
                        }
                    }
                }
                line = Console.ReadLine();
            }
            foreach (var users in result.OrderByDescending(x=>x.Value.Count).ThenBy(z=>z.Key))
            {
                Console.WriteLine($"{users.Key} - {users.Value.Count}");
                foreach (var Inner in users.Value.OrderBy(l=>l))
                {
                    Console.WriteLine(Inner);
                }
            }
        }
       
    }
}
