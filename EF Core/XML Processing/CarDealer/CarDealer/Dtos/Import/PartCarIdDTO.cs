namespace CarDealer.Dtos.Import
{
    using System.Xml.Serialization;

    [XmlRoot("parts")]
    public class PartCarIdDTO
    {
        [XmlAttribute("id")]
        public int Id { get; set; }

    }
}
