namespace Simple_Text_Editor
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Program
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            StringBuilder manipulator = new StringBuilder();
            Stack<string> operations = new Stack<string>();

            for (int i = 0; i < n; i++)
            {
                string[] arr = Console.ReadLine()
                    .Split()
                    .ToArray();

                if (arr[0] == "1")
                {
                    operations.Push(manipulator.ToString());
                    manipulator.Append(arr[1]);
                }
                else if (arr[0] == "2")
                {
                    operations.Push(manipulator.ToString());
                    manipulator = manipulator.Remove(manipulator.Length - int.Parse(arr[1]), int.Parse(arr[1]));
                }
                else if (arr[0] == "3")
                {
                    int index = int.Parse(arr[1]);
                    Console.WriteLine(manipulator[index - 1]);
                }
                else if (arr[0] == "4")
                {
                    manipulator.Remove(0,manipulator.Length);
                    manipulator.Append(operations.Pop());
                }
            }
        }
    }
}
