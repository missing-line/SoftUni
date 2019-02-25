namespace Action_Point
{
    using System;
    using System.Linq;
    public class Program
    {
        public static void Main(string[] args)
        {
            Action<string> print = x => Console.WriteLine(x);

            Console.ReadLine()
                .Split()
                .ToList()
                .ForEach(print);
        }
    }
}
