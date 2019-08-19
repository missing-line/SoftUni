using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Football_Stranding
{
    class Program
    {
        static void Main(string[] args)
        {
                     // 90 / 100
            string forPattern = Console.ReadLine();
            string patternTeams = $@"([{forPattern}]+)([a-zA-Z]+|\s*)(\1)";
            string patterScore = @"(\d+):(\d+)";
            string line = Console.ReadLine();
            Dictionary<string, long> winers = new Dictionary<string, long>();
            Dictionary<string, long> bestGoals = new Dictionary<string, long>();
            while (line != "final")
            {
                string firstT = "";
                string secondT = "";
                long firstScore = 0;
                long secScore = 0;
                MatchCollection match = Regex.Matches(line, patternTeams);
                char[] first = match[0].Groups[2].Value.ToUpper().ToArray();
                char[] second = match[1].Groups[2].Value.ToUpper().ToArray();
                Array.Reverse(first);
                Array.Reverse(second);
                firstT = Team(first);
                secondT = Team(second);
                Match score = Regex.Match(line, patterScore);
                if (score.Success)
                {
                    firstScore = long.Parse(score.Groups[1].Value);
                    secScore = long.Parse(score.Groups[2].Value);
                    if (!bestGoals.ContainsKey(firstT))
                    {
                        bestGoals.Add(firstT, firstScore);
                    }
                    else if (bestGoals.ContainsKey(firstT))
                    {
                        bestGoals[firstT] += firstScore;
                    }
                    if (!bestGoals.ContainsKey(secondT))
                    {
                        bestGoals.Add(secondT, secScore);
                    }
                    else if (bestGoals.ContainsKey(secondT))
                    {
                        bestGoals[secondT] += secScore;
                    }
                }
                if (firstScore > secScore)
                {
                    string win = firstT;
                    string loser = secondT;
                    if (!winers.ContainsKey(win))
                    {
                        winers.Add(win, 3);
                    }
                    else if (winers.ContainsKey(win))
                    {
                        winers[win] += 3;
                    }
                    if (!winers.ContainsKey(loser))
                    {
                        winers.Add(loser, 0);
                    }
                    
                }
                else if (firstScore < secScore)
                {
                    string loser = firstT;
                    string win = secondT;
                    if (!winers.ContainsKey(win))
                    {
                        winers.Add(win, 3);
                    }
                    else if (winers.ContainsKey(win))
                    {
                        winers[win] += 3;
                    }
                    if (!winers.ContainsKey(loser))
                    {
                        winers.Add(loser, 0);
                    }
                    
                }
                else if (firstScore == secScore)
                {
                    string loser = firstT;
                    string win = secondT;
                     if (winers.ContainsKey(win))
                    {
                        winers[win] += 1;
                    }
                    else if (!winers.ContainsKey(win))
                    {
                        winers.Add(win, 1);
                    }
                    if (winers.ContainsKey(loser))
                    {
                        winers[loser] += 1;
                    }                  
                    else if (!winers.ContainsKey(loser))
                    {
                        winers.Add(loser, 1);
                    }
                    
                }
                line = Console.ReadLine();
            }
            int count = 0;
            Console.WriteLine("League standings:");
            foreach (var standing in winers.OrderByDescending(i => i.Value).ThenBy(i => i.Key))
            {
                count++;
                Console.WriteLine($"{count}. {standing.Key} {standing.Value}");
            }
            count = 0;
            Console.WriteLine("Top 3 scored goals:");
            foreach (var team in bestGoals.OrderBy(x => x.Key).OrderByDescending(i => i.Value))
            {
                count++;
                Console.WriteLine($"- {team.Key} -> {team.Value}");
                if (count == 3)
                {
                    return;
                }
            }

        }
        static string Team(char[] teams)
        {
            string currTeam = string.Empty;
            for (int i = 0; i < teams.Length; i++)
            {
                currTeam += teams[i].ToString();
            }
            return currTeam;
        }
    }
}
