namespace FootballTeamGenerator
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    public class Program
    {
        public static void Main(string[] args)
        {
            //string[] input = Console.ReadLine()
            //    .Split(";".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
            //    .ToArray();

            var teams = new List<Team>();

            string arg;

            while ((arg = Console.ReadLine()) != "END")
            {
                string[] array = arg
                     .Split(";".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                     .ToArray();

                try
                {
                    string command = array[0];
                    if (command == "Team")
                    {
                        teams.Add(new Team(array[1]));
                    }
                    else if (command == "Add")
                    {
                        var team = teams.FirstOrDefault(t => t.Name == array[1]);
                        if (team == null)
                        {
                            throw new ArgumentException($"Team {array[1]} does not exist.");
                        }
                        string namePlayer = array[2];
                        int endurance = int.Parse(array[3]);
                        int sprint = int.Parse(array[4]);
                        int dribble = int.Parse(array[5]);
                        int passing = int.Parse(array[6]);
                        int shooting = int.Parse(array[7]);

                        Player player = new Player(namePlayer, endurance, sprint, dribble, passing, shooting);
                        team.Adding(player);
                    }
                    else if (command == "Remove")
                    {
                        var team = teams.FirstOrDefault(t => t.Name == array[1]);
                        if (team == null)
                        {
                            throw new ArgumentException($"Team {array[1]} does not exist.");
                        }

                        team.Remove(array[2]);
                    }
                    else if (command == "Rating")
                    {
                        var team = teams.FirstOrDefault(t => t.Name == array[1]);
                        if (team == null)
                        {
                            throw new ArgumentException($"Team {array[1]} does not exist.");
                        }

                        Console.WriteLine($"{team.Name} - {team.Rating}");
                    }
                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message);
                };                                            
            }
        }
    }
}
