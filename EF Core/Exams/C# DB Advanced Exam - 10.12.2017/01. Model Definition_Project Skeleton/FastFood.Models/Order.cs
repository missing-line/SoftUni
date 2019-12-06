namespace FastFood.Models
{
    using FastFood.Models.Enums;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Order
    {
        public Order()
        {
            this.OrderItems = new List<OrderItem>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string Customer { get; set; }


        [Required]
        public DateTime DateTime { get; set; }


        [Required]
        public OrderType Type { get; set; }

        [NotMapped]
        [Required]
        [Range(typeof(decimal), "0" , "79228162514264337593543950335")]
        public decimal TotalPrice { get; set; }

        [Required]
        public  int EmployeeId { get; set; }
        public Employee Employee { get; set; }


        public ICollection<OrderItem> OrderItems { get; set; }
    }
}
