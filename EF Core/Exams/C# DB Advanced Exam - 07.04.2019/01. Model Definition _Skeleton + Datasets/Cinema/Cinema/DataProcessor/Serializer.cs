namespace Cinema.DataProcessor
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Serialization;

    using Cinema.DataProcessor.ExportDTO;
    using Cinema.Data;
    using Newtonsoft.Json;
    using Formatting = Newtonsoft.Json.Formatting;

    public class Serializer
    {
        public static string ExportTopMovies(CinemaContext context, int rating)
        {
            var movies = context.Movies
                .OrderByDescending(r => r.Rating)
                .ThenByDescending(t => t.Projections.Sum(s => s.Tickets.Sum(i => i.Price)))
                .Where(x => x.Rating >= rating && x.Projections.Any(p => p.Tickets.Count > 0))
                .Select(x => new
                {
                    MovieName = x.Title,
                    Rating = $"{x.Rating:f2}",
                    TotalIncomes = $"{(x.Projections.Sum(t => t.Tickets.Sum(s => s.Price))):f2}",
                    Customers = x.Projections
                    .SelectMany(p => p.Tickets)
                    .Select(t => new
                    {
                        FirstName = t.Customer.FirstName,
                        LastName = t.Customer.LastName,
                        Balance = $"{(t.Customer.Balance):f2}"
                    })
                    .OrderByDescending(b => b.Balance)
                    .ThenBy(f => f.FirstName)
                    .ThenBy(l => l.LastName)
                    .ToArray()
                })
                .Take(10)
                .ToList();

            return JsonConvert.SerializeObject(movies, Formatting.Indented);
        }

        public static string ExportTopCustomers(CinemaContext context, int age)
        {
            var customers = context.Customers
                .Where(x => x.Age >= age)
                .OrderByDescending(x => x.Tickets.Sum(t => t.Price))
                .Select(x => new ExportCusotmerDTO
                {
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    SpentMoney = x.Tickets.Sum(t => t.Price).ToString("F2"),
                    SpentTime = TimeSpan
                    .FromSeconds(x.Tickets.Sum(s => s.Projection.Movie.Duration.TotalSeconds))
                    .ToString(@"hh\:mm\:ss")
                })               
                .Take(10)
                .ToArray();

            var sb = new StringBuilder();

            var xml = new XmlSerializer(typeof(ExportCusotmerDTO[]), new XmlRootAttribute("Customers"));
            var namespaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });
            xml.Serialize(new StringWriter(sb), customers, namespaces);

            return sb.ToString().TrimEnd();
        }
    }
}