namespace Reverse_Strings
{
    using System;
    using System.Collections;
    using System.Linq;
    public class Program
    {
        public static void Main(string[] args)
        {
            string words = Console.ReadLine();

            Stack stack = new Stack(words.ToArray());

            Console.WriteLine(string.Join("",stack.ToArray()));
        }
    }
}
