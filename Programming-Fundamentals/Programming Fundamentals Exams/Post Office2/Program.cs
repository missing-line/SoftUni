using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace Post_Office2
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split("|".ToCharArray(),StringSplitOptions.RemoveEmptyEntries).ToArray();
            string pattern1 = @"\$([A-Z]+)\$";
            string pattern2 = @"\#([A-Z]+)\#";
            string pattern3 = @"\%([A-Z]+)\%";
            string pattern4 = @"\*([A-Z]+)\*";
            string pattern5 = @"\&([A-Z]+)\&";
            string firstPart = string.Empty;
            string[] words = input[2].Split(' ').ToArray();
            while (true)
            {
                Match match1 = Regex.Match(input[0], pattern1);
                Match match2 = Regex.Match(input[0], pattern2);
                Match match3 = Regex.Match(input[0], pattern3);
                Match match4 = Regex.Match(input[0], pattern4);
                Match match5 = Regex.Match(input[0], pattern5);
                if (match1.Success)
                {
                    firstPart = match1.Groups[1].Value;
                    break;
                }
                if (match2.Success)
                {
                    firstPart = match2.Groups[1].Value;
                    break;
                }
                if (match3.Success)
                {
                    firstPart = match3.Groups[1].Value;
                    break;
                }
                if (match4.Success)
                {
                    firstPart = match4.Groups[1].Value;
                    break;
                }
                if (match5.Success)
                {
                    firstPart = match5.Groups[1].Value;
                    break;
                }
            }
            for (int i = 0; i < firstPart.Length; i++)
            {
                int currASCII = (int)firstPart[i];
                string patterntLenght = $@"{currASCII}\:(\d{{2}})";
                Match match = Regex.Match(input[1], patterntLenght);
                if (match.Success)
                {
                    string currDigits = match.Groups[1].Value;
                    int size = 0;
                    if (currDigits[0] == '0')
                    {
                        
                        size = int.Parse(currDigits[currDigits.Length - 1].ToString());
                    }
                    else
                    {
                        size = int.Parse(currDigits);
                    }
                    string patternWord = $@"^{firstPart[i]}\S{{{size}}}$";
                    
                    foreach (var word in words)
                    {
                        Match matchWord = Regex.Match(word, patternWord);
                        if (matchWord.Success)
                        {
                            Console.WriteLine(matchWord.ToString());
                            break;
                        }
                    }
                }
            }
        }
    }
}
