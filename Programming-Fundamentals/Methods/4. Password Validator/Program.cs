using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _4._Password_Validator
{
    class Program
    {
        static void Main(string[] args)
        {
            string password = Console.ReadLine();
            List<string> info = ValidationaPasswood(password);
            foreach (var msg in info)
            {
                Console.WriteLine(msg);
            }
        }
        public static List<string> ValidationaPasswood(string password)
        {
            List<string> info = new List<string>();
            bool isValid = true;
            string pattern = @"^(([a-zA-Z]+)*(\d+)*)*$";
            string pattern1 = @"\d{2,}";
            Match m = Regex.Match(password,pattern);
            if (password.Length < 6 || password.Length > 10)
            {
                isValid = false;
                info.Add("Password must be between 6 and 10 characters");
            }
            if (!m.Success)
            {
                isValid = false;
                info.Add("Password must consist only of letters and digits");
            }          
            if (!Regex.IsMatch(password,pattern1))
            {
                isValid = false;
                info.Add("Password must have at least 2 digits");
            }
            if (isValid == true)
            {
                info.Add("Password is valid");
            }
            return info;
        }
    }
}
