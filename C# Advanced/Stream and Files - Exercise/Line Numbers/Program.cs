namespace Line_Numbers
{
    using System;
    using System.IO;
    using System.Linq;

    public class Program
    {
        public static void Main(string[] args)
        {
            string symbols = "-.,!?'";

            using (var reader = new StreamReader("text.txt"))
            {
                using (var writer = new StreamWriter("Output.txt"))
                {
                    int count = 1;
                    while (true)
                    {
                        string line = reader.ReadLine();
                        if (line == null)
                        {
                            break;
                        }

                        char[] letter = line.Where(x => char.IsLetter(x)).ToArray();
                        char[] symbol = line.Where(x => symbols.Contains(x)).ToArray();

                        line = $"Line{count}: {line}({letter.Length})({symbol.Length})";
                        Console.WriteLine(line);
                        writer.WriteLine(line);
                        count++;
                    }
                }
            }
        }
    }
}
