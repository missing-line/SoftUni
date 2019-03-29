using System;

namespace _6._Middle_Characters
{
    class Program
    {
        static void Main(string[] args)
        {
            string word = Console.ReadLine();
            MiddleChar(word);
        }
        public static void MiddleChar(string word)
        {
            if (word.Length % 2 == 0)
            {
                char curr = word[word.Length / 2];
                char curr1 = word[word.Length / 2 - 1];
                Console.WriteLine($"{curr1}{curr}");
            }
            else
            {
                char curr = word[word.Length / 2];
                Console.WriteLine(curr);
            }
        }
    }
}
