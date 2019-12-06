namespace VaporStore.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using Data;
    using Newtonsoft.Json;
    using VaporStore.Data.Enums;
    using VaporStore.Data.Models;
    using VaporStore.DataProcessor.Import;

    public static class Deserializer
    {
        public static string ImportGames(VaporStoreDbContext context, string jsonString)
        {
            var sb = new StringBuilder();

            var developers = new List<Developer>();
            var genres = new List<Genre>();
            var tags = new List<Tag>();
            var games = new List<Game>();

            var dtos = JsonConvert
                .DeserializeObject<ImportGameDto[]>(jsonString);

            foreach (var dto in dtos)
            {
                if (!IsValid(dto) || !dto.Tags.All(IsValid))
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                var developer = developers.Find(x => x.Name == dto.Developer);
                if (developer == null)
                {
                    developer = new Developer { Name = dto.Developer };
                    developers.Add(developer);
                }

                var genre = genres.Find(x => x.Name == dto.Genre);
                if (genre == null)
                {
                    genre = new Genre { Name = dto.Genre };
                    genres.Add(genre);
                }

                var tagsForImport = new List<Tag>();
                foreach (var tag in dto.Tags)
                {
                    var tagInfo = tags.SingleOrDefault(x => x.Name == tag);
                    if (tagInfo == null)
                    {
                        tagInfo = new Tag { Name = tag };
                        tags.Add(tagInfo);
                    }
                    tagsForImport.Add(tagInfo);
                }

                var game = new Game
                {
                    Name = dto.Name,
                    Price = dto.Price,
                    ReleaseDate = DateTime.ParseExact(dto.ReleaseDate, "yyyy-MM-dd", CultureInfo.InvariantCulture),
                    Developer = developer,
                    Genre = genre,
                    GameTags = tagsForImport.Select(t => new GameTag { Tag = t }).ToArray()
                };

                games.Add(game);

                sb.AppendLine($"Added {game.Name} ({game.Genre.Name}) with {dto.Tags.Length} tags");
            }

            context.Games.AddRange(games);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportUsers(VaporStoreDbContext context, string jsonString)
        {
            var sb = new StringBuilder();

            var users = new List<User>();

            var dtos = JsonConvert
                .DeserializeObject<ImportUserDto[]>(jsonString);

            foreach (var dto in dtos)
            {
                if (!IsValid(dto) || !dto.Cards.All(IsValid))
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                var user = new User
                {
                    Username = dto.Username,
                    FullName = dto.FullName,
                    Email = dto.Email,
                    Age = dto.Age,
                    Cards = dto.Cards.Select(x => new Card
                    {
                        Number = x.Number,
                        Cvc = x.CVC,
                        Type = x.Type
                    })
                    .ToArray()
                };

                users.Add(user);
                sb.AppendLine($"Imported {user.Username} with {user.Cards.Count} cards");
            }

            context.Users.AddRange(users);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportPurchases(VaporStoreDbContext context, string xmlString)
        {
            var sb = new StringBuilder();

            var purchases = new List<Purchase>();

            var xml = new XmlSerializer(typeof(ImportPurchase[]), new XmlRootAttribute("Purchases"));

            var dots = (ImportPurchase[])xml
                .Deserialize(new StringReader(xmlString));

            foreach (var dto in dots)
            {
                var enumType = Enum.TryParse(dto.Type, out PurchaseType result);
                var cardInfo = context.Cards.SingleOrDefault(x => x.Number == dto.Card);
                var gameInfo = context.Games.SingleOrDefault(x => x.Name == dto.Title);

                if (!IsValid(dto) || !enumType || cardInfo == null || gameInfo == null)
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                var purchase = new Purchase
                {
                    Type = Enum.Parse<PurchaseType>(dto.Type),
                    ProductKey = dto.Key,
                    Date = DateTime.ParseExact(dto.Date, @"dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture),
                    Card = cardInfo,
                    Game = gameInfo
                };

                purchases.Add(purchase);
                sb.AppendLine($"Imported {dto.Title} for {purchase.Card.User.Username}");
            }

            context.Purchases.AddRange(purchases);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        private static bool IsValid(object obj)
        {
            var validationContext = new ValidationContext(obj);
            var validationResults = new List<ValidationResult>();

            return Validator.TryValidateObject(obj, validationContext, validationResults, true);
        }
    }
}