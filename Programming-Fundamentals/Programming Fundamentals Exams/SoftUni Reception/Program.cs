using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftUni_Reception
{
    class Program
    {
        static void Main(string[] args)
        {
            int fist = int.Parse(Console.ReadLine());
            int second = int.Parse(Console.ReadLine());
            int theed = int.Parse(Console.ReadLine());
            int allStudents = int.Parse(Console.ReadLine());
            int oneHour = fist + second + theed;
            int count = 0;
            int hours = 0;
            while (allStudents > 0)
            {
                count++;
                hours++;
                if (count == 4)
                {
                    count = 0;
                    continue;
                }
                allStudents -= oneHour;
            }
            Console.WriteLine($"Time needed: {hours}h.");
        }
    }
}
