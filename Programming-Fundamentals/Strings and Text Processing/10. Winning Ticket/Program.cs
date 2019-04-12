using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _10._Winning_Ticket
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] line = Console.ReadLine().Split(" ,\t".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).ToArray();
            List<string> resultTickets = new List<string>();
            string pattern1 = @"([@]+)";
            string pattern2 = @"([#]+)";
            string pattern3 = @"([$]+)";
            string pattern4 = @"([\^]+)";
            for (int i = 0; i < line.Length; i++)
            {
                if (line[i].Length != 20)
                {
                    string invalid = $"invalid ticket";
                    resultTickets.Add(invalid);
                    continue;
                }
                string first = string.Empty;
                string firstPart = line[i].Substring(0, line[i].Length / 2);
                string secondPart = line[i].Substring(line[i].Length / 2, line[i].Length / 2);
                Match match1 = Regex.Match(firstPart, pattern1);
                Match match2 = Regex.Match(firstPart, pattern2);
                Match match3 = Regex.Match(firstPart, pattern3);
                Match match4 = Regex.Match(firstPart, pattern4);
                if (match1.Success)
                {
                    if (secondPart.Contains(match1.Groups[1].Value))
                    {
                        string curr = match1.Groups[1].Value;
                        if (curr.Length > first.Length)
                        {

                            first = curr;
                        }                                          
                    }

                }
                if (match2.Success)
                {
                    if (secondPart.Contains(match2.Groups[1].Value))
                    {
                        string curr = match2.Groups[1].Value;
                        if (curr.Length > first.Length)
                        {
                            first = curr;
                        }
                    }
                }
                if (match3.Success)
                {
                    if (secondPart.Contains(match3.Groups[1].Value))
                    {
                        string curr = match3.Groups[1].Value;
                        if (curr.Length > first.Length)
                        {
                            first = curr;
                        }
                    }
                }
                if (match4.Success)
                {
                    if (secondPart.Contains(match4.Groups[1].Value))
                    {
                        string curr = match4.Groups[1].Value;
                        if (curr.Length > first.Length)
                        {
                            first = curr;
                        }
                    }
                }
                if (first == string.Empty)
                {
                    string noMatch = $"ticket \"{line[i]}\" - no match";
                    resultTickets.Add(noMatch);
                }
                else if (first.Length == 10)
                {
                    if (first.Length == 10)
                    {
                        string winnerJackpot = $"ticket \"{line[i]}\" - 10{first[0]} Jackpot!";
                        resultTickets.Add(winnerJackpot);
                    }
                }
                else if (first.Length >= 6 && first.Length <= 9)
                {
                    string winner = $"ticket \"{line[i]}\" - {first.Length}{first[0]}";
                    resultTickets.Add(winner);
                }
            }
            foreach (var tickets in resultTickets)
            {
                Console.WriteLine(tickets);
            }
        }
    }
}
