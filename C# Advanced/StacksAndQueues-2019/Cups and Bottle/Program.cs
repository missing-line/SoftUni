namespace Cups_and_Bottle
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main(string[] args)
        {
            int[] caps = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int[] bottles = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            Queue<int> queue = new Queue<int>(caps);
            Stack<int> stack = new Stack<int>(bottles);

            int wastedWater = 0;

            while (queue.Count > 0 && stack.Count > 0)
            {
                int cap = queue.Peek();
                int bottle = stack.Pop();

                if (cap <= bottle)
                {
                    wastedWater += bottle - cap;
                    queue.Dequeue();
                }
                else if (cap > bottle)
                {
                    queue = ReducerValue(queue, cap, bottle);
                }
            }
            if (stack.Count == 0)
            {
                Console.WriteLine($"Cups: {string.Join(" ", queue.ToArray())}");
            }
            else
            {
                Console.WriteLine($"Bottles: {string.Join(" ", stack.ToArray().Reverse())}");
            }
            Console.WriteLine($"Wasted litters of water: {wastedWater}");
        }

        private static Queue<int> ReducerValue(Queue<int> queue, int cap, int bottle)
        {
            int capValue = cap - bottle;
            queue.Dequeue();
            List<int> list = new List<int>(queue.ToArray());
            list.Insert(0, capValue);
            queue.Clear();
            return queue = new Queue<int>(list);
        }
    }
}
