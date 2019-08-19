using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace Arriving_in_Kathmandu
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"^([!?$#@a-zA-Z0-9]+)=([0-9]+)<<(.*)$";

            string input;

            while ((input = Console.ReadLine()) != "Last note")
            {
                string nameOfPeak = string.Empty;
                int geodash = 0;
                string code = string.Empty;

                Match match = Regex.Match(input, pattern);

                if (match.Success)
                {
                    nameOfPeak = match.Groups[1].Value;
                    geodash = int.Parse(match.Groups[2].Value);
                    code = match.Groups[3].Value;

                    if (IsValidLength(geodash, code))
                    {
                        string nameOfMountain = ReturnAllLetterAndNumbers(nameOfPeak);
                        Console.WriteLine($"Coordinates found! {nameOfMountain} -> {code}");
                        continue;
                    }
                    
                }
                Console.WriteLine("Nothing found!");
            }
        }

        private static bool IsValidLength(int geodash, string code)
        {
            return geodash == code.Length;
        }

        private static string ReturnAllLetterAndNumbers(string text)
        {
            var separated =  new string(text.Where(char.IsLetterOrDigit).ToArray());

            return separated;
        }
    }
}
