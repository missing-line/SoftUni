namespace _3._Articles_2._0
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    public class Program
    {
        public class Article
        {
            public string Title { get; set; }
            public string Content { get; set; }
            public string Author { get; set; }
        }
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<Article> articles = new List<Article>();

            for (int i = 0; i < n; i++)
            {
                string[] line = Console.ReadLine().Split(", ");
                articles.Add(new Article()
                {
                    Title = line[0],
                    Content = line[1],
                    Author = line[2]
                });
            }
            string sordBy = Console.ReadLine().ToLower();
            
            if (sordBy == "title")
            {
                foreach (var article in articles.OrderBy(x => x.Title))
                {
                    Console.WriteLine($"{article.Title} - {article.Content}: {article.Author}");
                }
            }
            else if (sordBy == "content")
            {
                foreach (var article in articles.OrderBy(x => x.Content))
                {
                    Console.WriteLine($"{article.Title} - {article.Content}: {article.Author}");
                }
            }
            else if (sordBy == "author")
            {
                foreach (var article in articles.OrderBy(x => x.Author))
                {
                    Console.WriteLine($"{article.Title} - {article.Content}: {article.Author}");
                }
            }
        }
    }
}
