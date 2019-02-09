namespace _4._List_Operations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    public class Program
    {
        public static void Main(string[] args)
        {
            List<int> nums = Console.ReadLine().
                Split()
                .Select(int.Parse)
                .ToList();
            string[] command = Console.ReadLine().Split();

            while (command[0] != "End")
            {
                if (command[0] == "Add")
                {
                    nums.Add(int.Parse(command[1]));
                }
                else if (command[0] == "Insert")
                {
                    int element = int.Parse(command[1]);
                    int index = int.Parse(command[2]);
                    if (index >= 0 && index <= nums.Count)
                    {
                        nums.Insert(index, element);
                    }
                    else
                    {
                        Console.WriteLine("Invalid index");
                    }
                }
                else if (command[0] == "Remove")
                {
                    int index = int.Parse(command[1]);
                    if (index >= 0 && index <= nums.Count)
                    {
                        nums.RemoveAt(index);
                    }
                    else
                    {
                        Console.WriteLine("Invalid index");
                    }
                }
                else if (command[0] == "Shift")
                {
                    int count = int.Parse(command[command.Length - 1]);
                    if (command.Contains("left"))
                    {
                        RotattingLeft(nums, count);
                    }
                    else
                    {
                        RotattingRight(nums, count);
                    }
                }
                command = Console.ReadLine().Split();
            }
            Console.WriteLine(string.Join(" ", nums));
        }
        public static List<int> RotattingLeft(List<int> nums, int count)
        {
            int jump = count % nums.Count;
            for (int i = 0; i < jump; i++)
            {
                int firstElement = nums[0];
                for (int j = 0; j < nums.Count - 1; j++) // 1 2 3 4 5 // 
                {
                    nums[j] = nums[j + 1];
                }
                nums[nums.Count - 1] = firstElement;
            }
            return nums;
        }
        public static List<int> RotattingRight(List<int> nums, int count)
        {
            int jump = count % nums.Count;
            for (int i = 0; i < jump; i++)
            {
                int lastElement = nums[nums.Count - 1];
                for (int j = nums.Count - 1; j > 0; j--) // 1 2 3 4 5 // 5 4 3 2 1
                {
                    nums[j] = nums[j - 1];
                }
                nums[0] = lastElement;
            }
            return nums;
        }
    }
}
