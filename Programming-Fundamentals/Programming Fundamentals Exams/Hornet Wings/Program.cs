using System;

namespace Hornet_Wings
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            double m = double.Parse(Console.ReadLine());
            int y = int.Parse(Console.ReadLine());
            double meters = 0;
            double seconds = 0;
            meters = (n / 1000) * m;
            double flaps = n / 100;
            seconds = (n / y) * 5 + flaps;
            Console.WriteLine($"{meters:f2} m.");
            Console.WriteLine($"{seconds} s.");
        }
    }
}
