namespace Stations.Processor.Exports
{
    using Stations.Models.Models.Enums;
    using System.Xml.Serialization;

    [XmlType("Card")]
    public class ExportCardDto
    {
        [XmlAttribute("name")]
        public string Name { get; set; } 

        [XmlAttribute("type")]
        public CardType Type { get; set; }

        [XmlArray("Tickets")]
        public ExportTickedDto[] Tickets { get; set; }
    }
}
