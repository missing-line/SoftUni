namespace TriFunction
{
    using System;
    using System.Linq;
    public class Program
    {
        public static void Main(string[] args)
        {
            Func<string, int, bool> equals = (a, b) => a.Sum(x => x) >= b;

            int n = int.Parse(Console.ReadLine());

            string[] words = Console.ReadLine()
                .Split()
                .ToArray();

            string result = words.FirstOrDefault(x => equals(x, n));

            Console.WriteLine(result);
        }
    }
}
