namespace _8.Custom_Comparator
{
    using System;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            int[] nums = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Func<int, int, int> comp = (a, b) =>
            (a % 2 == 0 && b % 2 != 0) ? -1 :
            (a % 2 != 0 && b % 2 == 0) ? 1 :
            a.CompareTo(b);

            Array.Sort(nums, new Comparison<int>(comp));

            Console.WriteLine(string.Join(" ", nums));
        }
    }
}
