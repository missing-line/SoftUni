namespace Supermarket
{
    using System;
    using System.Collections.Generic;
    public class Program
    {
        public static void Main(string[] args)
        {
            Queue<string> queue = new Queue<string>();

            string name = Console.ReadLine();

            while (name != "End")
            {
                if (name == "Paid")
                {
                    DequeueNames(queue);                  
                }
                else
                {
                    queue.Enqueue(name);
                }
                name = Console.ReadLine();
            }

            Console.WriteLine($"{queue.Count} people remaining.");
        }

        private static void DequeueNames(Queue<string> queue)
        {
            while (queue.Count != 0)
            {
                Console.WriteLine(queue.Dequeue());
            }
        }
    }
}
