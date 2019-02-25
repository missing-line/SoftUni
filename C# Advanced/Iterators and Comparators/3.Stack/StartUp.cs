namespace _3.Stack
{
    using System;
    using System.Linq;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            Stack<string> stack = new Stack<string>();

            string input;

            while ((input = Console.ReadLine()) != "END")
            {
                string[] arr = input
                    .Split(", ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string command = arr[0];

                if (command == "Push")
                {
                    stack.Push(arr.Skip(1).ToArray());
                }
                else if (command == "Pop")
                {
                    stack.Pop();
                }
            }

            for (int i = 0; i < 2; i++)
            {
                foreach (var element in stack)
                {
                    Console.WriteLine(element);
                }
            }
        }
    }
}
