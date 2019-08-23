using System;
using System.Linq;

namespace Username
{
    class Program
    {
        private static string word;
        static void Main(string[] args)
        {
            word = Console.ReadLine();

            string input;

            while ((input = Console.ReadLine()) != "Sign up")
            {
                string[] tokens = input
                    .Split()
                    .ToArray();

                string command = tokens[0];
                string output = null;
                switch (command)
                {
                    case "Case":
                        output = Case(tokens[1]);
                        break;
                    case "Reverse":
                        int startIndex = int.Parse(tokens[1]);
                        int endIndex = int.Parse(tokens[2]);

                        if (!(startIndex >= 0 &&
                            endIndex > startIndex &&
                            endIndex < word.Length))
                        {
                            continue;
                        }

                        output = Reverse(startIndex, endIndex);
                        break;
                    case "Cut":
                        output = Cut(tokens[1]);
                        break;
                    case "Replace":
                        output = Replace(tokens[1]);
                        break;
                    case "Check":
                        output = Check(tokens[1]);
                        break;
                    default:
                        break;
                }
                Console.WriteLine(output);
            }
        }

        private static string Check(string ch)
        {
            if (word.Contains(ch))
            {
                return "Valid";
            }
            return $"Your username must contain {ch}.";
        }

        private static string Replace(string ch)
        {
            return word = word.Replace(ch, "*");
        }

        private static string Cut(string subString)
        {
            if (word.Contains(subString))
            {
                word = word.Replace(subString, null);
                return word;
            }
            return $"The word {word} doesn't contain {subString}.";
        }

        private static string Reverse(int startIndex, int endIndex)
        {
            string getSubString = word.Substring(startIndex, (endIndex - startIndex) + 1);
            return string.Join("", getSubString.Reverse());
        }
       
        private static string Case(string typeCase)
        {
            if (typeCase == "lower")
            {
                word = word.ToLower();
            }
            else
            {
                word = word.ToUpper();
            }

            return word;
        }
    }
}
