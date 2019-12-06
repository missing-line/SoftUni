namespace CarDealer.Dtos.Import
{
    using System.Xml.Serialization;

    [XmlType("Car")]
    public class CarDTO
    {
        [XmlElement("make")]
        public string Make { get; set; }


        [XmlElement("model")]
        public string Model { get; set; }


        [XmlElement("TraveledDistance")]
        public long TraveledDistance { get; set; }


        [XmlElement("parts")]
        public PartCatDTO Parts { get; set; } 

    }
}
