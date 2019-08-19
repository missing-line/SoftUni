using System;
using System.Collections.Generic;
using System.Linq;

namespace Trophon_the_Grumpy_Cat
{
    class Program
    {
        static void Main(string[] args)
        {
            List<long> nums = Console.ReadLine()
                .Split()
                .Select(long.Parse)
                .ToList();
            int n = int.Parse(Console.ReadLine());
            string command1 = Console.ReadLine();
            string command2 = Console.ReadLine();
            long sumRight = 0;
            long sumLeft = 0;
            for (int i = n + 1; i < nums.Count; i++)
            {
                if (command1 == "cheap")
                {
                    if (command2 == "positive")
                    {
                        if (nums[i] > 0 && nums[i] < nums[n])
                        {
                            sumRight += nums[i];
                        }
                    }
                    else if (command2 == "negative")
                    {
                        if (nums[i] < 0 && nums[i] < nums[n])
                        {
                            sumRight += nums[i];
                        }
                    }
                    else
                    {
                        if (nums[i] < nums[n])
                        {
                            sumRight += nums[i];
                        }
                    }
                }
                else
                {
                    if (command2 == "positive")
                    {
                        if (nums[i] >= nums[n] && nums[i] > 0)
                        {
                            sumRight += nums[i];
                        }
                    }
                    else if (command2 == "negative")
                    {
                        if (nums[i] >= nums[n] && nums[i] < 0)
                        {
                            sumRight += nums[i];
                        }
                    }
                    else
                    {
                        if (nums[i] >= nums[n])
                        {
                            sumRight += nums[i];
                        }
                    }
                }
            }
            for (int i = 0; i < n; i++)
            {
                if (command1 == "cheap")
                {
                    if (command2 == "positive")
                    {
                        if (nums[i] > 0 && nums[i] < nums[n])
                        {
                            sumLeft += nums[i];
                        }
                    }
                    else if (command2 == "negative")
                    {
                        if (nums[i] < 0 && nums[i] < nums[n])
                        {
                            sumLeft += nums[i];
                        }
                    }
                    else
                    {
                        if (nums[i] < nums[n])
                        {
                            sumLeft += nums[i];
                        }
                    }
                }
                else
                {
                    if(command2 == "positive")
                    {
                        if (nums[i] > 0 && nums[i] >= nums[n])
                        {
                            sumLeft += nums[i];
                        }
                    }
                    else if (command2 == "negative")
                    {
                        if (nums[i] < 0 && nums[i] >= nums[n])
                        {
                            sumLeft += nums[i];
                        }
                    }
                    else
                    {
                        if (nums[i] >= nums[n])
                        {
                            sumLeft += nums[i];
                        }
                    }
                }
            }
            if (sumLeft >= sumRight)
            {
                Console.WriteLine($"Left - {sumLeft}");
            }
            else
            {
                Console.WriteLine($"Right - {sumRight}");
            }

        }
    }
}
