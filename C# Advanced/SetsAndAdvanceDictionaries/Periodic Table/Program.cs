using System;
using System.Collections.Generic;
using System.Linq;

namespace Periodic_Table
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            SortedSet<string> table = new SortedSet<string>();
            
            for (int i = 0; i < n; i++)
            {
                string[] arr = Console.ReadLine()
                .Split()   
                .ToArray();

                for (int j = 0; j < arr.Length; j++)
                {
                    table.Add(arr[j]);
                }
            }
            
            Console.WriteLine(string.Join(" ", table));
        }
    }
}
