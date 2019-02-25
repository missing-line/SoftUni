namespace Hot_Potato
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main(string[] args)
        {
            string[] names = Console.ReadLine()
                .Split()
                .ToArray();

            Queue<string> queue = new Queue<string>(names);

            Queue<string> queueMid = new Queue<string>();

            int n = int.Parse(Console.ReadLine());

            while (queue.Count != 1)
            {
                for (int i = 0; i < n - 1; i++)
                {
                    queue.Enqueue(queue.Dequeue());
                }
                Console.WriteLine("Removed " + queue.Dequeue());
            }
            Console.WriteLine("Last is " +queue.Dequeue());
        }
    }
}
