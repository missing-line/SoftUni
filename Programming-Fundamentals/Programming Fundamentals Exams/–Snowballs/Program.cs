using System;
using System.Numerics;

namespace _Snowballs
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            BigInteger currChecker = 0;
            int currSnoq = 0;
            int currTime = 0;
            int currQuantity = 0;
            BigInteger value = 0;
            for (int i = 0; i < n; i++)
            {
                int snow = int.Parse(Console.ReadLine());
                int time = int.Parse(Console.ReadLine());
                int quantity = int.Parse(Console.ReadLine());
                value = BigInteger.Pow((snow / time),quantity);
                if (value > currChecker )
                {
                    currChecker = value;
                    currSnoq = snow;
                    currTime = time;
                    currQuantity = quantity;
                }
            }
            
            Console.WriteLine($"{currSnoq} : {currTime} = {currChecker} ({currQuantity})");
        }
    }
}
