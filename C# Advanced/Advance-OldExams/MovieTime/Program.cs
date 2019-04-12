namespace MovieTime
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main(string[] args)
        {
            string genre = Console.ReadLine();

            string sortCommand = Console.ReadLine();

            Dictionary<string, TimeSpan> movies = new Dictionary<string, TimeSpan>();

            List<string> getTime = new List<string>();

            string input;

            while ((input = Console.ReadLine()) != "POPCORN!")
            {

                string[] arr = input.Split('|').ToArray();

                string nameMovie = arr[0];
                string genreMovie = arr[1];
                string time = arr[2];
                getTime.Add(arr[2]);
                if (genreMovie == genre)
                {
                    movies.Add(nameMovie, TimeSpan.Parse(time));
                }                
            }

            string preferences;

            if (sortCommand == "Short")
            {
                foreach (var movie in movies.OrderBy(x => x.Value))
                {
                    Console.WriteLine(movie.Key);
                    preferences = Console.ReadLine();
                    if (preferences == "Yes")
                    {
                        Console.WriteLine($"We're watching {movie.Key} - {movie.Value}");
                        break;
                    }
                }
            }
            else
            {
                foreach (var movie in movies.OrderByDescending(x => x.Value))
                {
                    Console.WriteLine(movie.Key);
                    preferences = Console.ReadLine();
                    if (preferences == "Yes")
                    {
                        Console.WriteLine($"We're watching {movie.Key} - {movie.Value}");
                        break;
                    }
                }
            }
            Console.WriteLine(TotaTimeMovies(getTime));
        }

        private static string TotaTimeMovies(List<string> movies)
        {
            TimeSpan total = TimeSpan.Parse("00:00:00");
            foreach (var movie in movies)
            {
                TimeSpan span = TimeSpan.Parse(movie);
                TimeSpan sumary = total.Add(span);
                total = sumary;
            }
            return $"Total Playlist Duration: {total}";
        }
    }
}
