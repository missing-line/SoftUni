namespace _7._Append_Arrays
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    public class Program
    {
        public static void Main(string[] args)
        {
            List<string> line = Console.ReadLine()
            .Split("|".ToCharArray(), StringSplitOptions.None)
            .ToList();
            List<string> result = new List<string>();
            for (int i = line.Count - 1; i >= 0; i--)
            {
                string[] curr = line[i].Split(" \t".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).ToArray();
                for (int j = 0; j < curr.Length; j++)
                {
                    result.Add(curr[j].ToString());
                }
            }
            Console.WriteLine(string.Join(" ", result));
        }
    }
}
