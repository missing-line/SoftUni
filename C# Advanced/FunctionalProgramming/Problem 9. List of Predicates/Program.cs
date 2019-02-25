namespace _09._List_of_Predicates
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    public class Program
    {
        public static void Main(string[] args)
        {
            int endRange = int.Parse(Console.ReadLine());
            var dividers = Console.ReadLine()
                .Split()
                .Distinct()
                .Select(int.Parse)
                .ToList();


            List<int> result = new List<int>();

            for (int i = 1; i <= endRange; i++)
            {
                bool isD = true;
                foreach (var number in dividers)
                {
                    if (i % number != 0)
                    {
                        isD = false;
                        break;
                    }
                }
                if (isD)
                {
                    result.Add(i);
                }
            }

            Console.WriteLine(string.Join(" ", result));
        }
    }
}
