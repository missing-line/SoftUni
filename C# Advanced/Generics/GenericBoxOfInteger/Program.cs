namespace GenericBoxOfInteger
{
    using System;
    using System.Collections.Generic;

    public class Program
    {
        public static void Main(string[] args)
        {
            List<Box<int>> box = new List<Box<int>>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                int number = int.Parse(Console.ReadLine());

                box.Add(new Box<int>()
                {
                    Value = number,
                });
            }

            box.ForEach(x => Console.WriteLine(x));
        }
    }
}
