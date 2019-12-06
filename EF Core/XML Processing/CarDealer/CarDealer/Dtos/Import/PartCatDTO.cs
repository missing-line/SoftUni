namespace CarDealer.Dtos.Import
{
    using System.Xml.Serialization;

    [XmlRoot("parts")]
    public class PartCatDTO
    {
        [XmlElement("partId")]
        public PartCarIdDTO[] PartId { get; set; }
    }
}
