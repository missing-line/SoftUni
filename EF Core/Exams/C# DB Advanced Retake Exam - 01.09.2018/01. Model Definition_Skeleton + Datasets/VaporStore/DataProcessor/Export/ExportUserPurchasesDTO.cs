namespace VaporStore.DataProcessor.Export
{
    using System.Xml.Serialization;


    [XmlType("User")]
    public class ExportUserPurchasesDTO
    {
        [XmlAttribute("username")]
        public string UserName { get; set; }

        [XmlArray("Purchases")]
        public PurchaseDTO[] Purchases { get; set; }

        public decimal TotalSpent { get; set; }

    }
}
