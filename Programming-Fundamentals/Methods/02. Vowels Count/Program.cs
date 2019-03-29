using System;
using System.Linq;

namespace _02._Vowels_Count
{
    class Program
    {
        static void Main(string[] args)
        {
            string word = Console.ReadLine().ToLower();
            int countOfVowels = ReturnVowelsCount(word);
            Console.WriteLine(countOfVowels);
        }

        public static int ReturnVowelsCount(string word)
        {
            int count = 0;
            char[] vowels = new char[]
            {
                'a',
                'o',
                'u',
                'y',
                'i',
                'e',
            };
            for (int i = 0; i < word.Length; i++)
            {
                if(vowels.Contains(word[i]))
                {
                    count++;
                }
            }
            return count;
        }
    }
}
