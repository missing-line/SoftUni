using System;
using System.Collections.Generic;
using System.Linq;

namespace Pokemon_Don_t_Go
{
    class Program
    {
        static void Main(string[] args)
        {
            List<long> line = Console.ReadLine()
                .Split()
                .Select(long.Parse)
                .ToList();

            long sum = 0;

            while (line.Count > 0)
            {
                int n = int.Parse(Console.ReadLine());
                long currValue = 0;
                if (n < 0)
                {
                    currValue = line[0];
                    line[0] = line[line.Count - 1];
                }
                else if (n >= line.Count)
                {
                    currValue = line[line.Count - 1];
                    line[line.Count - 1] = line[0];
                }
                else
                {

                    currValue = line[n];
                    line.RemoveAt(n);
                }
                sum += currValue;
                for (int i = 0; i < line.Count; i++)
                {
                    if (line[i] <= currValue)
                    {
                        line[i] += currValue;
                    }
                    else
                    {
                        line[i] -= currValue;
                    }
                }
            }
            Console.WriteLine(sum);
        }
    }
}
