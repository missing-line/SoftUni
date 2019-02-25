namespace Custom_Min_Function
{
    using System;
    using System.Linq;
    public class Program
    {
        public static void Main(string[] args)
        {
            Func<int[], int> min = n => n.Min();

            int[] arr = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            Console.WriteLine(min(arr));
        }
    }
}
