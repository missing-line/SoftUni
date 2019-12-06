namespace ProductShop.DateTransferObject.Export
{
    using Newtonsoft.Json;

    public class ProductDTO
    {
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "price")]
        public decimal Price { get; set; }

        [JsonProperty(PropertyName = "seller")]
        public string Seller { get; set; }

        [JsonProperty(PropertyName = "count")]
        public int Count { get; set; }
    }
}
