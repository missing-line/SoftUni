namespace _02._Pascal_Triangle
{
    using System;
    public class Program
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int[] prev = new int[n];

            for (int i = 1; i <= n; i++)
            {
                int[] curr = new int[i];
                if (curr.Length == 1 || curr.Length == 2)
                {
                    for (int j = 0; j < curr.Length; j++)
                    {
                        curr[j] = 1;
                    }
                }
                else
                {
                    for (int k = 1; k < curr.Length - 1; k++)
                    {
                        curr[0] = 1;
                        curr[curr.Length - 1] = 1;
                        curr[k] = prev[k - 1] + prev[k];
                    }
                }
                prev = curr;
                Console.WriteLine(string.Join(" ", curr));
            }
            Console.WriteLine();
        }
    }
}
