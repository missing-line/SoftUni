using System;
using System.Collections.Generic;
using System.Linq;

namespace _2._SoftUni_Water_Supplies
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal waterQuantity = decimal.Parse(Console.ReadLine());

            string[] line = Console.ReadLine().Split().ToArray();

            decimal bottleCapacity = decimal.Parse(Console.ReadLine());

            List<int> notEnought = new List<int>();

            decimal neededWater = 0;

            if (waterQuantity % 2 == 0)
            {
                for (int i = 0; i < line.Length; i++)
                {
                    decimal currN = decimal.Parse(line[i]);
                    decimal refil = 0;

                    refil = bottleCapacity - currN;

                    if (waterQuantity >= refil)
                    {
                        waterQuantity -= refil;
                    }
                    else
                    {
                        neededWater += refil - waterQuantity;// ???
                        waterQuantity = 0;
                        notEnought.Add(i);
                    }
                }
                
            }
            else
            {
                for (int i = line.Length - 1; i >= 0; i--)
                {
                    decimal currN = decimal.Parse(line[i]);
                    decimal refil = 0;

                    refil = bottleCapacity - currN;   
                    
                    if (waterQuantity >= refil)
                    {
                        waterQuantity -= refil;
                    }
                    else
                    {
                        neededWater += refil - waterQuantity;// ???
                        waterQuantity = 0;
                        notEnought.Add(i);
                    }
                }
            }
            if (neededWater == 0)
            {
                Console.WriteLine("Enough water!");
                Console.WriteLine($"Water left: {waterQuantity}l.");
            }
            else
            {
                Console.WriteLine("We need more water!");
                Console.WriteLine($"Bottles left: {notEnought.Count}");
                Console.WriteLine($"With indexes: {string.Join(", ", notEnought)}");
                Console.WriteLine($"We need {neededWater} more liters!");
            }
        }
    }
}
