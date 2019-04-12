using System;
using System.Collections.Generic;
using System.Linq;

namespace _7._String_Explosion
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> line = Console.ReadLine().Split(">".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).ToList();
            int lastRemove = 0;
            for (int i = 1; i < line.Count; i++)
            {
                string curr = line[i];
                
                if (char.IsDigit(line[i][0]))
                {                 
                    int remove = int.Parse(line[i][0].ToString());
                    remove += lastRemove;
                    if (curr.Length == remove)
                    {
                        line[i] = ">";                       
                    }
                    else if(curr.Length < remove){
                        line[i] = ">";
                        remove -= curr.Length;
                        lastRemove = remove;
                    }
                    else
                    {
                        line[i] = line[i].Remove(0, remove);
                        lastRemove = 0;
                        if (line[i].Length == 0)
                        {
                            line[i] = ">";
                        }
                        else
                        {
                            line[i] = line[i].Insert(0, ">");
                        }
                    }
                }
            }
            Console.WriteLine(string.Join("", line));
        }
    }
}
