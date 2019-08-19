using System;
using System.Collections.Generic;
using System.Linq;

namespace Deciphering
{
    class Program
    {
        static void Main(string[] args)
        {
            List<char> symbols = new List<char>() { '{', '}', '|', '#' };

            string error = "This is not the book you are looking for.";

            string line = Console.ReadLine();

            string[] ch = Console.ReadLine()
                .Split()
                .ToArray();

            string find = ch[0];
            string replace = ch[1];

            char[] letter = line.Where(x => char.IsLetter(x)).ToArray(); // get only letters
            char[] symbol = line.Where(x => !char.IsLetter(x)).Distinct().ToArray(); // get everything diff from letter

            if (line.Any(x => char.IsUpper(x)) ||
                letter.Any(x => x < 'd') ||
                symbol.Any(x => !symbols.Contains(x))) // validation
            {
                Console.WriteLine(error);
                return;
            }

            string sentence = "";

            for (int i = 0; i < line.Length; i++)
            {
                int ascii = (int)line[i] - 3;
                sentence += (char)ascii;
            }

            sentence = sentence.Replace(find, replace);

            Console.WriteLine(sentence);
        }
    }
}
