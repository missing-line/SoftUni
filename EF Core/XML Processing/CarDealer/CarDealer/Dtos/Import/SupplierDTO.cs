namespace CarDealer.Dtos
{
    using System.Xml.Serialization;
    [XmlType("Supplier")]
    public class SupplierDTO
    {
        [XmlElement("name")]
        public string Name { get; set; }

        [XmlElement("isImporter")]
        public bool isImporter { get; set; }
    }
}
