namespace Basic_Queue_Operations
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    public class Program
    {
        public static void Main(string[] args)
        {
            int[] arr = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int[] numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            Queue<int> queue = new Queue<int>();
            FillQueue(queue, arr, numbers);

            while (arr[1] != 0)
            {
                if (queue.Count == 0)
                {
                    break;
                }
                queue.Dequeue(); ;
                arr[1]--;
            }

            Console.WriteLine(queue.Count == 0 ? "0".ToString() : queue.Contains(arr[2]) ? "true" : queue.Min().ToString());
        }

        private static void FillQueue(Queue<int> queue, int[] arr, int[] numbers)
        {
            if (numbers.Length < arr[0])
            {
                for (int i = 0; i < numbers.Length; i++)
                {
                    queue.Enqueue(numbers[i]);
                }
            }
            else
            {
                for (int i = 0; i < arr[0]; i++)
                {
                    queue.Enqueue(numbers[i]);
                }
            }
        }
    }
}
