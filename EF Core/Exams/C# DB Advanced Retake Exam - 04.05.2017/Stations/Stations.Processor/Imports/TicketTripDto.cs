namespace Stations.Processor.Imports
{
    using System.Xml.Serialization;

    [XmlType("Trip")]
    public class TicketTripDto
    {
        [XmlElement("OriginStation")]
        public string OriginStation { get; set; }

        [XmlElement("DestinationStation")]
        public string DestinationStation { get; set; }

        [XmlElement("DepartureTime")]
        public string DepartureTime { get; set; }
    }
}
