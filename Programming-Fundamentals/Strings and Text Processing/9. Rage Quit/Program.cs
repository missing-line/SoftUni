using System;
using System.Text;
using System.Linq;

namespace _9._Rage_Quit
{
    class Program
    {
        static void Main(string[] args)
        { 
            string line = Console.ReadLine();
            StringBuilder repeate = new StringBuilder();

            for (int i = 0; i < line.Length; i++)
            {
                if (char.IsDigit(line[i]))
                {
                    string currN = line[i].ToString();
                    if (i + 1 < line.Length && char.IsDigit(line[i + 1]))
                    {
                        currN += line[i + 1];
                    }
                    int index = int.Parse(currN);
                    int removeIndex = line.IndexOf(line[i]);
                    string repeateWord = line.Substring(0, removeIndex);
                    for (int j = 0; j < index; j++)
                    {
                        repeate.Append(repeateWord);
                    }
                    line = line.Remove(0, repeateWord.Length + currN.Length);
                    i = -1;                   
                }
            }
            char[] removeDuplicate = repeate.ToString().ToUpper().Distinct().ToArray();
            Console.WriteLine($"Unique symbols used: {removeDuplicate.Length}");
            Console.WriteLine(repeate.ToString().ToUpper());
        }       
    }
}
