namespace ProductShop.Dtos.Export
{
    using System.Xml.Serialization;
    [XmlType("SoldProducts")]
    public class SoldProductsCountDto
    {
        [XmlElement("count")]
        public int Count { get; set; }

        [XmlArray("products")]
        public SoldProductDTO[] Products { get; set; }
    }
}
