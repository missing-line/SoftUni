namespace Tagram
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, int>> tagram = new Dictionary<string, Dictionary<string, int>>();

            string input;

            while ((input = Console.ReadLine()) != "end")
            {
                string[] array = input
                    .Split(" ->".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                if (array[0] == "ban")
                {
                    string username = array[1];
                    tagram.Remove(username);
                }
                else
                {
                    string user = array[0];
                    string tag = array[1];
                    int likes = int.Parse(array[2]);
                    if (!tagram.ContainsKey(user))
                    {
                        tagram.Add(user, new Dictionary<string, int>());
                        tagram[user].Add(tag, likes);
                    }
                    else if (tagram.ContainsKey(user) && tagram[user].ContainsKey(tag))
                    {
                        tagram[user][tag] += likes;
                    }
                    else if (tagram.ContainsKey(user) && !tagram[user].ContainsKey(tag))
                    {
                        tagram[user].Add(tag, likes);
                    }
                }
            }

            foreach (var username in tagram.OrderByDescending(x => x.Value.Select(y => y.Value).Sum()).ThenBy(t => t.Value.Count()))
            {
                Console.WriteLine($"{username.Key}");
                foreach (var inner in username.Value)
                {
                    Console.WriteLine($"- {inner.Key}: {inner.Value}");
                }
            }
        }
    }
}
