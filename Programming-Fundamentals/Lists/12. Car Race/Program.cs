namespace _12._Car_Race
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    public class Program
    {
        public static void Main(string[] args)
        {
            List<double> line = Console.ReadLine()
                .Split()
                .Select(double.Parse)
                .ToList();
            double left = 0;
            double right = 0;
            for (int i = 0; i <= line.Count / 2 - 1; i++)
            {
                if (line[i] != 0 && line[i] > 0)
                {
                    left += line[i];
                }
                else if (line[i] == 0)
                {
                    left *= 0.8;
                }
            }
            for (int i = line.Count - 1; i >= (line.Count / 2) + 1; i--)
            {
                if (line[i] != 0 && line[i] > 0)
                {
                    right += line[i];
                }
                else if (line[i] == 0)
                {
                    right *= 0.8;
                }
            }
            if (left >= right)
            {
                Console.WriteLine($"The winner is right with total time: {right}");
            }
            else if (left < right)
            {
                Console.WriteLine($"The winner is left with total time: {left}");
            }
        }
    }
}
