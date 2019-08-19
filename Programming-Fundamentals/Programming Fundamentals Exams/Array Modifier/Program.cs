using System;
using System.Linq;

namespace Array_Modifier
{
    class Program
    {
        static void Main(string[] args)
        {
            long[] nums = Console.ReadLine().Split().Select(long.Parse).ToArray();

            string[] command = Console.ReadLine().Split().ToArray();

            while (command[0] != "end")
            {
                if (command[0] == "swap")
                {
                    long index1 = nums[long.Parse(command[1])];
                    long index2 = nums[long.Parse(command[2])];
                    nums[long.Parse(command[1])] = index2;
                    nums[long.Parse(command[2])] = index1;
                }
                else if (command[0] == "multiply")
                {
                    long first = nums[long.Parse(command[1])];
                    long second = nums[long.Parse(command[2])];

                    first *= second;
                    nums[long.Parse(command[1])] = first;

                }
                else if (command[0] == "decrease")
                {
                    for (int i = 0; i < nums.Length; i++)
                    {
                        nums[i]--;
                    }
                }
                command = Console.ReadLine().Split().ToArray();
            }
            Console.WriteLine(string.Join(", ", nums));
        }
    }
}
