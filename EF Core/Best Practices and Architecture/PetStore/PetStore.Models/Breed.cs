namespace PetStore.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using static DataValidation;
    public class Breed
    {
        public Breed()
        {
            this.Pets = new List<Pet>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(MaxLength), MinLength(MinLength)]
        public string Name { get; set; }


        public ICollection<Pet> Pets { get; set; }
    }
}
