namespace PetClinic.Processor.Dto.Export
{
    using System.Xml.Serialization;

    [XmlType("AnimalAid")]
    public class ExportAnimalAidsDto
    {
        [XmlElement("Name")]
        public string Name { get; set; }

        [XmlElement("Price")]
        public decimal Price { get; set; }
    }
}
