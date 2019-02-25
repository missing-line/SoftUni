namespace Sets_of_Elements
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    public class Program
    {
        public static void Main(string[] args)
        {
            HashSet<int> n = new HashSet<int>();
            HashSet<int> m = new HashSet<int>();

            int[] arr = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            for (int i = 0; i < arr[0]; i++)
            {
                int currN = int.Parse(Console.ReadLine());
                n.Add(currN);
            }

            for (int i = 0; i < arr[1]; i++)
            {
                int currM = int.Parse(Console.ReadLine());
                m.Add(currM);
            }

            int[] array = n.Where(x => m.Contains(x)).ToArray();
            Console.WriteLine(string.Join(" ",array));
        }
    }
}
