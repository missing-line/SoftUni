using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace HTML_parser
{
    class Program
    {
        static void Main(string[] args)
        {   
            string token = Console.ReadLine();
            string title = "";
            List<string> content = new List<string>();
            string patternTitle = @"(?<=<title>)([a-zA-Z\s]+)";
            string patternContent = @"(?<=\\n|>)[a-zA-Z\s\,\.\?\!]+";
            Match matchTitle = Regex.Match(token, patternTitle);
            if (matchTitle.Success)
            {
                title = matchTitle.Value;
            }
            int index = matchTitle.Index;
            token = token.Remove(index - 1,1);
            MatchCollection matchContent = Regex.Matches(token,patternContent);
            foreach (Match word in matchContent)
            {
                content.Add(word.ToString());
            }
            Console.WriteLine($"Title: {title}");
            Console.WriteLine($"Content: {string.Join(" ",content)}");
        }
    }
}
