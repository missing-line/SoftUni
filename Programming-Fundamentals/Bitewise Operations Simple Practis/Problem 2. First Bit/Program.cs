using System;

namespace Problem_2._First_Bit
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int shifted = n >> 1;
            Console.WriteLine(shifted & 1);
        }
    }
}
