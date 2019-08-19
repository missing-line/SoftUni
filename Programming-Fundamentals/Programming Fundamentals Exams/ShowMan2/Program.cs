using System;
using System.Collections.Generic;
using System.Linq;

namespace ShowMan2
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> line = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            List<int> losers = new List<int>();

            while (line.Count != 1)
            {
                for (int i = 0; i < line.Count; i++)
                {
                    if (losers.Contains(i))
                    {
                        continue;
                    }
                    int attacker = i;
                    int target = line[i] % line.Count;
                    int diff = Math.Abs(attacker - target);
                    if (attacker == target)
                    {
                        if (!losers.Contains(i))
                        {
                            losers.Add(i);
                        }                      
                        Console.WriteLine($"{i} performed harakiri");                      
                    }
                    else if (diff % 2 == 0)
                    {
                        if (!losers.Contains(target))
                        {
                            losers.Add(target);
                        }
                        Console.WriteLine($"{attacker} x {target} -> {attacker} wins");
                    }
                    else if (diff % 2 != 0)
                    {
                        if (!losers.Contains(attacker))
                        {
                            losers.Add(attacker);
                        }                     
                        Console.WriteLine($"{attacker} x {target} -> {target} wins");
                    }
                    if (line.Count == losers.Count + 1)
                    {
                        break;
                    }
                }
                RemoverLosersAndSuicide(line, losers);
                losers.Clear();
            }
        }
        public static List<int> RemoverLosersAndSuicide(List<int> line, List<int> losers)
        {
            
            losers.Sort((a, b) => (b.CompareTo(a)));
            foreach (var index in losers)
            {
                line.RemoveAt(index);
            }
            return line;
        }
    }
}
