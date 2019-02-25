namespace _2._Article
{
    using System;
    using System.Linq;
    public class Program
    {
        public class Article
        {
            public Article(string title, string conten, string author)
            {
                Title = title;
                Content = conten;
                Author = author;
            }

            public string Title { set; get; }
            public string Content { set; get; }
            public string Author { set; get; }

            public void Edit(string newContent)
            {
                Content = newContent;
            }
            public void ChangeAuthor(string newAuthor)
            {
                Author = newAuthor;
            }
            public void Rename(string newTitle)
            {
                Title = newTitle;
            }

            public override string ToString()
            {
                return $"{Title} - {Content}: {Author}";
            }
        }
        static void Main(string[] args)
        {
            string[] line = Console.ReadLine().
                Split(", ");

            Article article = new Article
                (
                    line[0].TrimEnd(), line[1].TrimStart(), line[2].TrimStart()
                );

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] command = Console.ReadLine()
                    .Split(": ");


                if (command[0] == "Edit")
                {
                    string newContent = command[1];
                    article.Edit(newContent);
                }
                else if (command[0] == "ChangeAuthor")
                {
                    string newAuthor = command[1];
                    article.ChangeAuthor(newAuthor);
                }
                else if (command[0] == "Rename")
                {
                    string newTitle = command[1];
                    article.Rename(newTitle);
                }
            }
            Console.WriteLine(article);
        }
    }
}
