namespace Stations.Processor.Imports
{
    using System.ComponentModel.DataAnnotations;
    using System.Xml.Serialization;

    [XmlType("Ticket")]
    public class ImportTicketDto
    {
        [XmlAttribute("price")]
        [Required]
        [Range(typeof(decimal), "0", "79228162514264337593543950335")]
        public decimal Price { get; set; }

        [XmlAttribute("seat")]
        [Required]
        [RegularExpression(@"^[^\s]{2}[0-9]{1,6}$")]
        public string Seat { get; set; }

        [XmlElement("Trip")]
        public TicketTripDto Trip { get; set; }

        [XmlElement("Card Name")]
        public string CustomerCard { get; set; }        
    }
}
