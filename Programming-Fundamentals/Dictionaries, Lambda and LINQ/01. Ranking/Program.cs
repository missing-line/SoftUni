namespace _01._Ranking
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    public class Program
    {
        public static void Main(string[] args)
        {
            Dictionary<string, string> input = new Dictionary<string, string>();
            Dictionary<string, Dictionary<string, int>> users = new Dictionary<string, Dictionary<string, int>>();

            string[] line = Console.ReadLine()
                .Split(":".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            while (string.Join(" ", line) != "end of contests")
            {
                string contest = line[0];
                string password = line[1];
                if (!input.ContainsKey(contest))
                {
                    input.Add(contest, password);
                }
                line = Console.ReadLine()
                .Split(":".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            }

            string[] tokens = Console.ReadLine()
                .Split(":=>".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            while (string.Join(" ", tokens) != "end of submissions")
            {
                string course = tokens[0];
                string password = tokens[1];
                if (input.ContainsKey(course) && input[course] == password)
                {
                    string name = tokens[2];
                    int points = int.Parse(tokens[3]);
                    if (!users.ContainsKey(name))
                    {
                        users.Add(name, new Dictionary<string, int>());
                        users[name].Add(course, points);
                    }
                    else if (users.ContainsKey(name) && users[name].ContainsKey(course))
                    {
                        if (users[name][course] < points)
                        {
                            users[name][course] = points;
                        }
                    }
                    else if (users.ContainsKey(name) && !users[name].ContainsKey(course))
                    {
                        users[name].Add(course, points);
                    }
                }

                tokens = Console.ReadLine()
                .Split(":=>".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            }

            Dictionary<string, long> best = new Dictionary<string, long>();

            foreach (var bestSt in users)
            {
                if (!best.ContainsKey(bestSt.Key))
                {
                    best.Add(bestSt.Key, bestSt.Value.Values.Sum());
                }
            }

            foreach (var bestSt in best.OrderByDescending(c => c.Value))
            {
                Console.WriteLine($"Best candidate is {bestSt.Key} with total {bestSt.Value} points.");
                break;
            }

            Console.WriteLine("Ranking: ");
            foreach (var user in users.OrderBy(l => l.Key))
            {
                Console.WriteLine(user.Key);
                foreach (var inner in user.Value.OrderByDescending(x => x.Value))
                {
                    Console.WriteLine($"#  {inner.Key} -> {inner.Value}");
                }
            }
        }
    }
}
