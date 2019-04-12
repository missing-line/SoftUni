using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _01._Extract_Person_Information
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<string> result = new List<string>();
            for (int i = 0; i < n; i++)
            {
                string line = Console.ReadLine();                   
                string patternName = @"[\@][^\|]+\|";
                string patternAge = @"[\#][^\*]+\*";
                string name = "";
                string age = "";
                Match matchName = Regex.Match(line, patternName);
                Match matchAge = Regex.Match(line, patternAge);
                if (matchName.Success && matchAge.Success)
                {
                    name = matchName.Value.Trim("@|".ToCharArray());
                    age = matchAge.Value.Trim("#*".ToCharArray());
                    string curr = $"{name} is {age} years old.";
                    result.Add(curr);
                }
            }
            foreach (var name in result)
            {
                Console.WriteLine(name);
            }
        }
    }
}
