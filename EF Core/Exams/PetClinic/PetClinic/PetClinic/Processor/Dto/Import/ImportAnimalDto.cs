
namespace PetClinic.Processor.Dto.Import
{
    using System;
    using System.ComponentModel.DataAnnotations;
    public class ImportAnimalDto
    {
        [Required]
        [StringLength(20, MinimumLength = 3)]
        public string Name { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 3)]
        public string Type { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int Age { get; set; }

        [Required]
        public ImportPassportDto Passport { get; set; }

    }
}
