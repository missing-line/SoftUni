using System;

namespace Poke_Mon
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int m = int.Parse(Console.ReadLine());
            int y = int.Parse(Console.ReadLine());
            int count = 0;
            int curr = n;           
            while (curr >= m)
            {
                count++;
                curr -= m;
                if (curr == n / 2)
                {
                    if (y != 0)
                    {
                        curr /= y;                        
                    }
                }
            }
            Console.WriteLine(curr);
            Console.WriteLine(count);
        }
    }
}
