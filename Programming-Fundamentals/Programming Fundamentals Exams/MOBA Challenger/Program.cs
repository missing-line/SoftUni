using System;
using System.Collections.Generic;
using System.Linq;

namespace MOBA_Challenger
{
    class Program
    {
        static void Main(string[] args)
        {
            string line = Console.ReadLine();
            Dictionary<string, Dictionary<string, int>> player = new Dictionary<string, Dictionary<string, int>>();
            Dictionary<string, int> namePlayer = new Dictionary<string, int>();
            while (line != "Season end")
            {
                string[] tokens = line.Split("-> ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                if (tokens[1] != "vs")
                {
                    string name = tokens[0].Trim();
                    string position = tokens[1].Trim();
                    int skill = int.Parse(tokens[2]);
                    if (!player.ContainsKey(name))
                    {
                        player.Add(name, new Dictionary<string, int>());
                        player[name].Add(position, skill);
                    }
                    else if (player.ContainsKey(name))
                    {
                        if (!player[name].ContainsKey(position))
                        {
                            player[name].Add(position, skill);
                        }
                        else if (player[name].ContainsKey(position))
                        {
                            if (player[name][position] < skill)
                            {
                                player[name][position] = skill;
                            }
                        }
                    }
                }
                else
                {
                    string name1 = tokens[0];
                    string name2 = tokens[2];
                    bool isDemoned = false;
                    if (player.ContainsKey(name1) && player.ContainsKey(name2))
                    {
                        foreach (var player1 in player[name1])
                        {
                            foreach (var player2 in player[name2])
                            {

                                if (player1.Key == player2.Key)
                                {
                                    int cur1 = player[name1].Values.Sum();
                                    int cur2 = player[name2].Values.Sum();
                                    if (cur1 > cur2)
                                    {
                                        player.Remove(name2);
                                        isDemoned = true;
                                        break;
                                    }
                                    else if (cur1 < cur2)
                                    {
                                        player.Remove(name1);
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

            foreach (var kvp in player)
            {
                foreach (var Inner in kvp.Value)
                {
                    if (!namePlayer.ContainsKey(kvp.Key))
                    {
                        namePlayer.Add(kvp.Key, Inner.Value);
                    }
                    else if (namePlayer.ContainsKey(kvp.Key))
                    {
                        namePlayer[kvp.Key] += Inner.Value;
                    }
                }
            }
            foreach (var kvp in namePlayer.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                foreach (var kvp2 in player)
                {
                    if (kvp.Key == kvp2.Key)
                    {
                        Console.WriteLine($"{kvp.Key}: {kvp.Value} skill");
                        foreach (var inner in kvp2.Value.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
                        {
                            Console.WriteLine($"- {inner.Key} <::> {inner.Value}");
                        }
                    }
                }
            }

        }
    }
}
// Console.WriteLine($"{type.Key}::({(type.Value.Select(x => x.Value[0]).Average()):F2}/{(type.Value.Select(x => x.Value[1]).Average()):F2}/{(type.Value.Select(x => x.Value[2]).Average()):F2})");