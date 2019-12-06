namespace VaporStore.DataProcessor
{
    using System;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Serialization;
    using Data;
    using Newtonsoft.Json;
    using VaporStore.DataProcessor.Export;
    using Formatting = Newtonsoft.Json.Formatting;

    public static class Serializer
    {
        public static string ExportGamesByGenres(VaporStoreDbContext context, string[] genreNames)
        {
            var json = context.Genres
                .Where(x => genreNames.Contains(x.Name))
                .Select(x => new
                {
                    Id = x.Id,
                    Genre = x.Name,
                    Games = x.Games
                    .Where(g => g.Purchases.Count > 0)
                    .Select(g => new
                    {
                        Id = g.Id,
                        Title = g.Name,
                        Developer = g.Developer.Name,
                        Tags = string.Join(", ", g.GameTags.Select(t => t.Tag.Name)),
                        Players = g.Purchases.Count
                    })
                    .OrderByDescending(c => c.Players)
                    .ThenBy(id => id.Id)
                    .ToArray(),
                    TotalPlayers = x.Games.Sum(p => p.Purchases.Count)
                })
                .OrderByDescending(c => c.TotalPlayers)
                .ThenBy(id => id.Id)
                .ToList();

            return JsonConvert
                .SerializeObject(json, Formatting.Indented);
        }

        public static string ExportUserPurchasesByType(VaporStoreDbContext context, string storeType)
        {
            var users = context.Users
               .Select(x => new ExportUserPurchasesDTO
               {
                   UserName = x.Username,
                   Purchases = x.Cards.SelectMany(y => y.Purchases
                   .Where(type => type.Type.ToString() == storeType)
                   .Select(p => new PurchaseDTO
                   {
                       Card = p.Card.Number,
                       Cvc = p.Card.Cvc,
                       Date = p.Date.ToString("yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture),   // parse date
                       Game = new GameDTO
                       {
                           Title = p.Game.Name,
                           Genre = p.Game.Genre.Name,
                           Price = Math.Round(p.Game.Price, 2)
                       }
                   }))
                   .OrderBy(d => d.Date)
                   .ToArray(),
                   TotalSpent = x.Cards
                   .SelectMany(c => c.Purchases)
                   .Where(type => type.Type.ToString() == storeType)
                   .Sum(g => g.Game.Price)
               })
               .Where(p => p.Purchases.Any())
               .OrderByDescending(t => t.TotalSpent)
               .ThenBy(u => u.UserName)
               .ToArray();

            var sb = new StringBuilder();

            var xml = new XmlSerializer(typeof(ExportUserPurchasesDTO[]), new XmlRootAttribute("Users"));
            var namespaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });
            xml.Serialize(new StringWriter(sb), users, namespaces);

            return sb.ToString().TrimEnd();
        }
    }
}