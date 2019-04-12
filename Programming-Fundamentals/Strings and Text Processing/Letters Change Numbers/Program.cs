using System;
using System.Linq;

namespace Letters_Change_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] line = Console.ReadLine().Split("\t ".ToCharArray(),StringSplitOptions.RemoveEmptyEntries).ToArray();
            double sum = 0;
            for (int i = 0; i < line.Length; i++)
            {
                double currSum = 0;
                char firstLetter = line[i][0];
                char second = line[i][line[i].Length - 1];
                string numberForParse = line[i].Substring(1,line[i].Length - 2);
                double value = double.Parse(numberForParse);
                if (char.IsUpper(firstLetter))
                {
                    int index = char.ToUpper(firstLetter) - 64; // /
                    currSum += (value / index);
                }
                else
                {
                    int index = char.ToUpper(firstLetter) - 64; // *
                    currSum += (value * index);
                }
                if (char.IsUpper(second)) // -
                {
                    int index = char.ToUpper(second) - 64;
                    currSum -= index;

                }
                else // + 
                {
                    int index = char.ToUpper(second) - 64;
                    currSum += index;
                }
                sum += currSum;
            }
            Console.WriteLine($"{sum:f2}");
        }
    }
}
