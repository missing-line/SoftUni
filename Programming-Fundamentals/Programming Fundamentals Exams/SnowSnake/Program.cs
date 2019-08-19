using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace SnowSnake
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern1 = @"^([^\da-zA-Z]+)*$";
            string pattern2 = @"^([\d|_]+)*?$";
            string pattern3 = @"^([^\da-zA-Z]+)*([\d|_]+)*([a-zA-Z]+)([\d|_]+)*([^\da-zA-Z]+)*$";
            List<string> patterns = new List<string>();

            patterns.Add(pattern1);
            patterns.Add(pattern2);
            patterns.Add(pattern3);
            patterns.Add(pattern2);
            patterns.Add(pattern1);
            while (true)
            {
                List<string> snakes = new List<string>();
                int core = 0;
                for (int i = 0; i < 5; i++)
                {
                    string command = Console.ReadLine();
                    snakes.Add(command);
                    if (i == 2)
                    {
                        Match m = Regex.Match(command,pattern3);
                        if (m.Success)
                        {
                            string findCore = m.Groups[3].Value;
                            core = findCore.Length;
                        }
                    }
                }
                if (IsValidSnake(snakes, patterns) == true)
                {
                    Console.WriteLine("Valid");
                    Console.WriteLine(core);
                    return;
                }
                else
                {
                    Console.WriteLine("Invalid");
                    return;
                }

            }
        }
        static bool IsValidSnake(List<string> snakes, List<string> patterns)
        {
            bool isValid = false;
            int curr = 0;
            foreach (var pattern in patterns)
            {
                isValid = false;

                for (int i = 0 + curr; i < snakes.Count; i++)
                {
                    Match match = Regex.Match(snakes[i], pattern);
                    if (match.Success)
                    {
                        isValid = true;
                        curr++;
                        break;
                    }
                }
                if (isValid == false)
                {
                    break;
                }
            }
            return isValid;

        }

    }
}
