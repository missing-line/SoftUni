namespace Generic_Box_of_String
{
    using System;
    using System.Collections.Generic;

    public  class Program
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<Box<string>> box = new List<Box<string>>();

            for (int i = 0; i < n; i++)
            {
                string line = Console.ReadLine();

                box.Add(new Box<string>()
                {
                    Value = line,
                });
            }

            box.ForEach(x => Console.WriteLine(x));
        }
    }
}
