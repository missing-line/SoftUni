using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _1._Data_Type_Finder
{
    class Program
    {
        static void Main(string[] args)
        {
            string line = Console.ReadLine();

            while (line != "END")
            {
                bool isBoolean = bool.TryParse(line,out bool boolean);
                bool isIntiger = int.TryParse(line,out int integer);
                bool isDouble = double.TryParse(line,out double floatingPoint);
                bool isChar = char.TryParse(line,out char character);
                if (isBoolean)
                {
                    
                    Console.WriteLine($"{line} is boolean type");
                }
                else if (isIntiger)
                {
                    Console.WriteLine($"{line} is integer type");
                }
                else if (isDouble)
                {
                    Console.WriteLine($"{line} is floating point type");
                }
                else if (isChar)
                {
                    Console.WriteLine($"{line} is character type");
                }
                else
                {
                    Console.WriteLine($"{line} is string type");
                }
                line = Console.ReadLine();
            }
        }
    }
}
