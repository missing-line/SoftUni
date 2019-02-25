namespace Slice_File
{
    using System;
    using System.IO;

    public class Program
    {
        public static void Main(string[] args)
        {
            int parts = int.Parse(Console.ReadLine());

            using (var reader = new FileStream(@"05. Slice File/sliceMe.txt", FileMode.Open))
            {
                var pieceSize = Math.Ceiling((double)reader.Length / parts);


                for (int i = 1; i <= parts; i++)
                {
                    string curr = $"slice{i}.txt";

                    var currTotalBytes = 0;
                    using (var writer = new FileStream($@"05. Slice File/{curr}", FileMode.Create))
                    {

                        while (true)
                        {
                            var buffer = new byte[4096];
                          


                            var totalReader = reader.Read(buffer, 0, buffer.Length);
                            if (totalReader == 0)
                            {
                                break;
                            }
                            currTotalBytes += totalReader;
                            writer.Write(buffer, 0, totalReader);

                            if (currTotalBytes >= pieceSize)
                            {
                                break;
                            }
                        }
                    }
                }
            };
        }
    }
}
