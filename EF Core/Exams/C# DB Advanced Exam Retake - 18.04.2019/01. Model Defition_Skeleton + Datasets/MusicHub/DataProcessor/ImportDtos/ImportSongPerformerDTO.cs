namespace MusicHub.DataProcessor.ImportDtos
{
    using System.Xml.Serialization;

    [XmlType("Song")]
    public class ImportSongPerformerDTO
    {
        [XmlAttribute("id")]
        public int SongId { get; set; }
    }
}
