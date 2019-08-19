using System;
using System.Collections.Generic;
using System.Linq;

namespace Tseam_Account
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> line = Console.ReadLine().Split(' ',StringSplitOptions.RemoveEmptyEntries).ToList();
            string[] command = Console.ReadLine().Split(' ',StringSplitOptions.RemoveEmptyEntries);
            string expansion = "";
            while (command[0] != "Play!")
            {
                if (command[0] == "Install")
                {
                    if (!line.Contains(command[1]))
                    {
                        line.Add(command[1]);
                    }
                    
                }
                else if (command[0] == "Uninstall")
                {
                    if (line.Contains(command[1]))
                    {
                        line.Remove(command[1]);
                    }                   
                }
                else if (command[0] == "Update")
                {
                    if (line.Contains(command[1]))
                    {
                        line.Remove(command[1]);
                        line.Add(command[1]);
                    }
                   
                }
                else if (command[0] == "Expansion")
                {
                    string[] curr = command[1].Split('-',StringSplitOptions.RemoveEmptyEntries).ToArray();
                    if (line.Contains(curr[0]))
                    {
                        int position = line.IndexOf(curr[0]);
                        expansion += curr[0] + ":" + curr[1].ToString();
                        line.Insert(position + 1, expansion);
                        expansion = string.Empty;
                    }
                }
                command = Console.ReadLine().Split();
            }
            Console.WriteLine(string.Join(" ",line));
            
        }
    }
}
