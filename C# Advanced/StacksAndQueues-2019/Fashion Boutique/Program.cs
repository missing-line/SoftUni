namespace Fashion_Boutique
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

            int capacity = int.Parse(Console.ReadLine());

            Stack<int> stack = new Stack<int>(arr);

            int sum = 0;
            int racks = 0;
            while (stack.Count > 0)
            {
                int currClothes = stack.Pop();
                if (sum + currClothes <= capacity)
                {
                    sum += currClothes;
                    if (stack.Count == 0)
                    {
                        racks++;
                        break;
                    }
                }
                else
                {
                    sum = 0;
                    racks++;
                    stack.Push(currClothes);
                }
            }
            Console.WriteLine(racks);
        }
    }
}
