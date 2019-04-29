using System;
using System.Collections.Generic;
using System.Linq;

namespace Trojan_Invasion
{
    class Program
    {
        static void Main(string[] args)
        {
            int waves = int.Parse(Console.ReadLine());

            var plates = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            Stack<int> stack = new Stack<int>();

            for (int i = 1; i <= waves; i++)
            {
                var warriors = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToList();

                if (plates.Count == 0)
                {
                    continue;
                }

                if (i % 3 == 0)
                {
                    plates.Add(int.Parse(Console.ReadLine()));
                }

                stack = new Stack<int>(warriors);

                Attack(stack, plates);             
            }

            if (plates.Count != 0)
            {
                Console.WriteLine("The Spartans successfully repulsed the Trojan attack.");
            }
            else
            {
                Console.WriteLine("The Trojans successfully destroyed the Spartan defense.");
            }
            if (stack.Count > 0)
            {

                Console.WriteLine($"Warriors left: {string.Join(", ", stack.ToArray())}");
            }
            if (plates.Count > 0)
            {
                Console.WriteLine($"Plates left: {string.Join(", ", plates.ToArray())}");
            }
        }
        private static void Attack(Stack<int> stack, List<int> plates)
        {
            while (stack.Count != 0 && plates.Count != 0)
            {
                int currentWarrior = stack.Pop();

                int plate = plates[0];
                plates.RemoveAt(0);

                if (currentWarrior > plate)
                {
                    currentWarrior -= plate;
                    stack.Push(currentWarrior);
                }
                else if (plate > currentWarrior)
                {
                    plate -= currentWarrior;
                    plates.Insert(0, plate);
                }
            }
        }
    }
}
