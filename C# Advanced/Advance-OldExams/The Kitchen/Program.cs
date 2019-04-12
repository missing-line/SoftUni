namespace The_Kitchen
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static void Main(string[] args)
        {
            int[] knives = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int[] forks = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            Stack<int> stack = new Stack<int>(knives);

            Queue<int> queue = new Queue<int>(forks);

            List<int> sets = new List<int>();

            while (stack.Any() && queue.Any())
            {
                int currKnive = stack.Pop();
                int currFork = queue.Peek();

                if (currKnive > currFork)
                {                  
                    queue.Dequeue();
                    sets.Add(currFork + currKnive);
                }                
                else if (currFork == currKnive)
                {
                    currKnive++;
                    stack.Push(currKnive);
                    queue.Dequeue();
                }
            }
            Console.WriteLine($"The biggest set is: {sets.Max()}");
            Console.WriteLine(string.Join(" ",sets));
        }
    }
}
