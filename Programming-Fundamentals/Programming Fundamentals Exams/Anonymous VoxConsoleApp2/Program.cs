using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Anonymous_VoxConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            //([a-zA-Z]+)(.+)(\1)|(.)*?
            string line = Console.ReadLine();
            string[] placeholder = Console.ReadLine()
                .Split("{}".ToCharArray(),StringSplitOptions.RemoveEmptyEntries)
                .ToArray();           
            string curr = "";
            int count = 0;
            string pattern = @"([a-zA-Z]+)(.+)(\1)";
            MatchCollection match = Regex.Matches(line,pattern);
            foreach (Match lines in match)
            {
                count++;                
                string start = lines.Groups[1].Value;
                string end = lines.Groups[3].Value;
                string notMatch = lines.Groups[2].Value;
                int index = line.IndexOf(start);
                line = line.Remove(index,start.Length + end.Length + notMatch.Length);              
                if (count <= line.Length )
                {
                    curr = start + placeholder[count - 1] + end;
                    line = line.Insert(index,curr);
                }
                else
                {
                    line += start + placeholder[placeholder.Length - 1] + end;
                    line = line.Insert(index, curr);
                }
            }
            Console.WriteLine(line);
        }
    }
}
