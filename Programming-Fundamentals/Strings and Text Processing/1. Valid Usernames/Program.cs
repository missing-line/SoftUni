using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _1._Valid_Usernames
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> line = Console.ReadLine().Split(", ").ToList();

            for (int i = 0; i < line.Count; i++)
            {
                bool validating = ValidUserNames(line[i]);
                if (!validating)
                {
                    line.RemoveAt(i);
                    i--;
                }
            }
            Console.WriteLine(string.Join("\n", line));
        }

        public static bool ValidUserNames(string line)
        {
            bool isValid = false;
            if (line.Length >= 3 && line.Length <= 16)
            {
                isValid = true;
            }
            else
            {
                return isValid;
            }
            for (int i = 0; i < line.Length; i++)
            {
                if (!char.IsDigit(line[i]) && !char.IsLetter(line[i]) && line[i] != '-' && line[i] != '_')
                {
                    isValid = false;
                    return isValid;
                }
            }
          
            return isValid;
        }
    }
}
