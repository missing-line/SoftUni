using System;
using System.Numerics;

namespace _05._Multiply_Big_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            BigInteger x = BigInteger.Parse(Console.ReadLine());
            BigInteger y = BigInteger.Parse(Console.ReadLine());
            BigInteger result = x * y;
            Console.WriteLine(result);            
        }
    }
}
