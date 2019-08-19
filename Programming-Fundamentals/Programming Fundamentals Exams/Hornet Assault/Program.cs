using System;
using System.Collections.Generic;
using System.Linq;

namespace Hornet_Assault
{
    class Program
    {
        static void Main(string[] args)
        {
            long[] beehives = Console.ReadLine().Split().Select(long.Parse).ToArray();
            List<long> hornets = Console.ReadLine().Split().Select(long.Parse).ToList();
            List<long> beehive = new List<long>();

            long maxPower = hornets.Sum();
            for (int i = 0; i < beehives.Length; i++)
            {
                if (beehives[i] >= maxPower)
                {

                    beehives[i] = beehives[i] - maxPower;
                    if (beehives[i] > 0)
                    {
                        beehive.Add(beehives[i]);
                    }
                    if (hornets.Count >= 1)
                    {
                        hornets.RemoveAt(0);
                    }                
                    maxPower = hornets.Sum();
                }
                else if (beehives[i] < maxPower)
                {
                    beehives[i] = 0;
                }
            }
            if (beehive.Count > 0)
            {
                Console.WriteLine(string.Join(" ", beehive));
            }
            else
            {
                Console.WriteLine(string.Join(" ", hornets));
            }
        }
    }
}
