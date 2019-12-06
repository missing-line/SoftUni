namespace PetStore.Models
{
    using PetStore.Models.Enums;
    using System;
    using System.ComponentModel.DataAnnotations;

    using static DataValidation;
    public class Pet
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public Gender Gender { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }

        [Required]
        [Range(typeof(decimal), "0.01", "79228162514264337593543950335")]
        public decimal Price { get; set; }


        [MaxLength(DescriptionMaxLength)]
        public string Description { get; set; }



        public int? OrderId { get; set; }
        public Order Order { get; set; }

        public int BreedId { get; set; }
        public Breed Breed { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
