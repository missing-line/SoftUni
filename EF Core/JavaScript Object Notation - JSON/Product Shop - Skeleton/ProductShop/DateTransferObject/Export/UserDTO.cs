namespace ProductShop.DateTransferObject.Export
{
    using Newtonsoft.Json;
    using ProductShop.Models;
    using System.Collections.Generic;
    public class UserDTO
    {
        [JsonProperty(PropertyName = "firstName")]
        public string FirstName { get; set; }

        [JsonProperty(PropertyName = "lastName")]
        public string LastName { get; set; }

        [JsonProperty(PropertyName = "soldProducts")]
        public ICollection<SoldProductsDTO> SoldProducts { get; set; }

    }
}
