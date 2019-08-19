using System;
using System.Collections.Generic;
using System.Linq;

namespace Grains_of_Sand2
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> nums = Console.ReadLine().Split().Select(int.Parse).ToList();
            string[] command = Console.ReadLine().Split();
            while (string.Join("", command) != "Mort")
            {
                if (command[0] == "Add")
                {
                    nums.Add(int.Parse(command[1]));
                }
                else if (command[0] == "Remove")
                {
                    int index = int.Parse(command[1]);
                    if (nums.Any(x=>x == index))
                    {
                        nums.Remove(index);
                    }
                    else if (index >= 0 && index < nums.Count) // ?
                    {
                        nums.RemoveAt(index);
                    }
                }
                else if (command[0] == "Replace")
                {
                    int findIndex = int.Parse(command[1]);
                    int replaceIndex = int.Parse(command[2]);
                    int index = nums.IndexOf(findIndex);
                    if (index != -1)
                    {
                        nums[index] = replaceIndex;
                    }
                }
                else if (command[0] == "Increase")
                {
                    int value = int.Parse(command[1]);
                    if (nums.Any(x=>x >= value))
                    {
                        int ext = nums.First(x=>x >= value);
                        for (int i = 0; i < nums.Count; i++)
                        {
                            nums[i] += ext;
                        }
                    }
                    else
                    {
                        int lastElement = nums[nums.Count - 1];
                        for (int i = 0; i < nums.Count; i++)
                        {
                            nums[i] += lastElement;
                        }
                    }
                }
                else if (command[0] == "Collapse")
                {
                    int collapse = int.Parse(command[1]);
                    for (int i = 0; i < nums.Count; i++)
                    {
                        if (nums[i] < collapse)
                        {
                            nums.Remove(nums[i]);
                            i--;
                        }
                    }
                }
                command = Console.ReadLine().Split();
            }
            Console.WriteLine(string.Join(" ",nums));
        }
    }
}
