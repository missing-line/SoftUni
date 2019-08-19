using System;
using System.Collections.Generic;
using System.Linq;

namespace Seize_the_Fire
{
    class Program
    {
        private static List<int> list = new List<int>();
        private static int totalFire = 0;
        private static double effort = 0;
        private static int water = 0;
        static void Main(string[] args)
        {
            string[] line = Console.ReadLine()
                 .Split('#', StringSplitOptions.RemoveEmptyEntries)
                 .ToArray();

            water = int.Parse(Console.ReadLine());

            foreach (var fire in line)
            {
                string[] token = fire
                    .Split(" =".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string typeOfFire = token[0];
                int fireSize = int.Parse(token[1]);

                switch (typeOfFire)
                {
                    case "High":
                        if (IsHighLevel(fireSize) && water - fireSize >= 0)
                        {
                            Manipulation(fireSize);
                        }
                        break;
                    case "Medium":
                        if (IsMediumLevel(fireSize) && water - fireSize >= 0)
                        {
                            Manipulation(fireSize);
                        }
                        break;
                    case "Low":
                        if (IsLowLevel(fireSize) && water - fireSize >= 0)
                        {
                            Manipulation(fireSize);
                        }
                        break;
                    default:
                        break;
                }
            }
            Print();
        }

        private static void Print()
        {
            Console.WriteLine("Cells: ");
            foreach (var fire in list)
            {
                Console.WriteLine($" - {fire}");
            }
            Console.WriteLine($"Effort: {effort:f2}");
            Console.WriteLine($"Total Fire: {totalFire}");
        }

        private static void Manipulation(int fireSize)
        {
            water -= fireSize;
            totalFire += fireSize;
            effort += fireSize - (fireSize * 0.75);
            list.Add(fireSize);
        }

        private static bool IsLowLevel(int fireSize)
        {
            return fireSize >= 1 && fireSize <= 50;
        }

        private static bool IsMediumLevel(int fireSize)
        {
            return fireSize >= 51 && fireSize <= 80;
        }

        private static bool IsHighLevel(int fireSize)
        {
            return fireSize >= 81 && fireSize <= 125;
        }
    }
}
