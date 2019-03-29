using System;

namespace _09._Palindrome_Integers
{
    class Program
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();
            while (command != "END")
            {
                Palindrome(command);
                command = Console.ReadLine();
            }

        }
        public static void Palindrome(string n)
        {
            bool isPalindrome = false;
            string curr = "";
            for (int i = n.Length - 1; i >= 0; i--)
            {
                curr += n[i];
            }
            if (curr == n)
            {
                isPalindrome = true;
            }
            if (isPalindrome)
            {
                Console.WriteLine("true");
            }
            else
            {
                Console.WriteLine("false");
            }
        }

    }
}
