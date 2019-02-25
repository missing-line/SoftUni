namespace Even_Lines
{
    using System;
    using System.IO;
    using System.Linq;

    public class Program
    {
        public static void Main(string[] args)
        {
            string symbol = "-.,!?";
            int count = 0;
            using (var reader = new StreamReader(@"text.txt"))
            {

                using (var writer = new StreamWriter("Output.txt"))
                {
                    while (true)
                    {
                        var line = reader.ReadLine();
                        if (line == null)
                        {
                            break;
                        }


                        if (count % 2 == 0)
                        {
                            string changed = string.Empty;

                            foreach (var index in line)
                            {
                                if (symbol.Contains(index))
                                {
                                    changed += '@';
                                }
                                else
                                {
                                    changed += index;
                                }
                            }

                            string[] splitted = changed.Split().ToArray();
                            Array.Reverse(splitted);

                            writer.WriteLine(string.Join(" ",splitted));
                        }
                        count++;
                    }
                }
            }

            using (var reader =  new StreamReader("Output.txt"))
            {
                while (true)
                {
                    string line = reader.ReadLine();

                    if (line == null)
                    {
                        return;
                    }

                    Console.WriteLine(line);
                }
            }
        }
    }
}
