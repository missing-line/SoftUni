using System;

namespace _6._Replace_Repeating_Chars
{
    class Program
    {
        static void Main(string[] args)
        {
            string line = Console.ReadLine();

            for (int i = 0; i < line.Length - 1; i++)
            {
                if (line[i] == line[i + 1])
                {
                    line = line.Remove(i + 1,1);
                    i--;
                }
            }
            Console.WriteLine(line);
        }
    }
}
