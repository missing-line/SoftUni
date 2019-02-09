namespace _03._Zig_Zag_Arrays
{
    using System;
    using System.Linq;
    public class Program
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            string[] line1 = new string[n];
            string[] line2 = new string[n];

            for (int i = 1; i <= n; i++)
            {
                string[] curr = Console.ReadLine().Split().ToArray();
                if (i % 2 != 0)
                {
                    line1[i - 1] = curr[0];
                    line2[i - 1] = curr[1];
                }
                else
                {
                    line1[i - 1] = curr[1];
                    line2[i - 1] = curr[0];
                }
            }

            Console.WriteLine(string.Join(" ", line1));
            Console.WriteLine(string.Join(" ", line2));
        }
    }
}
