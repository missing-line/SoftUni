using System;
using System.Collections.Generic;
using System.Linq;

namespace MeTube_Statistics
{
    class Program
    {
        static void Main(string[] args)
        {
            string token = Console.ReadLine();
            Dictionary<string, int> views = new Dictionary<string, int>();
            Dictionary<string, int> likes = new Dictionary<string, int>();

            while (token != "stats time")
            {
                if (token.Contains("-"))
                {
                    string[] artist = token.Split("-".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).ToArray();
                    if (views.ContainsKey(artist[0]))
                    {
                        views[artist[0]] += int.Parse(artist[1]);
                    }
                    else
                    {
                        views.Add(artist[0], int.Parse(artist[1]));
                        likes.Add(artist[0], 0);
                    }
                }
                else
                {
                    string[] likeOrDislike = token.Split(":".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).ToArray();
                    if (likeOrDislike[0] == "like")
                    {
                        if (likes.ContainsKey(likeOrDislike[1]))
                        {
                            likes[likeOrDislike[1]]++;
                        }
                    }
                    else
                    {
                        if (likes.ContainsKey(likeOrDislike[1]))
                        {
                            likes[likeOrDislike[1]]--;                           
                        }
                    }
                }
                token = Console.ReadLine();
            }

            string[] commandToOrder = Console.ReadLine().Split();
            if (commandToOrder[1] == "views")
            {
                foreach (var artist in views.OrderByDescending(x=>x.Value))
                {
                    foreach (var artistThumbs in likes)
                    {
                        if (artistThumbs.Key == artist.Key)
                        {
                            Console.WriteLine($"{artist.Key} - {artist.Value} views - {artistThumbs.Value} likes");
                        }
                    }
                }
            }
            else
            {
                foreach (var artistThumbs in likes.OrderByDescending(x=>x.Value))
                {
                    foreach (var artist in views)
                    {
                        if (artistThumbs.Key == artist.Key)
                        {
                            Console.WriteLine($"{artist.Key} - {artist.Value} views - {artistThumbs.Value} likes");
                        }
                    }
                }
            }
        }
    }
}
