namespace BookShop.DataProcessor
{
    using System;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Serialization;

    using BookShop.DataProcessor.ExportDto;
    using Data;

    using Newtonsoft.Json;
    using Formatting = Newtonsoft.Json.Formatting;

    public class Serializer
    {
        public static string ExportMostCraziestAuthors(BookShopContext context)
        {

            var authors = context.Authors
                .Select(e => new ExportAuthorDto
                {
                    AuthorName = e.FirstName + " " + e.LastName,
                    Books = e.AuthorsBooks
                    .OrderByDescending(b => b.Book.Price)
                    .Select(b => new ExportABookDto
                    {
                        BookName = b.Book.Name,
                        BookPrice = $"{b.Book.Price:f2}",
                    }).ToList()
                })
                .ToArray()
                .OrderByDescending(c => c.Books.Count)
                .ThenBy(f => f.AuthorName);

            return JsonConvert.SerializeObject(authors, Formatting.Indented);
        }

        public static string ExportOldestBooks(BookShopContext context, DateTime date)
        {

            var books = context.Books
                 .Where(x => x.PublishedOn < date && (int)x.Genre == 3)
                 .Select(x => new ExportBookDto
                 {
                     Pages = x.Pages,
                     Name = x.Name,
                     Date = x.PublishedOn.ToString("d",CultureInfo.InvariantCulture)
                 })   
                 .OrderByDescending(x => x.Pages)
                 .ThenByDescending(x => x.Date)
                 .Take(10)
                 .ToArray();

            var sb = new StringBuilder();

            var xml = new XmlSerializer(typeof(ExportBookDto[]), new XmlRootAttribute("Books"));

            var namespaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });

            xml.Serialize(new StringWriter(sb), books, namespaces);

            return sb.ToString().TrimEnd();
        }
    }
}