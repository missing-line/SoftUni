namespace Stations.Processor
{
    using Newtonsoft.Json;
    using Formatting = Newtonsoft.Json.Formatting;
    using Stations.Data;
    using Stations.Models.Models.Enums;
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Text;
    using Stations.Processor.Exports;
    using System.Xml.Serialization;
    using System.Xml;
    using System.IO;

    public class Serializer
    {
        public static string ExportAllDelayedTrains(StationContext context, string data)
        {

            int delayed = context.Trips
                .Where(x => x.Status == StatusType.Delayed &&
                x.Departure <= DateTime.ParseExact(data, @"dd/MM/yyyy", CultureInfo.InvariantCulture))
                .Count();

            string maxDelayedTime = context.Trips.Where(x => x.Status == StatusType.Delayed &&
                x.Departure <= DateTime.ParseExact(data, @"dd/MM/yyyy", CultureInfo.InvariantCulture))
                .Select(t => t.TimeDifference)
                .OrderByDescending(t => t)
                .Select(t => t.ToString())
                .ToArray()[0];


            var trips = context.Trips
                 .Where(x => x.Status == StatusType.Delayed &&
                 x.Departure <= DateTime.ParseExact(data, @"dd/MM/yyyy", CultureInfo.InvariantCulture))
                 .Select(x => new
                 {
                     TrainNumber = x.Train.Number,
                     DelayedTimes = delayed,
                     MaxDelayedTime = maxDelayedTime

                 })
                 .OrderByDescending(x => x.DelayedTimes)
                 .ThenByDescending(x => x.MaxDelayedTime)
                 .ThenBy(x => x.TrainNumber)
                 .ToArray();

            return JsonConvert.SerializeObject(trips, Formatting.Indented);
        }

        public static string CardType(StationContext context, string data)
        {
           var cursomerCards = context.CustomerCards
                .Where(x => x.Type == Enum.Parse<CardType>(data))
                .Select(x => new ExportCardDto
                {
                    Name = x.Name,
                    Type = x.Type,
                    Tickets = x.BoughtTickets.Select(b => new ExportTickedDto
                    {
                        OriginStation = b.Trip.OriginStation.Name,
                        DestinationStation = b.Trip.DestinationStation.Name,
                        DepartureTime = b.Trip.Departure
                    })
                    .ToArray()
                })
                .OrderBy(n => n.Name)
                .ToArray();

            var sb = new StringBuilder();

            var xml = new XmlSerializer(typeof(ExportTickedDto[]), new XmlRootAttribute("Cards"));
            var namespaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });
            xml.Serialize(new StringWriter(sb), cursomerCards, namespaces);

            return null;
        }
    }
}
