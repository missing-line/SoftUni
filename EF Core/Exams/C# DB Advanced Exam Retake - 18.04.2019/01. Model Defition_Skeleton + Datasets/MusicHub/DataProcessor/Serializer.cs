namespace MusicHub.DataProcessor
{
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Serialization;
    using Data;
    using MusicHub.DataProcessor.ExportDtos;
    using Newtonsoft.Json;
    using Formatting = Newtonsoft.Json.Formatting;

    public class Serializer
    {
        public static string ExportAlbumsInfo(MusicHubDbContext context, int producerId)
        {
            var albums = context.Albums
               .Where(p => p.ProducerId == producerId)
               .OrderByDescending(s => s.Price)
               .Select(x => new
               {
                   AlbumName = x.Name,
                   ReleaseDate = x.ReleaseDate.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture),
                   ProducerName = x.Producer.Name,
                   Songs = x.Songs
                   .Select(s => new
                   {
                       SongName = s.Name,
                       Price = $"{s.Price:f2}",
                       Writer = s.Writer.Name

                   }).OrderByDescending(sn => sn.SongName).ThenBy(w => w.Writer).ToList(),
                   AlbumPrice = $"{x.Price:f2}"
               })
               .ToList();

            return JsonConvert.SerializeObject(albums, Formatting.Indented);
        }

        public static string ExportSongsAboveDuration(MusicHubDbContext context, int duration)
        {
            var songs = context.Songs
                 .Where(x => x.Duration.TotalSeconds > duration)
                 .Select(x => new ExportSongDTO
                 {
                     SongName = x.Name,
                     WriterName = x.Writer.Name,
                     PerformerName = x.SongPerformers
                     .FirstOrDefault(p => p.SongId == x.Id).Performer.FirstName + " " + x.SongPerformers
                     .FirstOrDefault(p => p.SongId == x.Id).Performer.LastName,
                     AlbumProducer = x.Album.Producer.Name,
                     Duration = x.Duration.ToString("c")

                 })
                 .OrderBy(x => x.SongName)
                 .ThenBy(w => w.WriterName)           
                 .ToArray();

            var sb = new StringBuilder();

            var xml = new XmlSerializer(typeof(ExportSongDTO[]), new XmlRootAttribute("Songs"));

            var namespaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });
            xml.Serialize(new StringWriter(sb), songs, namespaces);

            return sb.ToString().TrimEnd();
        }
    }
}