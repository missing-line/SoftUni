namespace PetClinic.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public class Procedure
    {
        public Procedure()
        {
            this.ProcedureAnimalAids = new List<ProcedureAnimalAid>();
        }
        [Key]
        public int Id { get; set; }

        [Required]
        public int AnimalId { get; set; }
        public Animal Animal { get; set; }

        [Required]
        public int VetId { get; set; }
        public Vet Vet { get; set; }

        [Required]
        public DateTime DateTime { get; set; }

        [NotMapped]
        public decimal Cost 
            => this.ProcedureAnimalAids.Sum(x => x.AnimalAid.Price);

        //-	Cost – the cost of the procedure, calculated by summing the price of the different services performed; does not need to be inserted in the database

        public ICollection<ProcedureAnimalAid> ProcedureAnimalAids { get; set; }      
    }
}
