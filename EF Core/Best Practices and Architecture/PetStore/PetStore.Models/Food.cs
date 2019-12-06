namespace PetStore.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using static DataValidation;
    public class Food
    {
        public Food()
        {
            this.FoodOrders = new List<FoodOrder>();
        }

        [Key]
        public int Id { get; set; }


        [Required]
        [MaxLength(MaxLength), MinLength(MinLength)]
        public string Name { get; set; }


        [Range(0.01, double.MaxValue)]
        public double Weight { get; set; }

        [Required]
        [Range(typeof(decimal), "0.01" , "79228162514264337593543950335")]
        public decimal Price { get; set; }

        [Required]
        [Range(typeof(decimal), "0.01", "79228162514264337593543950335")]
        public decimal PriceFromDistributor { get; set; }

        [Required]
        public DateTime ExpirationDate { get; set; }

        [Required]
        public int BrandId { get; set; }
        public Brand Brand { get; set; }

        [Required]
        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public ICollection<FoodOrder> FoodOrders { get; set; }
    }
}
