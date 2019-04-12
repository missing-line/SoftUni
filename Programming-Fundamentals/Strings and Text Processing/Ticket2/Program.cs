using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Winning_Ticket
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> line = Console.ReadLine()
                .Split(", \t".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                .ToList();
            for (int i = 0; i < line.Count; i++)
            {
                if (line[i].Length == 20)
                {
                    string patternJackpot = @"(\${10}|\^{10}|\#{10}|\@{10})(\1)";
                    string pattern = @"(\${6,9}|\^{6,9}|\#{6,9}|\@{6,9})[^@$#\^]*(\1)";
                    Match matchJackpot = Regex.Match(line[i], patternJackpot);
                    Match match = Regex.Match(line[i], pattern);
                    if (matchJackpot.Success)
                    {
                        string curr = matchJackpot.Groups[1].Value;
                        Console.WriteLine($"ticket \"{line[i]}\" - 10{curr[0]} Jackpot!");
                    }
                    else if (match.Success)
                    {
                        string curr = match.Groups[1].Value;
                        string curr2 = match.Groups[2].Value;
                        if (curr[0] == curr2[0])
                        {
                            if (curr.Length >= curr2.Length)
                            {
                                Console.WriteLine($"ticket \"{line[i]}\" - {curr2.Length}{curr2[0]}");
                            }
                            else
                            {
                                Console.WriteLine($"ticket \"{line[i]}\" - {curr.Length}{curr[0]}");
                            }
                        }
                        else
                        {
                            Console.WriteLine($"ticket \"{line[i]}\" - no match");
                        }

                    }
                    else
                    {
                        Console.WriteLine($"ticket \"{line[i]}\" - no match");
                    }

                }
                else
                {
                    Console.WriteLine("invalid ticket");
                }
            }
        }
    }
}
