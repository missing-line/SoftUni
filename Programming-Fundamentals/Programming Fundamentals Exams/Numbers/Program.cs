using System;
using System.Collections.Generic;
using System.Linq;

namespace Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] line = Console.ReadLine().Split().Select(int.Parse).ToArray();
            double average = 0;
            List<int> take = new List<int>();
            List<int> print = new List<int>();
            for (int i = 0; i < line.Length; i++)
            {
                average += line[i];
            }
            average /= line.Length;

            for (int i = 0; i < line.Length; i++)
            {
                if (line[i] > average)
                {
                    take.Add(line[i]);
                }
            }
            take.Sort((emp1, emp2) => emp2.CompareTo(emp1));
            for (int i = 1; i <= 5; i++)
            {
                if (i <= take.Count)
                {
                    print.Add(take[i - 1]);
                }
            }
            if (print.Count == 0)
            {
                Console.WriteLine("No");
                return;
            }
            foreach (var item in print.OrderByDescending(x => x))
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
        }
    }
}
