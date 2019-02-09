namespace Top_Integers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    public class Program
    {
        public static void Main(string[] args)
        {
            decimal[] line = Console.ReadLine()
                .Split()
                .Select(decimal.Parse).
                ToArray();

            List<decimal> top = new List<decimal>();

            for (int i = 0; i < line.Length; i++)
            {
                bool isBigger = false;
                for (int i1 = i + 1; i1 < line.Length; i1++)
                {
                    if (line[i] < line[i1])
                    {
                        isBigger = false;
                        break;
                    }
                    else if (line[i] > line[i1])
                    {
                        isBigger = true;
                    }
                }
                if (isBigger)
                {
                    top.Add(line[i]);
                }
            }
            top.Add(line[line.Length - 1]);
            Console.WriteLine(string.Join(" ", top));
        }
    }
}
