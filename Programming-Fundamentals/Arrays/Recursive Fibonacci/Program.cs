namespace Recursive_Fibonacci
{
    using System;
    public class Program
    {
        public static void Main(string[] args)
        {
            var number = int.Parse(Console.ReadLine());
            var fib = Fib_Rec(number);

            Console.WriteLine(
                $"{fib}"
                );
        }
        public static int Fib_Rec(int n)
        {
            if (n <= 0)
                return 0;
            else if (n == 1 || n == 2)
                return 1;
            else
                return Fib_Rec(n - 1) + Fib_Rec(n - 2);
        }
    }
}
