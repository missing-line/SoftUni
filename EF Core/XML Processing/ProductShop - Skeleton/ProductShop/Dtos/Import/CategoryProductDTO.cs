using System.Xml.Serialization;

namespace ProductShop.Dtos.Export
{
    [XmlType("CategoryProduct")]
    public class CategoryProductDTO
    {
        public int CategoryId { get; set; }

        public int ProductId { get; set; }

    }
}
