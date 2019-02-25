namespace Add_VAT
{
    using System;
    using System.Linq;
    public class Program
    {
        public static void Main(string[] args)
        {
            double[] nums = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .Select(n => n * 1.2)
                .ToArray();

            foreach (var vat in nums)
            {
                Console.WriteLine($"{vat:f2}");
            }
        }
    }
}
