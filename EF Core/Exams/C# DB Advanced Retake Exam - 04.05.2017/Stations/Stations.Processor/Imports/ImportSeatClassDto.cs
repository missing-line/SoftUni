namespace Stations.Processor.Imports
{
    using System.ComponentModel.DataAnnotations;

    public class ImportSeatClassDto
    {
        [Required]
        [StringLength(30)]
        public string Name { get; set; }

        [Required]
        [RegularExpression(@"^[^\s]{2}$")]
        public string Abbreviation { get; set; }
    }
}
