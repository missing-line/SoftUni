namespace Applied_Arithmetics
{
    using System;
    using System.Linq;
    public class Program
    {
        public static void Main(string[] args)
        {
            int[] nums = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            string command = Console.ReadLine();

            Func<int[], int[]> add = x => x.Select(y => y + 1).ToArray();
            Func<int[], int[]> multiply = x => x.Select(y => y / 2).ToArray();
            Func<int[], int[]> subtract = x => x.Select(y => y - 1).ToArray();
            Func<int[], string> print = x => string.Join(" ", x);
            while (command != "end")
            {
                if (command == "add")
                {
                    nums = add(nums);
                }
                else if (command == "multiply")
                {
                    nums = multiply(nums);
                }
                else if (command == "subtract")
                {
                    nums = subtract(nums);
                }
                else if (command == "print")
                {
                    Console.WriteLine(print(nums));
                }
                command = Console.ReadLine();
            }
        }
    }
}
