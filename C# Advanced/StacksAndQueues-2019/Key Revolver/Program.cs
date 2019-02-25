namespace Key_Revolver
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main(string[] args)
        {
            int priceOfOneBullet = int.Parse(Console.ReadLine());
            int capacity = int.Parse(Console.ReadLine());

            int[] arr1 = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();


            int[] arr2 = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int intelligence = int.Parse(Console.ReadLine());
            int countShoots = 0;

            Stack<int> stack = new Stack<int>(arr1);
            Queue<int> queue = new Queue<int>(arr2);

            int countReloading = 0;

            while (queue.Count > 0 && stack.Count > 0)
            {
                int locker = queue.Peek();
                int bullet = stack.Pop();
                if (bullet > locker)
                {
                    Console.WriteLine("Ping!");
                }
                else
                {
                    Console.WriteLine("Bang!");
                    queue.Dequeue();
                }
                countShoots++;
                countReloading++;

                if (countReloading == capacity)
                {
                    countReloading = 0;
                    if (stack.Count > 0)
                    {
                        Console.WriteLine("Reloading!");
                    }
                    else
                    {
                        break;
                    }
                }
            }
            if (queue.Any())
            {
                Console.WriteLine($"Couldn't get through. Locks left: {queue.Count}");
                return;
            }
            Console.WriteLine($"{stack.Count} bullets left. Earned ${intelligence - (countShoots * priceOfOneBullet)}");
        }
    }
}
