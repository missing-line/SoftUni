namespace OnlineRadioDatabase
{
    using System;
    using System.Linq;
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Radio radio = new Radio();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine()
                    .Split(";")
                    .ToArray();
                try
                {
                    Song song = new Song(input);
                    Console.WriteLine(radio.AddSong(song));
                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message);
                }
            }
            Console.WriteLine(radio);
        }
    }
}
