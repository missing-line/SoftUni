namespace PetClinic.Processor.Dto.Import
{
    using System.ComponentModel.DataAnnotations;
    using System.Xml.Serialization;

    [XmlType("Procedure")]
    public class ImportProducerDto
    {
        [Required]
        [XmlElement("Animal")]
        public string Animal { get; set; }

        [Required]
        [XmlElement("Vet")]
        public string Vet { get; set; }

        [Required]
        [XmlElement("DateTime")]
        public string DateTime { get; set; }    //14-01-2016

        [XmlArray("AnimalAids")]
        public AnimalAidDto[] AnimalAids { get; set; }
 
    }
}
