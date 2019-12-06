namespace Stations.Processor.Imports
{
    using System.ComponentModel.DataAnnotations;


    public class ImportStatioDto
    {
        [Required]
        [StringLength(50, MinimumLength = 1)]
        public string Name { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 1)]
        public string Town { get; set; }
    }
}
