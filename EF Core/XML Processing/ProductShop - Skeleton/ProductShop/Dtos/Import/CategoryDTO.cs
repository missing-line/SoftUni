namespace ProductShop.Dtos.Export
{
    using System.Xml.Serialization;

    [XmlType("Category")]
    public class CategoryDTO
    {
        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }
    }
}
