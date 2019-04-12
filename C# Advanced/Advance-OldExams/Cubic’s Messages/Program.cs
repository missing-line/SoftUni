namespace Cubic_s_Messages
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    public class Program
    {
        public static void Main(string[] args)
        {
            List<KeyValuePair<string, char[]>> decrypt = new List<KeyValuePair<string, char[]>>();
            string input;

            while ((input = Console.ReadLine()) != "Over!")
            {
                int m = int.Parse(Console.ReadLine());

                string pattern = $@"\b\d+([a-zA-Z]{{{m}}})(.*)";

                Match match = Regex.Match(input, pattern);

                if (match.Success)
                {
                    if (match.Groups[2].Value.Any(x => char.IsLetter(x)))
                    {
                        continue;
                    }
                    string wordValue = match.Groups[1].Value;
                    char[] digits = match.Value.Where(x => char.IsDigit(x)).ToArray();
                    decrypt.Add(new KeyValuePair<string, char[]>(wordValue, digits));
                }
            }


            foreach (var word in decrypt)
            {
                string currMsg = "";

                for (int i = 0; i < word.Value.Length; i++)
                {
                    int index = int.Parse(word.Value[i].ToString());
                    if (index < word.Key.Length)
                    {
                        currMsg += word.Key[index];
                    }
                    else
                    {
                        currMsg += " ";
                    }
                }
                Console.WriteLine($"{word.Key} == {currMsg}");
            }
        }
    }
}
