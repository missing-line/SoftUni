namespace Basic_Stack_Operations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

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

            Stack<int> stack = new Stack<int>();
            FillStack(stack, arr, numbers);

            while (arr[1] != 0)
            {
                if (stack.Count == 0)
                {
                    break;
                }
                stack.Pop();
                arr[1]--;
            }

            Console.WriteLine(stack.Count == 0 ? "0".ToString() : stack.Contains(arr[2]) ? "true" : stack.Min().ToString());
        }

        private static void FillStack(Stack<int> stack, int[] arr, int[] numbers)
        {
            if (numbers.Length < arr[0])
            {
                for (int i = 0; i < numbers.Length; i++)
                {
                    stack.Push(numbers[i]);
                }
            }
            else
            {
                for (int i = 0; i < arr[0]; i++)
                {
                    stack.Push(numbers[i]);
                }
            }
        }
    }
}
