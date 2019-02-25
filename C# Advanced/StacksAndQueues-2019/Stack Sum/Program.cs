
namespace Stack_Sum
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

            Stack<int> stack = new Stack<int>(arr);

            string[] command = Console.ReadLine()
                .Split()
                .ToArray();

            while (string.Join("", command) != "end")
            {
                if (command[0] == "add")
                {
                    int num1 = int.Parse(command[1]);
                    int num2 = int.Parse(command[2]);
                    stack.Push(num1);
                    stack.Push(num2);
                }
                else
                {
                    int removeCount = int.Parse(command[1]);
                    RemoveElements(stack, removeCount);
                }
                command = Console.ReadLine()
                .Split()
                .ToArray();
            }

            int[] array = stack.ToArray();
            Console.WriteLine($"Sum: {array.Sum()}");
        }

        private static void RemoveElements(Stack<int> stack, int removeCount)
        {
            if (removeCount <= stack.Count)
            {
                while (removeCount > 0)
                {
                    stack.Pop();
                    removeCount--;
                }

            }
        }
    }
}
