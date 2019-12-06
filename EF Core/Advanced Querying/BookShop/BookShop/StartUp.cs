namespace BookShop
{
    using BookShop.Models.Enums;
    using Data;
    using Initializer;
    using System;
    using System.Text;
    using System.Linq;
    using Microsoft.EntityFrameworkCore;

    public class StartUp
    {
        public static void Main()
        {
            using (var db = new BookShopContext())
            {
                //DbInitializer.ResetDatabase(db);

                //string ageRestriction = Console.ReadLine();
                //Console.WriteLine(GetBooksByAgeRestriction(db, ageRestriction));
                //Console.WriteLine(GetGoldenBooks(db));
                //Console.WriteLine(GetBooksByPrice(db));
                //int year = int.Parse(Console.ReadLine());
                //Console.WriteLine(GetBooksNotReleasedIn(db, year));
                //string input = Console.ReadLine();
                //Console.WriteLine(GetBooksByCategory(db, input));
                //int lengthCheck = int.Parse(Console.ReadLine());
                //Console.WriteLine(GetMostRecentBooks(db));

                RemoveBooks(db);
            }
        }

        public static int RemoveBooks(BookShopContext context)
        {
            var books = context.Books
                .Where(b => b.Copies < 4200)
                .ToList();

            context.RemoveRange(books);
            context.SaveChanges();

            return books.Count();    
        }

        public static void IncreasePrices(BookShopContext context)
        {
            context.Books
                .Where(b => b.ReleaseDate.Value.Year < 2010)
               .ToList()
               .ForEach(x => x.Price += 5);

            context.SaveChanges();
        }

        public static string GetMostRecentBooks(BookShopContext context)
        {
            var sb = new StringBuilder();

            var collection = context.Categories
                .Select(x => new
                {
                    x.Name,
                    Book = x.CategoryBooks
                    .Select(b => b.Book)
                    .OrderByDescending(y => y.ReleaseDate)
                    .Take(3)
                })
                .OrderBy(n => n.Name)
                .ToList();

            foreach (var category in collection)
            {
                sb.AppendLine($"--{category.Name}");
                foreach (var book in category.Book)
                {
                    sb.AppendLine($"{book.Title} ({book.ReleaseDate.Value.Year})");
                }
            }
           
            return sb.ToString().TrimEnd();
        }

        public static string GetTotalProfitByCategory(BookShopContext context)
        {
            var sb = new StringBuilder();

            context.Categories
                .Include(b => b.CategoryBooks)
                .Select(x => new
                {
                    x.Name,
                    Total = x.CategoryBooks.Select(y => y.Book.Price * y.Book.Copies).Sum()
                })
                .OrderByDescending(t => t.Total).ThenBy(l => l.Name)
                .ToList()
                .ForEach(x => sb.AppendLine($"{x.Name} ${x.Total:f2}"));


            return sb.ToString().TrimEnd();
        }

        public static string CountCopiesByAuthor(BookShopContext context)
        {
            var sb = new StringBuilder();

            context.Authors
               .Select(x => new
               {
                   Copies = x.Books.Select(b => b.Copies).Sum(),
                   x.FirstName,
                   x.LastName
               })
               .OrderByDescending(x => x.Copies)
               .ToList()
               .ForEach(x => sb.AppendLine($"{x.FirstName} {x.LastName} - {x.Copies}"));

            return sb.ToString().TrimEnd();
        }

        public static int CountBooks(BookShopContext context, int lengthCheck)
        {

            int count = context.Books
                .Where(b => b.Title.Length > lengthCheck)
                .Count();

            return count;
        }

        public static string GetBooksByAuthor(BookShopContext context, string input)
        {
            var sb = new StringBuilder();

            context.Books
               .Where(b => b.Author.LastName.ToLower().StartsWith(input.ToLower()))
               .Select(x => new { x.BookId, x.Title, x.Author.FirstName, x.Author.LastName })
               .OrderBy(x => x.BookId)
               .ToList()
               .ForEach(x => sb.AppendLine($"{x.Title} ({x.FirstName} {x.LastName})"));


            return sb.ToString().TrimEnd();
        }

        public static string GetBookTitlesContaining(BookShopContext context, string input)
        {
            var sb = new StringBuilder();

            context.Books
               .Where(b => b.Title.ToLower().Contains(input.ToLower()))
               .Select(x => new { x.Title })
               .OrderBy(x => x.Title)
               .ToList()
               .ForEach(x => sb.AppendLine($"{x.Title}"));


            return sb.ToString().TrimEnd();
        }

        public static string GetAuthorNamesEndingIn(BookShopContext context, string input)
        {
            var sb = new StringBuilder();

            context.Books
                .Where(b => b.Author.FirstName.EndsWith(input))
                .Select(x => new { x.Author.FirstName, x.Author.LastName })
                .OrderBy(x => x.FirstName).ThenBy(x => x.LastName)
                .Distinct()
                .ToList()
                .ForEach(x => sb.AppendLine($"{x.FirstName} {x.LastName}"));


            return sb.ToString().TrimEnd();
        }

        public static string GetBooksReleasedBefore(BookShopContext context, string date)
        {
            var sb = new StringBuilder();

            DateTime parsedDate = DateTime.ParseExact(date, "dd-MM-yyyy", null);

            var getDate = parsedDate.Date;

            context.Books
                .Where(b => b.ReleaseDate.Value.Date < getDate)
                .Select(x => new { x.Title, x.EditionType, x.Price, x.ReleaseDate })
                .OrderByDescending(x => x.ReleaseDate)
                .ToList()
                .ForEach(x => sb.AppendLine($"{x.Title} - {x.EditionType} - ${x.Price:f2}"));

            return sb.ToString().TrimEnd();
        }

        public static string GetBooksByCategory(BookShopContext context, string input)
        {
            var sb = new StringBuilder();

            var categories = input
                .Split()
                .Select(c => c.ToLower());

            context.Books
               .Where(b => b.BookCategories.Any(bc => categories.Contains(bc.Category.Name.ToLower())))
               .Select(x => new { x.Title })
               .OrderBy(t => t.Title)
               .ToList()
               .ForEach(x => sb.AppendLine($"{x.Title}"));

            return sb.ToString().TrimEnd();
        }

        public static string GetBooksNotReleasedIn(BookShopContext context, int year)
        {
            var sb = new StringBuilder();

            context.Books
                .Where(b => b.ReleaseDate.Value.Year != year)
                .Select(x => new { x.BookId, x.Title })
                .OrderBy(x => x.BookId)
                .ToList()
                .ForEach(x => sb.AppendLine($"{x.Title}"));

            return sb.ToString().TrimEnd();
        }

        public static string GetBooksByPrice(BookShopContext context)
        {
            var sb = new StringBuilder();

            context.Books
                .Where(b => b.Price > 40)
                .Select(x => new { x.Title, x.Price })
                .OrderByDescending(x => x.Price)
                .ToList()
                .ForEach(x => sb.AppendLine($"{x.Title} - ${x.Price:f2}"));

            return sb.ToString().TrimEnd();
        }

        public static string GetGoldenBooks(BookShopContext context)
        {
            //string titles of the golden edition books that have less than 5000 copies

            var sb = new StringBuilder();

            context.Books
                .Where(b => b.Copies < 5000 && b.EditionType == EditionType.Gold)
                .Select(b => new { b.BookId, b.Title })
                .OrderBy(i => i.BookId)
                .ToList()
                .ForEach(b => sb.AppendLine($"{b.Title}"));


            return sb.ToString().TrimEnd();
        }

        public static string GetBooksByAgeRestriction(BookShopContext context, string command)
        {
            var sb = new StringBuilder();

            //(AgeRestriction)Enum.Parse(typeof(AgeRestriction), command, true); //
            var ageRestriction = Enum.Parse<AgeRestriction>(command, true);


            context.Books
                .Where(b => b.AgeRestriction == ageRestriction)
                .Select(b => new { b.Title })
                .OrderBy(x => x.Title)
                .ToList()
                .ForEach(x => sb.AppendLine($"{x.Title}"));


            return sb.ToString().TrimEnd();
        }
    }
}
