using System;
using System.Collections.Generic;
using System.Linq;

namespace Hornet_Armada
{
    class Program
    { // 80/100
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<string> lines = new List<string>();
            for (int i = 0; i < n; i++)
            {
                string line = Console.ReadLine();
                lines.Add(line);
            }
            string command = Console.ReadLine();
            if (command.Contains('\\'))
            {
                Dictionary<string, long> print = new Dictionary<string, long>();
                List<string> currComm = command.Split("\\".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                    .ToList();
                long maxActivity = long.Parse(currComm[0]);
                string type = currComm[1];
                for (int i = 0; i < lines.Count; i++)
                {
                    List<string> curr = lines[i].Split(" ->:=".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).ToList();
                    if (long.Parse(curr[0]) < maxActivity && type == curr[2])
                    {
                        string legionName = curr[1];
                        long soldiersCount = long.Parse(curr[3]);
                        if (!print.ContainsKey(legionName))
                        {
                            print.Add(legionName, soldiersCount);
                        }
                        else
                        {
                            print[legionName] += soldiersCount;
                        }
                    }
                }
                foreach (var result in print.OrderByDescending(x => x.Value))
                {
                    Console.WriteLine($"{result.Key} -> {result.Value}");
                }
            }
            else
            {
                Dictionary<string, long> print = new Dictionary<string, long>();
                List<string> findType = new List<string>();
                for (int i = 0; i < lines.Count; i++)
                {
                    string[] curr = lines[i].Split(" ->:=".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).ToArray();
                    if (curr[2] == command)
                    {

                        if (!findType.Contains(curr[1]))
                        {
                            findType.Add(curr[1]);
                        }
                    }
                }
                for (int i = 0; i < findType.Count; i++)
                {
                    foreach (var legion in lines)
                    {
                        if (legion.Contains(findType[i]))
                        {
                            string[] curr = legion.Split(" ->:=".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).ToArray();
                            string legionName = curr[1];
                            long activity = long.Parse(curr[0]);
                            if (!print.ContainsKey(legionName))
                            {
                                print.Add(legionName, activity);
                            }
                            else if (print.ContainsKey(legionName))
                            {
                                if (print[legionName] < activity)
                                {
                                    print[legionName] = activity;
                                }
                            }
                        }

                    }
                }
                foreach (var result in print.OrderByDescending(x => x.Value))
                {
                    Console.WriteLine($"{result.Value} : {result.Key}");
                }
            }
        }
    }
}
