using System;

namespace Problem_4._Bit_Destroyer
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int position = int.Parse(Console.ReadLine());
            string converted = Convert.ToString(n, 2);
            Console.WriteLine($"N: {converted}");
            Console.WriteLine($"Position: {Convert.ToString(position, 2)}");
            Console.WriteLine($"Position: {Convert.ToString(~position, 2)}");

            int mask = (1 << position); // изместваме побитово числото 1...
            Console.WriteLine(Convert.ToString(mask, 2));                    
            int masked = ~mask;
            Console.WriteLine(Convert.ToString(masked, 2));
            int rs = n & masked;
            Console.WriteLine(rs);
            
            


        }
    }
}
