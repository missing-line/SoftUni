namespace _04._Reverse_Array_of_Strings
{
    using System;
    using System.Linq;
    public class Program
    {
        public static void Main(string[] args)
        {
            string[] chars = Console.ReadLine().Split().ToArray();
            Array.Reverse(chars);
            Console.WriteLine(string.Join(" ", chars));
        }
    }
}
