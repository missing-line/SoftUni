namespace _2._Article
{
    using System;
    using System.Linq;
    public class Program
    {
        public class Article
        {
            public string Title { set; get; }
            public string Content { set; get; }
            public string Author { set; get; }
        }
        public static void Main(string[] args)
        {
            string[] line = Console.ReadLine().
                Split(", ");

            Article article = new Article()
            {
                Title = line[0].TrimStart().TrimEnd(),
                Content = line[1].TrimStart().TrimEnd(),
                Author = line[2].TrimStart().TrimEnd()
            };

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] command = Console.ReadLine()
                    .Split(":".ToCharArray(), StringSplitOptions.None)
                    .ToArray();

                string currReplace = command[1].Trim();

                if (command[0] == "Edit")
                {
                    article.Content = currReplace;
                }
                else if (command[0] == "ChangeAuthor")
                {
                    article.Author = currReplace;
                }
                else if (command[0] == "Rename")
                {
                    article.Title = currReplace;
                }
            }
            Console.WriteLine($"{article.Title} - {article.Content}: {article.Author}");
        }
    }
}
