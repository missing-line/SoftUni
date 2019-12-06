namespace CarDealer.Dtos.Export
{
    using System.Xml.Serialization;
    [XmlType("car")]
    public class ExportCarBmwDTO
    {
        [XmlAttribute("id")]
        public string Id { get; set; }

        [XmlAttribute("model")]
        public string Model { get; set; }

        [XmlAttribute("travelled-distance")]
        public decimal Travelled { get; set; }

    }
}
