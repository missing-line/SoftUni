using System;
using System.Collections.Generic;
using System.Linq;

namespace Memory_View
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] nums = Console.ReadLine().Split().ToArray();
            //string[] p = n.Skip(5).Take(6).Where(x => int.Parse(x) != 0).ToArray();
            int currEnd = -1;
            int midd = -1;
            string take = string.Empty;
            List<string> words = new List<string>();
            while (true)
            {
                if (midd < 0)
                {
                     take = string.Empty;
                }                               
                for (int i = 0; i < nums.Length - 2; i++)
                {
                    if ( midd > 0)
                    {
                        string[] p = nums.Take(midd).ToArray();
                        for (int i1 = 0; i1 < p.Length; i1++)
                        {
                            take += (char)int.Parse(p[i1]);
                        }
                        words.Add(take);
                        take = string.Empty;
                        midd = -1;                        
                    }
                     if (currEnd == 0  && int.Parse(nums[0]) != 0 && int.Parse(nums[0]) <= nums.Length && int.Parse(nums[1]) == 0)
                    {
                        string[] p = nums.Skip(i + 2).Take(int.Parse(nums[i])).ToArray();
                        for (int i1 = 0; i1 < p.Length; i1++)
                        {
                            take += (char)int.Parse(p[i1]);
                        }
                        words.Add(take);
                        take = string.Empty;
                        currEnd = -1;
                    }
                    else if (int.Parse(nums[i]) == 0 && int.Parse(nums[i + 1]) != 0 /*&& (int.Parse(nums[i + 1]) <= nums.Length - i)*/)
                    {
                        if ((int.Parse(nums[i + 1]) <= nums.Length - i) && int.Parse(nums[i + 2]) == 0)
                        {
                            string[] p = nums.Skip(i + 3).Take(int.Parse(nums[i + 1])).ToArray();
                            for (int i1 = 0; i1 < p.Length; i1++)
                            {
                                take += (char)int.Parse(p[i1]);
                            }
                            words.Add(take);
                            take = string.Empty;                          
                        }
                        else if ((int.Parse(nums[i + 1]) > nums.Length - i) && (int.Parse(nums[i + 1]) <= 22) && int.Parse(nums[i + 2]) == 0)
                        {
                            string[] p = nums.Skip(i + 3).Take(int.Parse(nums[i + 1])).ToArray();
                            for (int i1 = 0; i1 < p.Length; i1++)
                            {
                                take += (char)int.Parse(p[i1]);
                            }
                            midd = int.Parse(nums[i + 1]) - take.Length;
                            break;
                        }                     
                    }                   
                }
                currEnd = -1;
                if (int.Parse(nums[nums.Length - 1]) == 0)
                {
                    currEnd = 0;
                }
                nums = Console.ReadLine().Split().ToArray();               
                if (string.Join(" ",nums.Take(3)) == "Visual Studio crash")
                {                    
                    break;
                }                
            }
            foreach (var word in words)
            {
                Console.WriteLine(word);
            }
           
            

        }
    }
}
