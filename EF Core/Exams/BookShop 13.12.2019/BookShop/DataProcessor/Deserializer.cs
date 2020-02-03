namespace BookShop.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;

    using BookShop.Data.Models;
    using BookShop.Data.Models.Enums;
    using BookShop.DataProcessor.ImportDto;
    using Data;

    using Newtonsoft.Json;
    using ValidationContext = System.ComponentModel.DataAnnotations.ValidationContext;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedBook
            = "Successfully imported book {0} for {1:F2}.";

        private const string SuccessfullyImportedAuthor
            = "Successfully imported author - {0} with {1} books.";


        public static string ImportBooks(BookShopContext context, string xmlString)
        {
            var sb = new StringBuilder();

            var books = new List<Book>();

            var xml = new XmlSerializer(typeof(ImportBookDto[]), new XmlRootAttribute("Books"));

            var dtos = (ImportBookDto[])xml.Deserialize(new StringReader(xmlString));

            foreach (var dto in dtos)
            {

                if (!IsValid(dto) ||
                    (dto.Genre != 1 && dto.Genre != 2 && dto.Genre != 3))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var book = new Book()
                {
                    Name = dto.Name,
                    Genre = (Genre)dto.Genre,
                    Price = dto.Price,
                    Pages = dto.Pages,
                    PublishedOn = DateTime.ParseExact(dto.PublishedOn, "MM/dd/yyyy", CultureInfo.InvariantCulture)
                };

                books.Add(book);
                sb.AppendLine(string.Format
                    (
                        SuccessfullyImportedBook, book.Name, book.Price
                    ));
            }

            context.Books.AddRange(books);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportAuthors(BookShopContext context, string jsonString)
        {
            var sb = new StringBuilder();

            var authos = new List<Author>();

            var dtos = JsonConvert
                .DeserializeObject<ImportAuthorDto[]>(jsonString);


            foreach (var dto in dtos)
            {
                var author = authos
                    .Any(e => e.Email == dto.Email);

                if (!IsValid(dto) || author)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var validBooks = new List<Book>();
                foreach (var b in dto.Books)
                {
                    if (b.Id == null)
                    {
                        continue;
                    }

                    var book = context.Books.Find(b.Id);
                    if (book == null)
                    {
                        continue;
                    }

                    validBooks.Add(book);
                }

                if (validBooks.Count() == 0)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var a = new Author()
                {
                    FirstName = dto.FirstName,
                    LastName = dto.LastName,
                    Email = dto.Email,
                    Phone = dto.Phone,
                    AuthorsBooks = validBooks
                    .Select(e => new AuthorBook() { BookId = e.Id })
                    .ToArray()
                };

                authos.Add(a);

                sb.AppendLine
                    (
                        string.Format(SuccessfullyImportedAuthor, a.FirstName + " " + a.LastName, a.AuthorsBooks.Count)
                    );
            }

            context.Authors.AddRange(authos);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}