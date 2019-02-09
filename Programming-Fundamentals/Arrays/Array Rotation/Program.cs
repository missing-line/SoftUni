namespace Array_Rotation
{
    using System;
    using System.Linq;
    public class Program
    {
        public static void Main(string[] args)
        {
            string[] line = Console.ReadLine().Split().ToArray();
            int n = int.Parse(Console.ReadLine());

            int jump = n % line.Length;

            for (int i = 0; i < jump; i++)
            {
                string element = line[0];
                for (int i1 = 0; i1 < line.Length - 1; i1++)
                {
                    line[i1] = line[i1 + 1];
                }
                line[line.Length - 1] = element;
            }
            Console.WriteLine(string.Join(" ", line));
        }
    }
}
