namespace Knights_of_Honor
{
    using System;
    using System.Collections;
    using System.Linq;
    public class Program
    {
        public static void Main(string[] args)
        {
            Action<string> print = x => Console.WriteLine($"Sir {x}");

            Console.ReadLine()
                .Split(" \t".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                .ToList()
                .ForEach(print);

            Hashtable hs = new Hashtable();
            hs.Add(1, 2);
            Console.WriteLine(string.Join(" ", hs.Keys));
        }
    }
}
