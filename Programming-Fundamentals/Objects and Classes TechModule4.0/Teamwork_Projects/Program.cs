namespace Teamwork_projects
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    public class Program
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<Team> teams = new List<Team>();

            string line = Console.ReadLine();
            int count = 0;

            while (line != "end of assignment")
            {
                if (line.Contains("->"))
                {
                    string[] curr = line
                        .Split("->".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                        .ToArray();
                    Team currTeam = new Team();

                    currTeam.nameTeam = curr[1];
                    currTeam.Members = new List<string>();

                    if (teams.All(x => x.nameTeam != curr[1]))
                    {
                        Console.WriteLine($"Team {curr[1]} does not exist!");
                    }
                    else if (teams.Any(x => x.Members.Contains(curr[0])) || teams.Any(c => c.Creator == curr[0]))
                    {
                        Console.WriteLine($"Member {curr[0]} cannot join team {curr[1]}!");
                    }
                    else /*if(teams.All(x=>x.Creator != curr[0]))*/
                    {
                        Team etx = teams.Find(x => x.nameTeam == curr[1]);
                        etx.Members.Add(curr[0]);
                    }
                }
                else
                {
                    string[] curr = line
                        .Split("-".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                       .ToArray();

                    Team currTeam = new Team();

                    currTeam.nameTeam = curr[1];
                    currTeam.Creator = curr[0];
                    currTeam.Members = new List<string>();

                    if (teams.Any(z => z.nameTeam == curr[1]))
                    {
                        Console.WriteLine($"Team {curr[1]} was already created!");
                    }
                    else if (teams.Any(x => x.Creator == currTeam.Creator))
                    {
                        Console.WriteLine($"{curr[0]} cannot create another team!");
                    }
                    else if (count < n)
                    {
                        teams.Add(currTeam);
                        count++;
                        Console.WriteLine($"Team {curr[1]} has been created by {curr[0]}!");
                    }

                }
                line = Console.ReadLine();
            }

            foreach (var user in teams.OrderByDescending(x => x.Members.Count).ThenBy(l => l.nameTeam))
            {
                if (user.Members.Count > 0)
                {
                    Console.WriteLine($"{user.nameTeam}");
                    Console.WriteLine($"- {user.Creator}");
                    foreach (var member in user.Members.OrderBy(l => l))
                    {
                        Console.WriteLine($"-- {member}");
                    }
                }
            }
            Console.WriteLine("Teams to disband:");
            foreach (var user in teams.OrderBy(x => x.nameTeam))
            {
                if (user.Members.Count == 0)
                {
                    Console.WriteLine($"{user.nameTeam}");
                }
            }
        }
    }
    public class Team
    {
        public string nameTeam { set; get; }
        public string Creator { set; get; }
        public List<string> Members { set; get; }
    }
}
