namespace _6._List_Manipulation_Advanced
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
            bool task = false;
            while (command[0] != "end")
            {
                if (command[0] == "Add")
                {
                    int curr = int.Parse(command[1]);
                    nums.Add(curr);
                    task = true;
                }
                else if (command[0] == "Remove")
                {
                    int curr = int.Parse(command[1]);
                    if (nums.Contains(curr))
                    {
                        nums.Remove(curr);
                        task = true;
                    }
                }
                else if (command[0] == "RemoveAt")
                {
                    int index = int.Parse(command[1]);
                    if (index >= 0 && index < nums.Count)
                    {
                        nums.RemoveAt(index);
                        task = true;
                    }
                }
                else if (command[0] == "Insert")
                {
                    int curr = int.Parse(command[1]);
                    int index = int.Parse(command[2]);
                    nums.Insert(index, curr);
                    task = true;
                }
                else if (command[0] == "Contains")
                {
                    int curr = int.Parse(command[1]);
                    if (nums.Contains(curr))
                        Console.WriteLine("Yes");
                    else
                        Console.WriteLine("No such number");
                }
                else if (command[0] == "PrintEven")
                {
                    Console.WriteLine(string.Join(" ", nums.Where(x => x % 2 == 0)));
                }
                else if (command[0] == "PrintOdd")
                {
                    Console.WriteLine(string.Join(" ", nums.Where(x => x % 2 != 0)));
                }
                else if (command[0] == "GetSum")
                {
                    Console.WriteLine(nums.Sum());
                }
                else if (command[0] == "Filter")
                {
                    int curr = int.Parse(command[command.Length - 1]);
                    if (command.Contains(">="))
                    {
                        Console.WriteLine(string.Join(" ", nums.Where(x => x >= curr)));
                    }
                    else if (command.Contains(">"))
                    {
                        Console.WriteLine(string.Join(" ", nums.Where(x => x > curr)));
                    }
                    else if (command.Contains("<="))
                    {
                        Console.WriteLine(string.Join(" ", nums.Where(x => x <= curr)));
                    }
                    else
                    {
                        Console.WriteLine(string.Join(" ", nums.Where(x => x < curr)));
                    }
                }
                command = Console.ReadLine().Split();
            }
            if (task)
            {
                Console.WriteLine(string.Join(" ", nums));
            }
        }
    }
}
