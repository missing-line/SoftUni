using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Hornet_Comm2
{
    class Program
    {
        static void Main(string[] args)
        {
            string line = Console.ReadLine();
            List<string> msg = new List<string>();
            List<string> board = new List<string>();
            while (line != "Hornet is Green")
            {
                string pattertnMSg = @"^(\d+) <-> (([a-zA-Z]*\d*)*)$";
                Match match1 = Regex.Match(line, pattertnMSg);
                if (match1.Success)
                {
                    string partDigits = ReverseString(match1.Groups[1].Value);
                    string partSec = match1.Groups[2].Value;
                    string newMsg = $"{partDigits} -> {partSec}";
                    msg.Add(newMsg);
                }
                string pattern2 = @"^([^\d]+) <-> (([a-zA-Z]*\d*)*)$";
                Match match2 = Regex.Match(line, pattern2);
                if (match2.Success)
                {
                    string partFirst = UpperLowerChnager(match2.Groups[2].Value);
                    string partSec = match2.Groups[1].Value;
                    string boardCast = $"{partFirst} -> {partSec}";
                    board.Add(boardCast);
                }
                line = Console.ReadLine();
            }
            Console.WriteLine("Broadcasts:");
            if (board.Count > 0)
            {
                foreach (var cast in board)
                {
                    Console.WriteLine(cast);
                }
            }
            else
            {
                Console.WriteLine("None");
            }
            Console.WriteLine("Messages:");
            if (msg.Count > 0)
            {
                foreach (var currMsg in msg)
                {
                    Console.WriteLine(currMsg);
                }
            }
            else
            {
                Console.WriteLine("None");
            }
        }
        public static string UpperLowerChnager(string s)
        {
            string newString = "";
            for (int i = 0; i < s.Length; i++)
            {
                if (char.IsLower(s[i]) && char.IsLetter(s[i]))
                {
                    newString += char.ToUpper(s[i]);
                }
                else if (char.IsUpper(s[i]) && char.IsLetter(s[i]))
                {
                    newString += char.ToLower(s[i]);
                }
                else
                {
                    newString += s[i];
                }
            }
            return newString;
        }
        public static string ReverseString(string s)
        {
            char[] arr = s.ToCharArray();
            Array.Reverse(arr);
            return new string(arr);
        }
    }
}
