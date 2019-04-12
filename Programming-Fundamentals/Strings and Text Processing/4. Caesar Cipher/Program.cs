using System;
using System.Text;

namespace _4._Caesar_Cipher
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            StringBuilder builder = new StringBuilder();

            for (int i = 0; i < text.Length; i++)
            {
                int currChar = (int)text[i] + 3;
                builder.Append((char)currChar);
            }
            Console.WriteLine(builder);
        }
    }
}
