using System;
using System.Linq;

namespace _04._Morse_Code_Translator
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] line = Console.ReadLine().Split("|".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            string[] aakkoset = { ".", "A", "B", "C", "D", "E",
                                 "F", "G", "H", "I", "J",
                                 "K", "L", "M", "N", "O",
                                 "P", "Q", "R", "S", "T",
                                 "U", "V","W", "X", "Y",
                                 "Z", "Ä", "Ö", "0", "1",
                                 "2", "3", "4", "5", "6",
                                 "7", "8", "9", "?", ":",
                                 ",", "@", "/", "=", " ",
            };

            string[] morse = {".-.-.-", ".-", "-...", "-.-.", "-..", ".",
                              "..-.", "--.", "....", "..", ".---",
                              "-.-", ".-..", "--", "-.", "---",
                              ".--.", "--.-", ".-.", "...", "-",
                              "..-", "...-", ".--", "-..-", "-.--",
                              "--..", ".-.-", "---.", "-----", ".----",
                              "..---", "...--", "....-", ".....", "-....",
                              "--...", "---..","----.", "..--..", "---...",
                              "-....-", ".--.-.", "-..-.", "-...-", " ",
            };
            for (int i = 0; i < line.Length; i++)
            {
                string[] currCode = line[i].Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).ToArray();

                for (int j = 0; j < currCode.Length; j++)
                {
                    int index = Array.IndexOf(morse, currCode[j].Trim());
                    currCode[j] = aakkoset[index];
                }
                line[i] = string.Join("", currCode);

            }
            Console.WriteLine(string.Join(" ", line));
        }
    }
}

