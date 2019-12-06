namespace PetStore.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using static DataValidation;
    public class Category
    {
        public Category()
        {
            this.Pets = new List<Pet>();
            this.Toys = new List<Toy>();
            this.Foods = new List<Food>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(MaxLength), MinLength(MinLength)]
        public string Name { get; set; }

        [MaxLength(DescriptionMaxLength)]
        public string Description { get; set; }

        public ICollection<Pet> Pets { get; set; }
        public ICollection<Toy> Toys { get; set; }
        public ICollection<Food> Foods { get; set; }
    }
}
