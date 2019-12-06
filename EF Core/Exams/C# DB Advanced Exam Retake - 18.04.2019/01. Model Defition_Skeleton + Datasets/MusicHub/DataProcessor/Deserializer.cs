namespace MusicHub.DataProcessor
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
    using MusicHub.Data.Models;
    using MusicHub.Data.Models.Enums;
    using MusicHub.DataProcessor.ImportDtos;
    using Newtonsoft.Json;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data";

        private const string SuccessfullyImportedWriter
            = "Imported {0}";
        private const string SuccessfullyImportedProducerWithPhone
            = "Imported {0} with phone: {1} produces {2} albums";
        private const string SuccessfullyImportedProducerWithNoPhone
            = "Imported {0} with no phone number produces {1} albums";
        private const string SuccessfullyImportedSong
            = "Imported {0} ({1} genre) with duration {2}";
        private const string SuccessfullyImportedPerformer
            = "Imported {0} ({1} songs)";

        public static string ImportWriters(MusicHubDbContext context, string jsonString)
        {
            var sb = new StringBuilder();

            var list = new List<Writer>();

            var dtos = JsonConvert
                .DeserializeObject<ImportWriterDTO[]>(jsonString);

            foreach (var dto in dtos)
            {
                if (!IsValid(dto))
                {
                    sb.AppendLine(string.Format(ErrorMessage));
                    continue;
                }
                list.Add(AutoMapper.Mapper.Map<Writer>(dto));
                sb.AppendLine(string.Format(SuccessfullyImportedWriter, dto.Name));
            }

            context.Writers.AddRange(list);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportProducersAlbums(MusicHubDbContext context, string jsonString)
        {
            var sb = new StringBuilder();

            var list = new List<Producer>();

            var dtos = JsonConvert
                .DeserializeObject<ImportProcuserDTO[]>(jsonString);


            foreach (var dto in dtos)
            {
                if (!IsValid(dto) || !dto.Albums.All(IsValid))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var producer = new Producer()
                {
                    Name = dto.Name,
                    Pseudonym = dto.Pseudonym,
                    PhoneNumber = dto.PhoneNumber,
                    Albums = new List<Album>()
                };

                if (dto.Albums.Length != 0)
                {
                    foreach (var album in dto.Albums)
                    {
                        var currAlbum = new Album()
                        {
                            Name = album.Name,
                            ReleaseDate = DateTime.ParseExact(album.ReleaseDate, "dd/MM/yyyy", CultureInfo.InvariantCulture)
                        };
                        producer.Albums.Add(currAlbum);
                    }
                    list.Add(producer);
                }


                string message = producer.PhoneNumber == null ?
                    string.Format(SuccessfullyImportedProducerWithNoPhone, producer.Name, producer.Albums.Count) :
                    string.Format(SuccessfullyImportedProducerWithPhone, producer.Name, producer.PhoneNumber, producer.Albums.Count);

                sb.AppendLine(message);

                list.Add(producer);
            }

            context.Producers.AddRange(list);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportSongs(MusicHubDbContext context, string xmlString)
        {
            var sb = new StringBuilder();

            var list = new List<Song>();

            var xml = new XmlSerializer(typeof(ImportSongDTO[]), new XmlRootAttribute("Songs"));

            var dtos = (ImportSongDTO[])xml
                .Deserialize(new StringReader(xmlString));

            foreach (var dto in dtos)
            {
                if (!IsValid(dto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var genre = Enum.TryParse(dto.Genre, out Genre genreResult);
                var album = context.Albums.Find(dto.AlbumId);
                var writer = context.Writers.Find(dto.WriterId);
                var songTitle = list.Any(s => s.Name == dto.Name);

                if (songTitle || !genre || album == null || writer == null)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var song = AutoMapper.Mapper.Map<Song>(dto);

                list.Add(song);
                sb.AppendLine
                    (
                        string.Format(SuccessfullyImportedSong, song.Name, song.Genre, song.Duration)
                    );
            }


            context.Songs.AddRange(list);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportSongPerformers(MusicHubDbContext context, string xmlString)
        {
            var sb = new StringBuilder();

            var list = new List<Performer>();

            var xml = new XmlSerializer(typeof(ImportPerformerDTO[]), new XmlRootAttribute("Performers"));

            var dtos = (ImportPerformerDTO[])xml
                .Deserialize(new StringReader(xmlString));


            foreach (var dto in dtos)
            {
                if (!IsValid(dto))
                {

                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var validSongsCount = context.Songs.Count(s => dto.PerformerSongs.Any(i => i.SongId == s.Id));

                if (validSongsCount != dto.PerformerSongs.Length)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                list.Add(AutoMapper.Mapper.Map<Performer>(dto));

                sb.AppendLine
                    (
                        string.Format(SuccessfullyImportedPerformer,
                        dto.FirstName, dto.PerformerSongs.Count())
                    );
            }


            context.Performers.AddRange(list);
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