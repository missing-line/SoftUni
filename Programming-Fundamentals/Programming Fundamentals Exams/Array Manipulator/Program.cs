using System;
using System.Collections.Generic;
using System.Linq;

namespace Array_Manipulator
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> nums = Console.ReadLine().Split().Select(int.Parse).ToList();
            string[] command = Console.ReadLine().Split().ToArray();
            while (command[0] != "end")
            {
                if (command[0] == "exchange")
                {
                    int currN = int.Parse(command[1]);
                    if (currN < nums.Count && currN >= 0)
                    {
                        List<int> curr = nums.Take(currN + 1).ToList();
                        nums = nums.Skip(currN + 1).ToList();
                        nums.InsertRange((nums.Count - 1) + 1, curr);                       
                    }
                    else
                    {
                        Console.WriteLine("Invalid index");
                    }
                }
                else if (command[0] == "max" || command[0] == "min")
                {
                    if (command[0] == "max")
                    {
                        int max = 0;
                        int index = 0;
                        if (command[1] == "odd")
                        {
                            try
                            {
                                max = nums.Where(x => x % 2 != 0).Max();
                                Console.WriteLine(index = nums.FindLastIndex(item => item == max));
                            }
                            catch (Exception)
                            {
                                Console.WriteLine("No matches");
                            }
                        }
                        else
                        {
                            try
                            {
                                max = nums.Where(x => x % 2 == 0).Max();
                                Console.WriteLine(index = nums.FindLastIndex(item => item == max));
                            }
                            catch (Exception)
                            {
                                Console.WriteLine("No matches");
                            }
                        }
                    }
                    else if (command[0] == "min")
                    {
                        int min = 0;
                        int index = 0;
                        if (command[1] == "odd")
                        {
                            try
                            {
                                min = nums.Where(x => x % 2 != 0).Min();
                                Console.WriteLine(index = nums.FindLastIndex(item => item == min));
                            }
                            catch (Exception)
                            {
                                Console.WriteLine("No matches");
                            }
                        }
                        else
                        {
                            try
                            {
                                min = nums.Where(x => x % 2 == 0).Min();
                                Console.WriteLine(index = nums.FindLastIndex(item => item == min));
                            }
                            catch (Exception)
                            {

                                Console.WriteLine("No matches");
                            }
                        }
                    }
                }
                else if (command[0] == "first")
                {
                    int n = int.Parse(command[1]);
                    string type = command[2];
                    if (n > nums.Count || n < 1)
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
                else if (command[0] == "last")
                {
                    int n = int.Parse(command[1]);
                    string type = command[2];
                    if (n > nums.Count || n < 1)
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
                command = Console.ReadLine().Split().ToArray();
            }
            Console.WriteLine($"[{string.Join(", ", nums)}]");
        }
    }
}

