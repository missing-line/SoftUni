namespace Line_Numbers
{
    using System;
    using System.IO;

    public class Program
    {
        public static void Main(string[] args)
        {
            using (var reader = new StreamReader(@"02. Line Numbers\Input.txt"))
            {
                using (var writer = new StreamWriter(@"Output.txt"))
                {
                    int count = 1;
                    while (true)
                    {
                        string line = reader.ReadLine();

                        if (line == null)
                        {
                            break;
                        }

                        line = $"{count}. {line}";
                        count++;

                        writer.WriteLine(line);

                        Console.WriteLine(line);
                    }
                }
            }
        }
    }
}
