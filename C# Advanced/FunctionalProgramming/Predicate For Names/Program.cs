namespace Predicate_For_Names
{
    using System;
    using System.Linq;
    public class Program
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());


            Predicate<string> checkLenght = x => x.Length <= n;
            Func<string, bool> filter = x => checkLenght(x);
            string[] words = Console.ReadLine()
                .Split()
                .Where(filter)
                .ToArray();
            Console.WriteLine(string.Join("\n", words));
        }
    }
}
