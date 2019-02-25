namespace Simple_Calculator
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    public class Program
    {
        public static void Main(string[] args)
        {
            string[] arr = Console.ReadLine()
                 .Split()                
                 .ToArray();
            
            Stack<string> calculator = new Stack<string>(arr);

            int sum = 0;
           
            while (true)
            {
                int stackPop = int.Parse(calculator.Pop());               
                string stackSymbol = calculator.Pop();
                if (stackSymbol == "+")
                {
                    sum += stackPop;
                }
                else
                {
                    sum -= stackPop;
                }                
                if (calculator.Count == 1)
                {
                    sum += int.Parse(calculator.Pop());
                    break;
                }
                
            }

            Console.WriteLine(sum);
        }
    }
}
