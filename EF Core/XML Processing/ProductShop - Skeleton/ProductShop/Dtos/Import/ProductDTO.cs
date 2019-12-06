namespace ProductShop.Dtos.Export
{
    using System.Xml.Serialization;
    [XmlType("Product")]
    public class ProductExportDTO
    {
        [XmlElement("name")]
        public string Name { get; set; }

        [XmlElement("price")]
        public decimal Price { get; set; }

        [XmlElement("sellerId")]
        public int sellerId { get; set; }

        [XmlElement("buyerId")]
        public int buyerId { get; set; }  
    }
}
