namespace Stations.Processor.Exports
{
    using System;
    using System.Xml.Serialization;

    [XmlType("Ticket")]
    public class ExportTickedDto
    {
        [XmlElement("OriginStation")]
        public string OriginStation { get; set; }

        [XmlElement("DestinationStation")]
        public string DestinationStation { get; set; }

        [XmlElement("DepartureTime")]
        public DateTime DepartureTime { get; set; }
    }
}
