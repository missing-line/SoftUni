using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Iron_Girder
{
    class Program
    {
        

        static void Main(string[] args)
        {
            string line = Console.ReadLine();
            

            while ( true)
            {
                string pattern = @"([^\:]+):(\d+)->(\d+)";
                Match matche = Regex.Match(line,pattern);
                if (matche.Success)
                {
                    string town = matche.Groups[1].Value.Trim();
                }
                line = Console.ReadLine();
            }
            Console.WriteLine(line);
        }
    }
}
