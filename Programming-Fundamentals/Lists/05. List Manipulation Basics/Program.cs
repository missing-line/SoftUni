
namespace _05._List_Manipulation_Basics
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    public class Program
    {
        public static void Main(string[] args)
        {
            List<int> nums = Console.ReadLine().Split().Select(int.Parse).ToList();
            string[] command = Console.ReadLine().Split();
            while (command[0] != "end")
            {
                if (command[0] == "Add")
                {
                    int curr = int.Parse(command[1]);
                    nums.Add(curr);
                }
                else if (command[0] == "Remove")
                {
                    int curr = int.Parse(command[1]);
                    if (nums.Contains(curr))
                    {
                        nums.Remove(curr);
                    }
                }
                else if (command[0] == "RemoveAt")
                {
                    int index = int.Parse(command[1]);
                    if (index >= 0 && index < nums.Count)
                    {
                        nums.RemoveAt(index);
                    }
                }
                else if (command[0] == "Insert")
                {
                    int curr = int.Parse(command[1]);
                    int index = int.Parse(command[2]);
                    nums.Insert(index, curr);
                }
                command = Console.ReadLine().Split();
            }
            Console.WriteLine(string.Join(" ", nums));
        }
    }
}
