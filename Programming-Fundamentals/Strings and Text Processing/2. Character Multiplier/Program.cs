using System;
using System.Linq;

namespace _2._Character_Multiplier
{
    class Program
    {
        static void Main(string[] args)
        {
           
            string[] line = Console.ReadLine().Split().ToArray();
            int sum = 0;
            int min = Math.Min(line[0].Length, line[1].Length);
            int max = Math.Max(line[0].Length, line[1].Length);

            if (line[0].Length == line[1].Length)
            {
                for (int i = 0; i < min; i++)
                {
                    int fisrt = (int)line[0][i];
                    int second = (int)line[1][i];
                    sum += (fisrt * second);
                }
            }
            else
            {
                for (int i = 0; i < min; i++)
                {
                    int fisrt = (int)line[0][i];
                    int second = (int)line[1][i];
                    sum += (fisrt * second);
                }
                if (line[0].Length == max)
                {                 
                    for (int i = min; i < max; i++)
                    {
                        sum += (int)line[0][i];
                    }
                }
                else if (max == line[1].Length)
                {                   
                    for (int i = min; i < max; i++)
                    {
                        sum += (int)line[1][i];
                    }
                }
            }
            Console.WriteLine(sum);
        }
    }
}
