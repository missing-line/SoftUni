using System;

namespace Problem_3._p_th_Bit
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int position = int.Parse(Console.ReadLine());
            string converted = Convert.ToString(n, 2);
            Console.WriteLine(converted);
            int shifted = n >> position;
            Console.WriteLine(shifted & 1);
            
        }
    }
}
