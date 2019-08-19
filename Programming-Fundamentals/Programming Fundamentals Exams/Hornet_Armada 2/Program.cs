using System;
using System.Collections.Generic;
using System.Linq;

namespace Hornet_Armada_2
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, long> activities = new Dictionary<string, long>();
            Dictionary<string, Dictionary<string, long>> soldiersCount = new Dictionary<string, Dictionary<string, long>>();
            for (int i = 0; i < n; i++)
            {
                string[] tokens = Console.ReadLine()
                    .Split("= ->:".ToCharArray(),StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                long activity = long.Parse(tokens[0]);
                string name = tokens[1];
                string type = tokens[2];
                long countSoldiers = long.Parse(tokens[3]);
                if (activities.ContainsKey(name) && activities[name] < activity)
                {
                    activities[name] = activity;
                }
                else if(!activities.ContainsKey(name))
                {
                    activities.Add(name,activity);
                }
                if (soldiersCount.ContainsKey(name) && soldiersCount[name].ContainsKey(type))
                {
                    soldiersCount[name][type] += countSoldiers;
                }
                else if (soldiersCount.ContainsKey(name) && !soldiersCount[name].ContainsKey(type))
                {
                    soldiersCount[name].Add(type,countSoldiers);
                }
                else
                {
                    soldiersCount.Add(name,new Dictionary<string, long>());
                    soldiersCount[name].Add(type, countSoldiers);
                }
            }
            string commandSepareted = Console.ReadLine();
            Dictionary<string, long> rs = new Dictionary<string, long>();
            if (commandSepareted.Contains("\\"))
            {
                string[] command = commandSepareted.Split("\\".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).ToArray();
                int findActivity = int.Parse(command[0]);
                string findType = command[1];
               
                foreach (var currActivity in activities)
                {
                    foreach (var currType in soldiersCount)
                    {
                        if (currActivity.Key == currType.Key && currActivity.Value < findActivity)
                        {
                            foreach (var inner in currType.Value.OrderByDescending(x => x.Value))
                            {
                                if (inner.Key == findType)
                                {                                   
                                    rs.Add(currActivity.Key, inner.Value);
                                }

                            }
                        }
                    }
                }
                foreach (var item in rs.OrderByDescending(x => x.Value))
                {
                    Console.WriteLine($"{item.Key} -> {item.Value}");
                }
            }
            else
            {
                string findType = commandSepareted;
                foreach (var currActivity in activities)
                {
                    foreach (var currType in soldiersCount)
                    {
                        if (currActivity.Key == currType.Key)
                        {
                            foreach (var inner in currType.Value.OrderByDescending(x => x.Value))
                            {
                                if (inner.Key == findType)
                                {                                   
                                    rs.Add(currActivity.Key, currActivity.Value);
                                }

                            }
                        }
                    }
                }
                foreach (var item in rs.OrderByDescending(x=>x.Value))
                {
                    Console.WriteLine($"{item.Value} : {item.Key}");
                }
            }
        }
    }
}
