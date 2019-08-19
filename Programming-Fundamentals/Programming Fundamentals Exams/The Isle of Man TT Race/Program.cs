using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace The_Isle_of_Man_TT_Race
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"^([&#*%$]([a-zA-Z]+)[&#%*$])=([0-9]+)!!(.*)$";

            string input;

            while ((input = Console.ReadLine()) != "Last note")
            {
                string name = string.Empty;
                int geodash = 0;
                string code = string.Empty;

                Match match = Regex.Match(input, pattern);

                if (match.Success)
                {
                    name = match.Groups[1].Value;
                    geodash = int.Parse(match.Groups[3].Value);
                    code = match.Groups[4].Value;

                    if (IsValidLength(geodash, code) && name[0] == name[name.Length - 1])
                    {
                        name = name.Trim(name[0]);
                        string nameOfRacer = ReturnName(name);
                        Console.WriteLine($"Coordinates found! {nameOfRacer} -> {Decrypt(geodash,code)}");
                        return;
                    }
                }
                Console.WriteLine("Nothing found!");
            }
        }

        private static string Decrypt(int geodash, string code)
        {
            string decrypt = "";

            for (int i = 0; i < code.Length; i++)
            {
                decrypt += (char)((int)code[i] + geodash);
            }
            return decrypt;
        }

        private static bool IsValidLength(int geodash, string code)
        {
            return geodash == code.Length;
        }

        private static string ReturnName(string text)
        {
            var separated = new string(text.Where(char.IsLetter).ToArray());

            return separated;
        }
    }
}
