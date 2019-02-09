namespace _2._Change_List
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    public class Program
    {
        public static void Main(string[] args)
        {
            List<int> nums = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();
            string[] command = Console.ReadLine().Split();

            while (command[0] != "end")
            {
                if (command[0] == "Insert")
                {
                    int element = int.Parse(command[1]);
                    int index = int.Parse(command[2]);
                    if (index >= 0 && index <= nums.Count)
                    {
                        nums.Insert(index, element);
                    }
                }
                else if (command[0] == "Delete")
                {
                    int element = int.Parse(command[1]);
                    nums.RemoveAll(x => x == element);
                }
                command = Console.ReadLine().Split();
            }
            Console.WriteLine(string.Join(" ", nums));
        }
    }
}
