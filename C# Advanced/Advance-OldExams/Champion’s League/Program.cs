namespace Champion_s_League
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static object Dicitonary { get; private set; }

        public static void Main(string[] args)
        {
            var teams = new Dictionary<string, List<string>>();
            var winners = new Dictionary<string, int>();

            string input;

            while ((input = Console.ReadLine()) != "stop")
            {
                string[] arr = input
                    .Split(new string[] { " | " },StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string firstTeam = arr[0];
                string secondTeam = arr[1];

                if (!teams.ContainsKey(firstTeam))
                {
                    teams.Add(firstTeam, new List<string>());
                    winners.Add(firstTeam, 0);

                }
                if (!teams.ContainsKey(secondTeam))
                {
                    teams.Add(secondTeam, new List<string>());
                    winners.Add(secondTeam, 0);
                }
                teams[firstTeam].Add(secondTeam);
                teams[secondTeam].Add(firstTeam);

                string[] score = arr.Skip(2).ToArray();

                string[] firstScore = score[0]
                    .Split(":".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).ToArray();

                string[] secondScore = score[1]
                    .Split(":".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).ToArray();

                int firstTeamScore = int.Parse(firstScore[0]) + int.Parse(secondScore[1]);
                int secondTeamScore = int.Parse(firstScore[1]) + int.Parse(secondScore[0]);

                if (firstTeamScore > secondTeamScore)
                {
                    winners[firstTeam]++;
                }
                else if (firstTeamScore < secondTeamScore)
                {
                    winners[secondTeam]++;
                }
                else
                {
                    if (int.Parse(firstScore[1]) > int.Parse(secondScore[1]))
                    {
                        winners[secondTeam]++;
                    }
                    else
                    {
                        winners[firstTeam]++;
                    }
                }
            }

            foreach (var team in winners.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                Console.WriteLine(team.Key);
                Console.WriteLine($"- Wins: {team.Value}");

                var currWinner = teams.First(x => x.Key == team.Key);
                currWinner.Value.Sort();

                Console.WriteLine($"- Opponents: {string.Join(", ", currWinner.Value)}");
            }
        }
    }
}
