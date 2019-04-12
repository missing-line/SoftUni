using System;
using System.Linq;

namespace _3._Extract_File
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] line = Console.ReadLine().Split("\\").ToArray();

            for (int i = 0; i < line.Length; i++)
            {
                if (line[i].Contains('.'))
                {
                    string[] curr = line[i].Split(".".ToCharArray(),StringSplitOptions.RemoveEmptyEntries).ToArray();
                    string name = curr[0];
                    string extension = curr[1];
                    Console.WriteLine($"File name: {name}");
                    Console.WriteLine($"File extension: {extension}");
                    return;
                }
            }
        }
    }
}
