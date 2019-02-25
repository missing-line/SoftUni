using System;
using System.Collections.Generic;

namespace SoftUni_Party
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> regular = new HashSet<string>();
            HashSet<string> vip = new HashSet<string>();

            string input;

            while ((input = Console.ReadLine()) != "PARTY")
            {
                if (input.Length == 8)
                {
                    if (char.IsDigit(input[0]))
                    {
                        vip.Add(input);
                    }
                    else
                    {
                        regular.Add(input);
                    }
                }
            }

            while ((input = Console.ReadLine()) != "END")
            {
                vip.Remove(input);
                regular.Remove(input);
            }
            Console.WriteLine(vip.Count + regular.Count);
            if (vip.Count > 0)
            {
                Console.WriteLine(string.Join("\n", vip));
            }
            if (regular.Count > 0)
            {
                Console.WriteLine(string.Join("\n", regular));
            }
        }
    }
}
