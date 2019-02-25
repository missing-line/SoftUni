namespace GenericCountMethodStrings
{
    using System;
    using System.Collections.Generic;

    public class StratUp
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Box<double> box = new Box<double>();

            for (int i = 0; i < n; i++)
            {
                double line = double.Parse(Console.ReadLine());
                box.Data.Add(line);
            }

            double element = double.Parse(Console.ReadLine());

            Console.WriteLine(box.Cointing<double>(box.Data, element));
        }
    }
}
