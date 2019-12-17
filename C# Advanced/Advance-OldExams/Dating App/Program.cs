namespace Dating_App
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        private static int matches;
        public static void Main(string[] args)
        {
            var males = Console.ReadLine()
                .Split(' ')
                .Select(x => int.Parse(x))
                .ToArray();

            var females = Console.ReadLine()
                .Split(' ')
                .Select(x => int.Parse(x))
                .ToArray();

            var stack = new Stack<int>(males);
            var queue = new Queue<int>(females);

            while (stack.Count() != 0 && queue.Count() != 0)
            {
                var male = stack.Peek();
                var female = queue.Peek();

                bool isDivisibleMale = false;
                bool isDivisibleFemale = false;

                if (male <= 0)
                {
                    stack.Pop();
                    continue;
                }
                if (female <= 0)
                {
                    queue.Dequeue();
                    continue;
                }

                if (male % 25 == 0)
                {
                    stack.Pop();
                    if (stack.Count() != 0)
                    {
                        stack.Pop();
                    }
                    isDivisibleMale = true;
                }
                if (female % 25 == 0)
                {
                    queue.Dequeue();
                    if (queue.Count() != 0)
                    {
                        queue.Dequeue();
                    }
                    isDivisibleFemale = true;
                }
                if (isDivisibleMale || isDivisibleFemale)
                {
                    continue;
                }


                if (male != female)
                {
                    queue.Dequeue();
                    stack.Push(stack.Pop() - 2);
                    continue;
                }

                if (male == female)
                {
                    stack.Pop();
                    queue.Dequeue();
                    matches++;
                }
            }

            Console.WriteLine($"Matches: {matches}");
            Console.WriteLine("Males left: {0}", stack.Count() == 0 ? "none" : string.Join(", ", stack));
            Console.WriteLine("Females left: {0}", queue.Count() == 0 ? "none" : string.Join(", ", queue));
        }
    }
}
