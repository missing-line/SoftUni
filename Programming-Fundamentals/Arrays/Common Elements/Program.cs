namespace Common_Elements
{
    using System;
    using System.Linq;
    public class Program
    {
        public static void Main(string[] args)
        {
            string[] line1 = Console.ReadLine().Split().ToArray();
            string[] line2 = Console.ReadLine().Split().ToArray();

            string result = "";

            for (int i = 0; i < line2.Length; i++)
            {
                for (int i1 = 0; i1 < line1.Length; i1++)
                {
                    if (line2[i] == line1[i1] && !result.Contains(line2[i]))
                    {
                        result += line2[i] + " ";
                    }
                }
            }
            Console.WriteLine(result.Trim());
        }
    }
}
