namespace _03._MOBA_Challenger
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    public class Program
    {
        public static void Main(string[] args)
        {
            string line = Console.ReadLine();
            Dictionary<string, Dictionary<string, long>> users = new Dictionary<string, Dictionary<string, long>>();

            while (line != "Season end")
            {
                if (line.Contains("->"))
                {
                    string[] currLine = line
                        .Split("->".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).ToArray();

                    string name = currLine[0].Trim();
                    string position = currLine[1].Trim();
                    long skill = long.Parse(currLine[2].Trim());

                    if (!users.ContainsKey(name))
                    {
                        users.Add(name, new Dictionary<string, long>());
                        users[name].Add(position, skill);
                    }
                    else if (users.ContainsKey(name))
                    {
                        if (users[name].ContainsKey(position) && users[name][position] < skill)
                        {
                            users[name][position] = skill;
                        }
                        else if (!users[name].ContainsKey(position))
                        {
                            users[name].Add(position, skill);
                        }
                    }
                }
                else
                {
                    string[] currLine = line
                        .Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).ToArray();

                    string firstPlayer = currLine[0].Trim();
                    string secondPlayer = currLine[2].Trim();
                    bool isDemoned = false;

                    if (users.Any(x => x.Key == firstPlayer) && users.Any(y => y.Key == secondPlayer))
                    {
                        foreach (var first in users[firstPlayer])
                        {
                            foreach (var second in users[secondPlayer])
                            {
                                if (first.Key == second.Key)
                                {
                                    if (first.Value > second.Value)
                                    {
                                        users.Remove(secondPlayer);
                                        isDemoned = true;
                                        break;
                                    }
                                    else if (first.Value < second.Value)
                                    {
                                        users.Remove(firstPlayer);
                                        isDemoned = true;
                                        break;
                                    }
                                }
                            }
                            if (isDemoned)
                            {
                                break;
                            }
                        }
                    }
                }
                line = Console.ReadLine();
            }
            foreach (var user in users.OrderByDescending(x => x.Value.Values.Sum()).ThenBy(y => y.Key))
            {
                Console.WriteLine($"{user.Key}: {user.Value.Values.Sum()} skill");
                foreach (var inner in user.Value.OrderByDescending(c => c.Value).ThenBy(l => l.Key))
                {
                    Console.WriteLine($"- {inner.Key} <::> {inner.Value}");
                }
            }
        }
    }
}
