using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Jedi_Code_X
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] nums = Console.ReadLine()
                .Split(", ")                
                .ToArray();

            List<string> list = new List<string>();
            List<string> results = new List<string>();

            for (int i = 0; i < nums.Length; i++)
            {
                string current = nums[i];
                string curr = "";
                for (int j = 0; j < current.Length; j++)
                {
                    string ch = current[j].ToString();
                    curr += ReturnNum(ch.ToString());
                }
                list.Add(curr);
            }
            list.Sort();
            string pattern1 = @"one";
            string pattern2 = @"two";
            string pattern3 = @"three";
            string pattern4 = @"four";
            string pattern5 = @"five";
            string pattern6 = @"six";
            string pattern7 = @"seven";
            string pattern8 = @"eight";
            string pattern9 = @"nine";
            string pattern0 = @"zero";

            foreach (var word in list)
            {
                string currMatch = "";
                MatchCollection match1 = Regex.Matches(word,pattern1);
                foreach (Match value in match1)
                {
                    string matched = value.Value;
                     currMatch += ReturnDigit(matched);
                }
                MatchCollection match2 = Regex.Matches(word,pattern2);
                foreach (Match value in match2)
                {
                    string matched = value.Value;
                     currMatch += ReturnDigit(matched);
                }
                MatchCollection match3 = Regex.Matches(word,pattern3);
                foreach (Match value in match3)
                {
                    string matched = value.Value;
                     currMatch += ReturnDigit(matched);
                }
                MatchCollection match4 = Regex.Matches(word, pattern4);
                foreach (Match value in match4)
                {
                    string matched = value.Value;
                    currMatch += ReturnDigit(matched);
                }
                MatchCollection match5 = Regex.Matches(word, pattern5);
                foreach (Match value in match5)
                {
                    string matched = value.Value;
                    currMatch += ReturnDigit(matched);
                }
                MatchCollection match6 = Regex.Matches(word, pattern6);
                foreach (Match value in match6)
                {
                    string matched = value.Value;
                    currMatch += ReturnDigit(matched);
                }
                MatchCollection match7 = Regex.Matches(word, pattern7);
                foreach (Match value in match7)
                {
                    string matched = value.Value;
                    currMatch += ReturnDigit(matched);
                }
                MatchCollection match8 = Regex.Matches(word, pattern8);
                foreach (Match value in match8)
                {
                    string matched = value.Value;
                    currMatch += ReturnDigit(matched);
                }
                MatchCollection match9 = Regex.Matches(word, pattern9);
                foreach (Match value in match9)
                {
                    string matched = value.Value;
                    currMatch += ReturnDigit(matched);
                }
                MatchCollection match0 = Regex.Matches(word, pattern0);
                foreach (Match value in match0)
                {
                    string matched = value.Value;
                    currMatch += ReturnDigit(matched);
                }
                results.Add(currMatch);
            }
            Console.WriteLine(string.Join(", ",results));
        }   

        private static string ReturnDigit(string ch)
        {
            if (ch == "one")
            {
                return "1";
            }
            else if (ch == "two")
            {
                return "2";
            }
            else if (ch == "three")
            {
                return "3";
            }
            else if (ch == "four")
            {
                return "4";
            }
            else if (ch == "five")
            {
                return "5";
            }
            else if (ch == "six")
            {
                return "6";
            }
            else if (ch == "seven")
            {
                return "7";
            }
            else if (ch == "eight")
            {
                return "8";
            }
            else if (ch == "nine")
            {
                return "9";
            }
            else if (ch == "zero")
            {
                return "0";
            }

            return "";
        }

        public static string ReturnNum(string current)
        {
            if (current == "0")
            {
                return "zero";
            }
            else if (current == "1")
            {
                return "one";
            }
            else if (current == "2")
            {
                return "two";
            }
            else if (current == "3")
            {
                return "three";
            }
            else if (current == "4")
            {
                return "four";
            }
            else if (current == "5")
            {
                return "five";
            }
            else if (current == "6")
            {
                return "six";
            }
            else if (current == "7")
            {
                return "seven";
            }
            else if (current == "8")
            {
                return "eight";
            }
            else if (current == "9")
            {
                return "nine";
            }
            return "";
        }
    }
}
