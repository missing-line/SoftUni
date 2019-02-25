namespace Balanced_Parentheses
{
    using System;   
    using System.Collections.Generic;
    public class Program
    {
        public static void Main(string[] args)
        {                                            //{[()()()]} - check for that case!!!!
            string line = Console.ReadLine();

            if (line.Length % 2 != 0)
            {
                Console.WriteLine("NO");
                return;
            }

            Stack<char> stack = new Stack<char>();
         
            bool isBalanced = true;

            foreach (var ch in line)
            {
                if (ch == '{' || ch == '[' || ch == '(')
                {
                    stack.Push(ch);
                }
                else if (ch == '}')
                {
                    if (stack.Pop() != '{')
                    {
                        isBalanced = false;
                        break;
                    }
                }
                else if (ch == ']')
                {
                    if (stack.Pop() != '[')
                    {
                        isBalanced = false;
                        break;
                    }
                }
                else if (ch == ')')
                {
                    if (stack.Pop() != '(')
                    {
                        isBalanced = false;
                        break;
                    }
                }
            }

            Console.WriteLine(isBalanced ? "YES" : "NO");
        }
    }
}
