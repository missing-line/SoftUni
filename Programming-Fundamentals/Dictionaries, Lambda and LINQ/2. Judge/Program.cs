namespace _2._Judge
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    public class Program
    {
        public static void Main(string[] args)
        {
            string[] line = Console.ReadLine()
                .Split("->".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            Dictionary<string, Dictionary<string, int>> context = new Dictionary<string, Dictionary<string, int>>();
            Dictionary<string, int> users = new Dictionary<string, int>();

            while (string.Join(" ", line) != "no more time")
            {
                string currContext = line[1].Trim();
                string userName = line[0].Trim();
                int point = int.Parse(line[2].Trim());

                if (!context.ContainsKey(currContext))
                {
                    context.Add(currContext, new Dictionary<string, int>());
                    context[currContext].Add(userName, point);
                }
                else if (context.ContainsKey(currContext) && !context[currContext].ContainsKey(userName))
                {
                    context[currContext].Add(userName, point);
                }
                else if (context.ContainsKey(currContext))
                {
                    if (context[currContext].ContainsKey(userName) && context[currContext][userName] < point)
                    {
                        context[currContext][userName] = point;
                    }
                }

                line = Console.ReadLine().Split("->".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).ToArray();
            }

            int count = 1;

            foreach (var item in context)
            {
                Console.WriteLine($"{item.Key}: {item.Value.Count} participants");
                count = 1;
                foreach (var inner in item.Value.OrderByDescending(x => x.Value).ThenBy(l => l.Key))
                {
                    Console.WriteLine($"{count}. {inner.Key} <::> {inner.Value}");
                    count++;
                    if (!users.ContainsKey(inner.Key))
                    {
                        users.Add(inner.Key, inner.Value);
                    }
                    else
                    {
                        users[inner.Key] += inner.Value;
                    }
                }
            }

            Console.WriteLine("Individual standings:");

            count = 1;
            foreach (var user in users.OrderByDescending(x => x.Value).ThenBy(l => l.Key))
            {
                Console.WriteLine($"{count}. {user.Key} -> {user.Value}");
                count++;
            }
        }
    }
}
