namespace Truck_Tour
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Queue<int> queue = new Queue<int>();

            for (int i = 0; i < n; i++)
            {
                int[] arr = Console.ReadLine() // 1 5       10 3        3 4
                    .Split()
                    .Select(int.Parse)
                    .ToArray();
                queue.Enqueue(arr[0] - arr[1]);
            }

            int index = 0;
            while (true)
            {
                Queue<int> copyOriginalDiff = new Queue<int>(queue);
                int fuel = -1;
                
                while (copyOriginalDiff.Any())
                {

                    if (copyOriginalDiff.Peek() > 0 && fuel == -1)
                    {
                        fuel = copyOriginalDiff.Dequeue();
                        queue.Enqueue(queue.Dequeue());
                    }
                    else if (copyOriginalDiff.Peek() < 0 && fuel == -1)
                    {
                        copyOriginalDiff.Enqueue(copyOriginalDiff.Dequeue());
                        queue.Enqueue(queue.Dequeue());
                        index++;
                    }
                    else
                    {
                        fuel += copyOriginalDiff.Dequeue();
                        if (fuel < 0)
                        {                        
                            break;
                        }
                    }
                }
                if (fuel >= 0)
                {
                    Console.WriteLine(index);
                    return;
                }
                index++;
            }
        }
    }
}
