namespace Unique_Usernames
{
    using System;
    using System.Collections.Generic;

    public class Program
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            HashSet<string> names = new HashSet<string>();

            for (int i = 0; i < n; i++)
            {
                string name;
                names.Add(name = Console.ReadLine());
            }
            Console.WriteLine(string.Join("\n", names));
        }
    }
}
