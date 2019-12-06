namespace PetStore.Models
{
    using PetStore.Models.Enums;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Order
    {
        public Order()
        {
            this.Pets = new List<Pet>();
            this.FoodOrders = new List<FoodOrder>();
            this.ToyOrders = new List<ToyOrder>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public DateTime PurchaseDate { get; set; }

        [Required]
        public Status Status { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public ICollection<FoodOrder> FoodOrders { get; set; }

        public ICollection<Pet> Pets { get; set; }

        public ICollection<ToyOrder> ToyOrders { get; set; }
    }
}
