using System;
using System.Collections.Generic;
using System.Linq;

namespace Showman
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> line = Console.ReadLine().Split().Select(int.Parse).ToList();
            List<int> remove = new List<int>();
          

            while (line.Count != 1)
            {
                for (int i = 0; i < line.Count; i++)
                {
                    int attacker = i;
                    if (remove.Contains(attacker))
                    {
                        continue;
                    }
                    int target = line[i] % line.Count;// 
                                     
                    int diff = Math.Abs(attacker - target);
                    if (attacker == target)
                    {
                        if (!remove.Contains(attacker))
                        {
                            remove.Add(attacker);
                        }
                        Console.WriteLine($"{target} performed harakiri");
                        
                    }
                    else 
                    {
                        int win = 0;
                        int lose = -1;
                        if (diff  % 2 == 0)
                        {
                            
                            win = attacker;
                            lose = target;                          
                        }
                        else
                        {                           
                            win = target;
                            lose = attacker;                           
                        }
                        Console.WriteLine($"{attacker} x {target} -> {win} wins");
                        if (!remove.Contains(lose))
                        {
                            remove.Add(lose);
                        }
                    }
                    if (line.Count == remove.Count + 1)
                    {
                        break;
                    }
                }
                line = Clean(line, remove.OrderByDescending(x=>x).ToList());
                remove.Clear();
            }

        }
        static List<int> Clean(List<int> line, List<int> remove)
        {

            foreach (var index in remove)
            {
                line.RemoveAt(index);
            }
            return line;
        }
    }
}
