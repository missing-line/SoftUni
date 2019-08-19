using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;


namespace Cubic_s_Messages
{
    class Program
    {
        static void Main(string[] args)
        {
            string line = Console.ReadLine();

            int n = int.Parse(Console.ReadLine()); 
            
            Dictionary<string, string> print = new Dictionary<string, string>();
            while (true)
            {
                string decryptMsg = "";

                string pattern = $@"^(\d+)([a-zA-Z]+)";

                Match match = Regex.Match(line, pattern);
                if (match.Success)
                {                   
                    string before = match.Groups[1].Value;
                    string msg = match.Groups[2].Value;                   
                    string after = line.Remove(0, before.Length);

                    after = after.Remove(0, msg.Length);

                    if (after.Any(char.IsLetter) || msg.Length != n)
                    {
                        for (int i = 0; i < line.Length; i++)
                        {
                            break;
                        }
                    }
                    else
                    {
                        string patternDigits = @"(\d+)";

                        Match mDigit = Regex.Match(after, patternDigits);

                        after = mDigit.Value;

                        decryptMsg = FindMsg(msg,before,after);

                        if (!print.ContainsKey(msg))
                        {
                            print.Add(msg,decryptMsg);
                        }
                    }
                }
                line = Console.ReadLine();
                if (line == "Over!")
                {
                    break;
                }
                n = int.Parse(Console.ReadLine());
            }
            foreach (var massages in print)
            {
                Console.WriteLine($"{massages.Key} == {massages.Value}");
            }
        }
        static string FindMsg(string line, string before, string after)
        {
            string msg = "";
            for (int i = 0; i <= before.Length - 1; i++)
            {
                int curr = int.Parse(before[i].ToString());
                if (curr >= 0 && curr < line.Length)
                {
                    msg += line[curr];
                }
                else
                {
                    msg += " ";
                }
            }
            for (int i = 0; i <= after.Length - 1; i++)
            {
                int curr = int.Parse(after[i].ToString());
                if (curr >= 0 && curr < line.Length)
                {
                    msg += line[curr];
                }
                else
                {
                    msg += " ";
                }
            }
            return msg;
        }
    }
}
