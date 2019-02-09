namespace _1._Train
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    public class Program
    {
        public static void Main(string[] args)
        {
            List<int> wagons = Console.ReadLine()
                 .Split()
                 .Select(int.Parse)
                 .ToList();
            int capacity = int.Parse(Console.ReadLine());

            string[] command = Console.ReadLine().Split();

            while (command[0] != "end")
            {
                if (command[0] == "Add")
                {
                    int currWagon = int.Parse(command[1]);
                    wagons.Add(currWagon);
                }
                else
                {
                    int passangers = int.Parse(command[0]);
                    wagons = FindSpace(wagons, passangers, capacity);
                }
                command = Console.ReadLine().Split();
            }
            Console.WriteLine(string.Join(" ", wagons));
        }
        public static List<int> FindSpace(List<int> wagons, int passangers, int capacity)
        {
            for (int i = 0; i < wagons.Count; i++)
            {
                if (wagons[i] + passangers <= capacity)
                {
                    wagons[i] += passangers;
                    break;
                }
            }
            return wagons;
        }
    }
}
