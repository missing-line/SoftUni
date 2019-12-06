namespace Stations.Processor.Imports
{
    using System.ComponentModel.DataAnnotations;
    using System.Xml.Serialization;

    [XmlType("Card")]
    public class ImportCardDto
    {
        [XmlElement("Name")]
        [Required]
        [StringLength(128)]
        public string Name { get; set; }

        [XmlElement("Age")]
        [Required]
        [Range(0, 120)]
        public int Age { get; set; }

        [XmlElement("CardType")]
        public string CardType { get; set; }
    }
}
