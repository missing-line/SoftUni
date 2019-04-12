using System;

namespace _05._Pounds_to_Dollars
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal poundQuantity = decimal.Parse(Console.ReadLine());
            decimal onePoundtoUSA = 1.31m;
            Console.WriteLine($"{(poundQuantity*onePoundtoUSA):f3}");
        }
    }
}
