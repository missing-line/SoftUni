using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Memory_View2
{
    class Program
    {
        static void Main(string[] args)
        {       //32656 19759 32763
            Console.SetIn(new StreamReader(Console.OpenStandardInput(8192)));
            string[] line = Console.ReadLine().Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            string memory = "";
            List<string> resultOfNames = new List<string>();
            while (string.Join(" ", line) != "Visual Studio crash")
            {
                memory += string.Join(" ",line) + " ";               
                line = Console.ReadLine().Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            }
            List<string> newLine = memory.Split().ToList();
            int index = newLine.IndexOf("32763");
            while (index != -1)
            {
                int take = int.Parse(newLine[index + 2]);
                string[] curr = newLine.Skip(index + 4).Take(take).ToArray();
                resultOfNames.Add(DecryptName(curr));
                newLine.RemoveRange(index - 2,3);
                index = newLine.IndexOf("32763");

            }
            foreach (var name in resultOfNames)
            {
                Console.WriteLine(name);
            }
        }
        public static string DecryptName(string[] curr)
        {
            string name = string.Empty;
            for (int i = 0; i < curr.Length; i++)
            {
                char letter = (char)int.Parse(curr[i].ToString());
                name += letter;
            }
            return name;
        }
    }
}
