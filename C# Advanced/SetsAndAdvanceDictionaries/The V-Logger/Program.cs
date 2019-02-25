namespace The_V_Logger
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, HashSet<string>>> vloggers = new Dictionary<string, Dictionary<string, HashSet<string>>>();


            string input = Console.ReadLine();


            while (input != "Statistics")
            {
                if (input.Contains("joined"))
                {
                    string[] line = input.Split(" joined ").ToArray();
                    string vloggerName = line[0];
                    if (!vloggers.ContainsKey(vloggerName))
                    {
                        vloggers.Add(vloggerName, new Dictionary<string, HashSet<string>>());
                        vloggers[vloggerName].Add("followers", new HashSet<string>());
                        vloggers[vloggerName].Add("following", new HashSet<string>());
                    }
                }
                else
                {
                    string[] line = input.Split(" followed ").ToArray();
                    string followerName = line[0];
                    string vloggerName = line[1];
                    if (vloggerName != followerName && vloggers.ContainsKey(vloggerName) && vloggers.ContainsKey(followerName))
                    {
                        vloggers[vloggerName]["followers"].Add(followerName);
                        vloggers[followerName]["following"].Add(vloggerName);
                    }
                }

                input = Console.ReadLine();
            }
            int count = 1;

            Console.WriteLine($"The V-Logger has a total of {vloggers.Count} vloggers in its logs.");

            foreach (var vlogger in vloggers.OrderByDescending(v => v.Value["followers"].Count).ThenBy(v => v.Value["following"].Count))
            {
                Console.WriteLine($"{count}. {vlogger.Key} : {vlogger.Value["followers"].Count} followers, {vlogger.Value["following"].Count} following");

                if (count == 1)
                {
                    foreach (string follower in vlogger.Value["followers"].OrderBy(f => f))
                    {
                        Console.WriteLine($"*  {follower}");
                    }
                }
                count++;
            }
        }
    }
}
