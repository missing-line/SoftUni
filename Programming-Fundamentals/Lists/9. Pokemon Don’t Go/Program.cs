namespace _9._Pokemon_Don_t_Go
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    public class Program
    {
        public static void Main(string[] args)
        {
            List<int> line = Console.ReadLine().Split().Select(int.Parse).ToList();
            List<int> removedElements = new List<int>();
            while (line.Count != 0)
            {
                int index = int.Parse(Console.ReadLine());
                int currRemovedElement = 0;
                if (index < 0)
                {
                    currRemovedElement = line[0];
                    removedElements.Add(line[0]);
                    line[0] = line[line.Count - 1];
                }
                else if (index > line.Count - 1)
                {
                    currRemovedElement = line[line.Count - 1];
                    removedElements.Add(line[line.Count - 1]);
                    line[line.Count - 1] = line[0];
                }
                else if (index >= 0 && index < line.Count)
                {
                    currRemovedElement = line[index];
                    removedElements.Add(currRemovedElement);
                    line.RemoveAt(index);
                }

                for (int i = 0; i < line.Count; i++)
                {
                    if (currRemovedElement >= line[i])
                    {
                        line[i] += currRemovedElement;
                    }
                    else
                    {
                        line[i] -= currRemovedElement;
                    }
                }
            }
            Console.WriteLine(removedElements.Sum());
        }
    }
}
