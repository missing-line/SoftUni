namespace FastFood.Web.ViewModels.Items
{
    using System.ComponentModel.DataAnnotations;
    public class CreateItemInputModel
    {
        [Required]
        [StringLength(20, MinimumLength = 3)]
        public string Name { get; set; }

        [Required]
        [Range(typeof(decimal), "0.01" , "79228162514264337593543950335")]
        public decimal Price { get; set; }

        public int CategoryId { get; set; }
    }
}
