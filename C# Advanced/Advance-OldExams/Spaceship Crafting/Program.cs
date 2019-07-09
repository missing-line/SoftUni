namespace Spaceship_Crafting
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        private static int Aluminium = 0;
        private static int CarbonFiber = 0;
        private static int Glass = 0;
        private static int Lithium = 0;
        private static Queue<int> queue;
        private static Stack<int> stack;
        private static List<int> advanceMaterialsValue = new List<int>() { 25, 50, 75, 100 };
        public static void Main(string[] args)
        {
          
            int[] chemicals = Console.ReadLine()
                 .Split(" ")
                 .Select(int.Parse)
                 .ToArray();

            int[] items = Console.ReadLine()
                 .Split(" ")
                 .Select(int.Parse)
                 .ToArray();

            queue = new Queue<int>(chemicals);
            stack = new Stack<int>(items);

            while (stack.Count != 0 && queue.Count != 0)
            {
                int stackElement = stack.Pop();
                int queueElement = queue.Dequeue();
                int sum = stackElement + queueElement;

                if (advanceMaterialsValue.Contains(sum))
                {
                    AddMaterial(sum);                  
                }
                else
                {
                    stackElement += 3;
                    stack.Push(stackElement);
                }

            }

            Print();
        }

        private static void AddMaterial(int sum)
        {
            switch (sum)
            {
                case 25:
                    Glass++;
                    break;
                case 50:
                    Aluminium++;
                    break;
                case 75:
                    Lithium++;
                    break;
                case 100:
                    CarbonFiber++;
                    break;
            }
        }

        private static void Print()
        {
            if (Aluminium == 0 || Glass == 0 || Lithium == 0 || CarbonFiber == 0)
            {
                Console.WriteLine("Ugh, what a pity! You didn't have enough materials to build the spaceship.");             
            }
            else
            {
                Console.WriteLine("Wohoo! You succeeded in building the spaceship!");               
            }

            if (queue.Count != 0)
            {
                Console.WriteLine($"Liquids left: {string.Join(", ", queue)}");

            }
            else
            {
                Console.WriteLine("Liquids left: none");
            }
            if (stack.Count != 0)
            {

                Console.WriteLine($"Physical items left: {string.Join(", ", stack)}");
            }
            else
            {
                Console.WriteLine("Physical items left: none");
            }

            Console.WriteLine($"Aluminium: {Aluminium}");
            Console.WriteLine($"Carbon fiber: {CarbonFiber}");
            Console.WriteLine($"Glass: {Glass}");
            Console.WriteLine($"Lithium: {Lithium}");

        }
    }
}
