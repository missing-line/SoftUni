namespace Maximum_and_Minimum_Element
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main(string[] args)
        {
            int countOfOperations = int.Parse(Console.ReadLine());

            Stack<int> stack = new Stack<int>();

            for (int i = 0; i < countOfOperations; i++)
            {
                int[] arr = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();

                if (arr[0] == 1)
                {
                    stack.Push(arr[1]);
                }
                else if (arr[0] == 2 && stack.Count > 0)
                {
                    stack.Pop();
                }
                else if (arr[0] == 3 && stack.Count > 0)
                {
                    Console.WriteLine(stack.Max());
                }
                else if (arr[0] == 4 && stack.Count > 0)
                {
                    Console.WriteLine(stack.Min());
                }
            }

            Console.WriteLine(string.Join(", ",stack.ToArray()));
        }
    }
}
