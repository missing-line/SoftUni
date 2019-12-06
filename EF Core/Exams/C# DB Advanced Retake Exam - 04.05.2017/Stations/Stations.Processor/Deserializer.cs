namespace Stations.Processor
{
    using Newtonsoft.Json;
    using Stations.Data;
    using Stations.Models.Models;
    using Stations.Models.Models.Enums;
    using Stations.Processor.Imports;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid Data";
        private const string SuccessMessage = "Record {0} successfully imported.";
        private const string SuccessMessageTrip = "Trip from {0} to {1} imported.";
        private const string SuccessMessageTicket = "Ticket from {0} to {1} departing at {2} imported.";

        public static DateTimeStyles CulturInfo { get; private set; }

        public static string ImportStations(StationContext context, string jsonString)
        {
            var stations = new List<Station>();

            var sb = new StringBuilder();

            var dtos = JsonConvert
                .DeserializeObject<ImportStatioDto[]>(jsonString);

            foreach (var dto in dtos)
            {
                if (dto.Town == null)
                {
                    dto.Town = dto.Name;
                }

                if (!IsValid(dto) || stations.Any(x => x.Name == dto.Name))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                stations.Add(new Station { Name = dto.Name, Town = dto.Town });
                sb.AppendLine(string.Format(SuccessMessage, dto.Name));
            }

            context.Stations.AddRange(stations);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportSeeatClasses(StationContext context, string jsonString)
        {
            var sb = new StringBuilder();

            var seatClasses = new List<SeatClass>();

            var dtos = JsonConvert.DeserializeObject<ImportSeatClassDto[]>(jsonString);

            foreach (var dto in dtos)
            {
                var seatClass = seatClasses
                    .SingleOrDefault(x => x.Name == dto.Name || x.Abbreviation == dto.Abbreviation); // && ||

                if (!IsValid(dto) || seatClass != null)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                seatClasses.Add(new SeatClass { Name = dto.Name, Abbreviation = dto.Abbreviation });
                sb.AppendLine(string.Format(SuccessMessage, dto.Name));
            }

            context.SeatClasses.AddRange(seatClasses);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportTrains(StationContext context, string jsonString)
        {
            var sb = new StringBuilder();
            var trains = new List<Train>();

            var dtos = JsonConvert
                .DeserializeObject<ImposrtTrainDto[]>(jsonString);

            foreach (var dto in dtos)
            {
                if (dto.Type == null)
                {
                    dto.Type = "HighSpeed";
                }


                if (!IsValid(dto) || dto.Seats.All(IsValid) || !IsAllSeatClassesExists(context, dto.Seats))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var train = new Train { Number = dto.Number, Type = Enum.Parse<TrainType>(dto.Type) };

                foreach (var seat in dto.Seats)
                {
                    if (train.TrainSeats.Any(x => x.SeatClass.Name == seat.Name))
                    {
                        continue;
                    }

                    var seatClass = context.SeatClasses
                        .SingleOrDefault(x => x.Name == seat.Name && x.Abbreviation == seat.Abbreviation);

                    train.TrainSeats.Add(new TrainSeat { SeatClass = seatClass, Quantity = seat.Quantity });
                }

                trains.Add(train);

                sb.AppendLine(string.Format(SuccessMessage, dto.Number));
            }

            context.Trains.AddRange(trains);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportTrip(StationContext context, string jsonString)
        {
            var sb = new StringBuilder();

            var trips = new List<Trip>();

            var dtos = JsonConvert
                .DeserializeObject<ImportTripDto[]>(jsonString);

            foreach (var dto in dtos)
            {
                dto.Status = dto.Status == null ? "OnTime" : dto.Status;

                var train = context.Trains.SingleOrDefault(x => x.Number == dto.Train);
                var startStation = context.Stations.SingleOrDefault(x => x.Name == dto.OriginStation);
                var endStation = context.Stations.SingleOrDefault(x => x.Name == dto.DestinationStation);
                if (!IsValid(dto) || train == null || startStation == null || endStation == null)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var departure = DateTime.ParseExact(dto.Departure, @"dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);
                var arrival = DateTime.ParseExact(dto.ArrivalTime, @"dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);

                if (departure >= arrival)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var trip = new Trip
                {
                    OriginStation = startStation,
                    DestinationStation = endStation,
                    Departure = departure,
                    ArrivalTime = arrival,
                    Train = train,
                    Status = Enum.Parse<StatusType>(dto.Status),
                };

                if (dto.TimeDifference != null)
                {
                    trip.TimeDifference = TimeSpan.ParseExact(dto.TimeDifference, @"hh\:mm", CultureInfo.InvariantCulture);
                }

                trips.Add(trip);
                sb.AppendLine(string.Format(SuccessMessageTrip, trip.OriginStation.Name, trip.DestinationStation.Name));
            }

            context.Trips.AddRange(trips);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportTickets(StationContext context, string xmlString)
        {
            var tickets = new List<Ticket>();

            var sb = new StringBuilder();

            var xml = new XmlSerializer(typeof(ImportTicketDto[]), new XmlRootAttribute("Tickets"));

            var dtos = (ImportTicketDto[])xml
                .Deserialize(new StringReader(xmlString));

            foreach (var dto in dtos)
            {
                var trip = context.Trips
                    .SingleOrDefault
                (
                    x => x.OriginStation.Name == dto.Trip.OriginStation &&
                    x.DestinationStation.Name == dto.Trip.DestinationStation &&
                    x.Departure.ToString() == dto.Trip.DepartureTime
                );

                string abbreviation = dto.Seat.Substring(0, 2);
                int seatNumber = int.Parse(dto.Seat.Skip(2).ToString());

                var seatClass = context.SeatClasses
                    .SingleOrDefault(x => x.Abbreviation == abbreviation);

                var trainSeat = trip.Train
                    .TrainSeats
                    .SingleOrDefault(x => x.SeatClassId == seatClass.Id && x.Quantity >= seatNumber && seatNumber > 0);

                if (
                    !IsValid(dto) ||
                    trip == null ||
                    trainSeat == null ||
                    dto.CustomerCard == null ||
                    !IsSingleExistCardNameOwner(context, dto.CustomerCard)
                   )
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }


                tickets.Add(new Ticket
                {
                    Trip = trip,
                    Price = dto.Price,
                    SeatingPlace = dto.Seat,
                    CustomerCard = context.CustomerCards.SingleOrDefault(x => x.Name == dto.CustomerCard)

                });

                sb.AppendLine(string.Format
                    (
                        SuccessMessageTicket ,dto.Trip.OriginStation,
                        dto.Trip.DestinationStation,
                        dto.Trip.DepartureTime
                    ));   
            }

            context.Tickets.AddRange(tickets);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportPersonCards(StationContext context,string xmlString)
        {
            var sb = new StringBuilder();

            var cards = new List<CustomerCard>();

            var xml = new XmlSerializer(typeof(ImportCardDto[]), new XmlRootAttribute("Cards"));

            var dtos = (ImportCardDto[])xml
                .Deserialize(new StringReader(xmlString));

            foreach (var dto in dtos)
            {
                dto.CardType = dto.CardType == null ? "Normal" : dto.CardType;
                if (!IsValid(dto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                cards.Add(new CustomerCard
                {
                    Name = dto.Name,
                    Age = dto.Age,
                    Type = Enum.Parse<CardType>(dto.CardType)
                });

                sb.AppendLine(string.Format(SuccessMessage, dto.Name));
            }

            context.CustomerCards.AddRange(cards);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }


        /// <summary>
        /// helper methods
        /// </summary>
        /// <param name="context"></param>
        /// <param name="customer"></param>
        /// <returns></returns>
        private static bool IsSingleExistCardNameOwner(StationContext context, string customer)
        {
            int count = context.CustomerCards
                .Where(x => x.Name == customer)
                .Count();

            return count == 1;
        }

        private static bool IsAllSeatClassesExists(StationContext context, SeatDto[] seatClasses)
        {
            foreach (var seat in seatClasses)
            {
                if (!context.SeatClasses.Any(x => x.Name == seat.Name && x.Abbreviation == seat.Abbreviation))
                {
                    return false;
                }
            }

            return true;
        }

        private static bool IsValid(object obj)
        {
            var validationContext = new ValidationContext(obj);
            var validationResults = new List<ValidationResult>();

            return Validator.TryValidateObject(obj, validationContext, validationResults, true);
        }
    }
}
