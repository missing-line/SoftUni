namespace Stations
{
    using Stations.Processor;
    using Stations.Data;
    using System;
    using System.IO;

    public class StartUp
    {
        private const string baseUrl = @"C:\Users\swade\Desktop\C# DB Advanced Retake Exam - 04.05.2017\Stations\StationsDataSet\";
        public static void Main(string[] args)
        {
            var context = new StationContext();

            ResetDataBase(context);

            Console.WriteLine("Database Reset.");

            ImportEntities(context);

            ExportEntities(context);
        }

        private static void ExportEntities(StationContext context)
        {
            string delayedTrains = Serializer.ExportAllDelayedTrains(context, "01/01/2017");
            //Printer(delayedTrains);

            string cards = Serializer.CardType(context , "Elder");
            //Printer(cards);
        }

        private static void ImportEntities(StationContext context)
        {
            string stations = Deserializer.ImportStations(context, File.ReadAllText(baseUrl + "stations.json"));
            //Printer(stations);

            string seatClasses = Deserializer.ImportSeeatClasses(context, File.ReadAllText(baseUrl + "classes.json"));
            //Printer(seatClasses);

            string trains = Deserializer.ImportTrains(context, File.ReadAllText(baseUrl + "trains.json"));
            //Printer(trains);

            string trips = Deserializer.ImportTrip(context, File.ReadAllText(baseUrl + "trips.json"));
            //Printer(trips);

            string cards = Deserializer.ImportPersonCards(context, File.ReadAllText(baseUrl + "cards.xml"));
            //Printer(cards);

            string tickets = Deserializer.ImportTickets(context, File.ReadAllText(baseUrl + "tickets.xml"));
            //Printer(tickets);
        }

        private static void Printer(string text)
        {
            Console.WriteLine(text);
        }

        private static void ResetDataBase(StationContext context)
        {
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
        }
    }
}
