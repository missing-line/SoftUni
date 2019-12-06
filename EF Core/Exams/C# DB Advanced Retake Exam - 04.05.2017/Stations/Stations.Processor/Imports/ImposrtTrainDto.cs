namespace Stations.Processor.Imports
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class ImposrtTrainDto
    {
        [Required]
        [Range(1, 10)]
        public string Number { get; set; }

        [Required]
        public string Type { get; set; }

        [Required]
        [MinLength(1)]
        public SeatDto[] Seats{get;set;}
    }
}
