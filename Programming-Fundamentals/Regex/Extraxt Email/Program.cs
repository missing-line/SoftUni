using System;
using System.Text.RegularExpressions;

namespace Extraxt_Email
{
    class Program
    {
        static void Main(string[] args)
        {
            string emailsInput = Console.ReadLine();
            
            string pattern = @"\b(?<=\s)[a-zA-Z0-9]+([-|.]\w*)*@([a-zA-Z]+[-|.])*[a-zA-Z]+\.[a-zA-Z]{2,}\b";
            MatchCollection emails = Regex.Matches(emailsInput, pattern);       
            foreach (Match email in emails)
            {
                Console.WriteLine(email.Value);
            }
        }
    }
}
