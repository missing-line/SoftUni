using System;

namespace _04._Convert_Meters_to_Kilometers
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal n = decimal.Parse(Console.ReadLine());
            decimal ress = n / 1000;
            Console.WriteLine($"{ress:f2}");
        }
    }
}
