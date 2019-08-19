using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grains_of_Sand
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> nums = Console.ReadLine().Split().Select(int.Parse).ToList();
            string[] command = Console.ReadLine().Split().ToArray();
            while (command[0] != "Mort")
            {
                if (command[0] == "Add")
                {
                    nums.Add(int.Parse(command[1]));
                }
                else if (command[0] == "Replace")
                {
                    int index = int.Parse(command[1]);
                    int replace = int.Parse(command[2]);
                    nums = Replace(nums, index, replace);
                }
                else if (command[0] == "Remove")
                {
                    if (nums.Contains(int.Parse(command[1])))
                    {
                        nums.Remove(int.Parse(command[1]));
                    }
                    else if (int.Parse(command[1]) <= nums.Count && int.Parse(command[1]) >= 0)
                    {
                        nums.RemoveAt(int.Parse(command[1]));
                    }

                }
                else if (command[0] == "Increase")
                {
                    int value = int.Parse(command[1]);                   
                    if (IncreasFind(nums,value) == true)
                    {
                        int item = nums.Find(x => x >= value);
                        nums = Increase(nums, item);
                    }
                    else
                    {
                        nums = Increase(nums,nums[nums.Count - 1]);
                    }
                }
                else if (command[0] == "Collapse")
                {
                    nums.RemoveAll(x => x < int.Parse(command[1]));
                }
                command = Console.ReadLine().Split().ToArray();
            }
            Console.WriteLine(string.Join(" ", nums));
        }
        static List<int> Increase(List<int> nums, int n)
        {
            for (int i = 0; i < nums.Count; i++)
            {
                nums[i] += n;
            }
            return nums;
        }
        static List<int> Replace(List<int> nums, int index, int replace)
        {
            for (int i = 0; i < nums.Count; i++)
            {
                if (nums[i] == index)
                {
                    nums[i] = replace;
                    break;
                }
            }
            return nums;
        }
        static bool IncreasFind(List<int> nums, int value)
        {
            bool isOk = false;
            for (int i = 0; i < nums.Count; i++)
            {
                if (nums[i] > value)
                {
                    isOk = true;
                    break;
                }
            }
            return isOk;
        }
    }
}
