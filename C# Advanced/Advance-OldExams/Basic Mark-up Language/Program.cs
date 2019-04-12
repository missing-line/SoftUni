namespace Basic_Mark_up_Language
{
    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;

    public class Program
    {
        public static void Main(string[] args)
        {   
            List<string> results = new List<string>();
            int counter = 0;

            string pattern1 = @"^\s*<\s*(\w+)\s+content\s*=\s*""(.*)""\s*\/>$";
            string pattern2 = @"^\s*<\s*\w+\s+\w+\s*=\s*""(\d+)""\s+\w+\s*=\s*""(.*)""\s*\/>$";
            string input;

            while ((input = Console.ReadLine()) != "<stop/>")
            {
                Match match = Regex.Match(input, pattern1);
                Match match2 = Regex.Match(input, pattern2);
                if (match2.Success)
                {
                    int value = int.Parse(match2.Groups[1].Value);
                    string word = match2.Groups[2].Value;
                    if (!string.IsNullOrEmpty(word))
                    {
                        for (int i = 0; i < value; i++)
                        {
                            string rs = $"{++counter}. {word}";
                            results.Add(rs);
                        }
                    }
                }
                if (match.Success)
                {
                    string command = match.Groups[1].Value;

                    if (command.Contains("inverse"))
                    {
                        string word = match.Groups[2].Value;
                        if (!string.IsNullOrEmpty(word))
                        {
                            string rs = SwapCaseSensitive(match.Groups[2].Value);
                            results.Add($"{++counter}. {rs}");
                        }
                    }
                    else if (command.Contains("reverse"))
                    {
                        string word = match.Groups[2].Value;
                        if (!string.IsNullOrEmpty(word))
                        {
                            char[] ch = match.Groups[2].Value.ToCharArray();
                            string rs = Reverse(ch);
                            results.Add($"{++counter}. {rs}");
                        }
                    }
                }
            }

            foreach (var word in results)
            {
                Console.WriteLine($"{word}");
            }
        }

        private static string Reverse(char[] ch)
        {
            string result = "";

            for (int i = ch.Length - 1; i >= 0; i--)
            {
                result += ch[i];
            }

            return result;
        }

        private static string SwapCaseSensitive(string word)
        {

            string result = string.Empty;

            for (int i = 0; i < word.Length; i++)
            {
                if (char.IsLower(word[i]))
                {
                    result += Char.ToUpper(word[i]);
                }
                else
                {
                    result += Char.ToLower(word[i]);
                }
            }
            return result;
        }
    }
}
