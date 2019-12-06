namespace Stations.Processor.Imports
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class SeatDto
    {
        [Required]
        [StringLength(30)]
        public string Name { get; set; }

        [Required]
        [RegularExpression(@"^[^\s]{2}$")]
        public string Abbreviation { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int Quantity { get; set; }
    }
}
