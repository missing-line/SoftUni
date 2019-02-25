namespace Fast_Food
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main(string[] args)
        {
            int quantity = int.Parse(Console.ReadLine());

            int[] arr = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();

            Array.Reverse(arr);
            Stack<int> stack = new Stack<int>(arr);
            
            Console.WriteLine(stack.Max());

            while (stack.Count != 0)
            {
                int order = stack.Pop();
                quantity -= order;
                if (stack.Count == 0)
                {
                    break;
                }
                if (quantity < stack.Peek())
                {
                    break;
                }
            }

            Console.WriteLine(stack.Count == 0 ? "Orders complete" : $"Orders left: {string.Join(" ",stack.ToArray())}");
        }
    }
}
