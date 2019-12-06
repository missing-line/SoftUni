namespace Cinema.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using Cinema.Data.Models;
    using Cinema.Data.Models.Enums;
    using Cinema.DataProcessor.ImportDto;
    using Data;
    using Newtonsoft.Json;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";
        private const string SuccessfulImportMovie
            = "Successfully imported {0} with genre {1} and rating {2}!";
        private const string SuccessfulImportHallSeat
            = "Successfully imported {0}({1}) with {2} seats!";
        private const string SuccessfulImportProjection
            = "Successfully imported projection {0} on {1}!";
        private const string SuccessfulImportCustomerTicket
            = "Successfully imported customer {0} {1} with bought tickets: {2}!";

        public static string ImportMovies(CinemaContext context, string jsonString)
        {
            var sb = new StringBuilder();

            var list = new List<Movie>();

            var dtos = JsonConvert
                .DeserializeObject<ImportMovieDTO[]>(jsonString);

            foreach (var dto in dtos)
            {
                var findTitle = list.Find(x => x.Title == dto.Title);
                var genre = Enum.TryParse(dto.Genre, out Genre genreResult);

                if (!IsValid(dto) || findTitle != null || !genre)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                list.Add(AutoMapper.Mapper.Map<Movie>(dto));

                sb.AppendLine
                    (
                         string.Format(SuccessfulImportMovie, dto.Title, dto.Genre, $"{dto.Rating:f2}")
                    );

            }

            context.Movies.AddRange(list);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportHallSeats(CinemaContext context, string jsonString)
        {

            var sb = new StringBuilder();

            var list = new List<Hall>();

            var dtos = JsonConvert
                .DeserializeObject<ImportHallDTO[]>(jsonString);

            foreach (var dto in dtos)
            {
                if (!IsValid(dto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var hall = new Hall
                {
                    Name = dto.Name,
                    Is4Dx = dto.Is4Dx,
                    Is3D = dto.Is3D
                };

                for (int i = 0; i < dto.Seats; i++)
                {
                    hall.Seats.Add(new Seat());
                }


                list.Add(hall);

                string projectionType = string.Empty;

                if (hall.Is4Dx && hall.Is3D)
                {
                    projectionType = "4Dx/3D";
                }
                else if (hall.Is4Dx || hall.Is3D)
                {
                    projectionType = hall.Is4Dx == true ? "4Dx" : "3D";
                }
                else
                {
                    projectionType = "Normal";
                }

                sb.AppendLine(string.Format(SuccessfulImportHallSeat,
                  hall.Name, projectionType, dto.Seats));

            }

            context.Halls.AddRange(list);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportProjections(CinemaContext context, string xmlString)
        {
            var sb = new StringBuilder();

            var list = new List<Projection>();

            var xml = new XmlSerializer(typeof(ProjectionDTO[]), new XmlRootAttribute("Projections"));

            var dtos = (ProjectionDTO[])xml
                .Deserialize(new StringReader(xmlString));

            foreach (var dto in dtos)
            {
                var checkMovie = context.Movies.Find(dto.MovieId);
                var checkHalli = context.Halls.Find(dto.HallId);
                var find = list.Any(x => x.MovieId == dto.MovieId && x.HallId == dto.HallId);

                if (!IsValid(dto) || checkMovie == null || checkHalli == null || find)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var projection = new Projection
                {
                    MovieId = dto.MovieId,
                    HallId = dto.HallId,
                    DateTime = DateTime.ParseExact(dto.DateTime, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture)
                };

                string title = context.Movies.FirstOrDefault(x => x.Id == dto.MovieId).Title;

                sb.AppendLine(string.Format(SuccessfulImportProjection, title, projection.DateTime.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture)));
                list.Add(projection);
            }

            context.Projections.AddRange(list);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportCustomerTickets(CinemaContext context, string xmlString)
        {
            var sb = new StringBuilder();

            var list = new List<Customer>();

            var xml = new XmlSerializer(typeof(TicketCustomerDTO[]), new XmlRootAttribute("Customers"));

            var dtos = (TicketCustomerDTO[])xml
                .Deserialize(new StringReader(xmlString));

            foreach (var dto in dtos)
            {
                if (!IsValid(dto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var customer = new Customer
                {
                    FirstName = dto.FirstName,
                    LastName = dto.LastName,
                    Age = dto.Age,
                    Balance = dto.Balance,
                };

                foreach (var ticket in dto.Tickets)
                {
                    customer.Tickets.Add(new Ticket
                    {
                        Price = ticket.Price,
                        ProjectionId = ticket.ProjectionId
                    });
                }

                sb.AppendLine(string.Format(SuccessfulImportCustomerTicket,
                    customer.FirstName, customer.LastName, customer.Tickets.Count));

                list.Add(customer);
            }

            context.Customers.AddRange(list);
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