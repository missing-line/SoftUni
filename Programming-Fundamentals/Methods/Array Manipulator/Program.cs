namespace Array_Manipulator
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    class Program
    {
        static void Main(string[] args)
        {
            List<int> nums = Console.ReadLine().Split().Select(int.Parse).ToList();
            string[] command = Console.ReadLine().Split().ToArray();

            while (string.Join("", command) != "end")
            {
                if (command[0] == "exchange")
                {
                    int nRotating = int.Parse(command[1]);
                    if (nRotating >= 0 && nRotating < nums.Count)
                    {
                        List<int> curr = nums.Take(nRotating + 1).ToList();
                        nums = nums.Skip(nRotating + 1).ToList();
                        nums.InsertRange((nums.Count - 1) + 1, curr);
                    }
                    else
                    {
                        Console.WriteLine("Invalid index");
                    }
                }
                else if (string.Join(" ", command) == "max odd")
                {
                    MaxOdd(nums);
                }
                else if (string.Join(" ", command) == "max even")
                {
                    MaxEven(nums);
                }
                else if (string.Join(" ", command) == "min odd")
                {
                    MinOdd(nums);
                }
                else if (string.Join(" ", command) == "min even")
                {
                    MinEven(nums);                   
                }
                else if (command[0] == "first")
                {
                    First(nums,command);                 
                }
                else if (command[0] == "last")
                {
                    Last(nums,command);                   
                }
                command = Console.ReadLine().Split().ToArray();
            }
            Console.WriteLine($"[{string.Join(", ", nums)}]");
        }

        public static void Last(List<int> nums, string[] command)
        {
            int n = int.Parse(command[1]);
            string type = command[2];
            if (n > nums.Count)
            {
                Console.WriteLine("Invalid count");
            }
            else
            {
                if (type == "even")
                {
                    List<int> currN = nums.Where(x => x % 2 == 0).ToList();
                    currN = currN.Skip(currN.Count - n).ToList();
                    Console.WriteLine($"[{string.Join(", ", currN)}]");
                }
                else
                {
                    List<int> currN = nums.Where(x => x % 2 != 0).ToList();
                    currN = currN.Skip(currN.Count - n).ToList();
                    Console.WriteLine($"[{string.Join(", ", currN)}]");
                }
            }
        }

        public static void First(List<int> nums, string[] command)
        {
            int n = int.Parse(command[1]);
            string type = command[2];
            if (n > nums.Count)
            {
                Console.WriteLine("Invalid count");
            }
            else
            {
                if (type == "even")
                {
                    List<int> currN = nums.Where(x => x % 2 == 0).Take(n).ToList();
                    Console.WriteLine($"[{string.Join(", ", currN)}]");
                }
                else
                {
                    List<int> currN = nums.Where(x => x % 2 != 0).Take(n).ToList();
                    Console.WriteLine($"[{string.Join(", ", currN)}]");
                }
            }
        }

        public static void MinEven(List<int> nums)
        {
            try
            {
                int minEven = nums.Where(x => x % 2 == 0).Min();
                int indexCurr = 0;
                int index = -1;
                for (int i = 0; i < nums.Count; i++)
                {
                    if (nums[i] == minEven)
                    {
                        indexCurr = i;
                        if (indexCurr > index)
                        {
                            index = indexCurr;
                        }
                    }
                }
                Console.WriteLine(indexCurr);
            }
            catch (Exception)
            {
                Console.WriteLine("No matches");
            }
        }

        public static void MinOdd(List<int> nums)
        {
            try
            {
                int minOdd = nums.Where(x => x % 2 != 0).Min();
                int indexCurr = 0;
                int index = -1;
                for (int i = 0; i < nums.Count; i++)
                {
                    if (nums[i] == minOdd)
                    {
                        indexCurr = i;
                        if (indexCurr > index)
                        {
                            index = indexCurr;
                        }
                    }
                }
                Console.WriteLine(indexCurr);
            }
            catch (Exception)
            {
                Console.WriteLine("No matches");
            }
        }

        public static void MaxEven(List<int> nums)
        {
            try
            {
                int maxEven = nums.Where(x => x % 2 == 0).Max();
                int indexCurr = 0;
                int index = -1;
                for (int i = 0; i < nums.Count; i++)
                {
                    if (nums[i] == maxEven)
                    {
                        indexCurr = i;
                        if (indexCurr > index)
                        {
                            index = indexCurr;
                        }
                    }
                }
                Console.WriteLine(indexCurr);
            }
            catch (Exception)
            {
                Console.WriteLine("No matches");
            }
        }

        public static void MaxOdd(List<int> nums)
        {
            try
            {
                int maxOdd = nums.Where(x => x % 2 != 0).Max();
                int indexCurr = 0;
                int index = -1;
                for (int i = 0; i < nums.Count; i++)
                {
                    if (nums[i] == maxOdd)
                    {
                        indexCurr = i;
                        if (indexCurr > index)
                        {
                            index = indexCurr;
                        }
                    }
                }
                Console.WriteLine(indexCurr);
            }
            catch (Exception)
            {
                Console.WriteLine("No matches");
            }
        }

        public static int[] Exchange(int[] numbers, int nRotating)
        {
            int jump = nRotating % numbers.Length;
            for (int i = 0; i < jump; i++)
            {
                int lastElement = numbers[numbers.Length - 1];
                for (int j = numbers.Length - 1; j > 0; j--)    // 1 2 3 4 5 -> 5 1 2 3 4
                {
                    numbers[j] = numbers[j - 1];
                }
                numbers[0] = lastElement;
            }
            return numbers;
        }
    }
}
