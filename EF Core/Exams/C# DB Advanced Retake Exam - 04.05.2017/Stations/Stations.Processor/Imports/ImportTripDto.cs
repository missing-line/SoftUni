namespace Stations.Processor.Imports
{
    using System;
    using System.ComponentModel.DataAnnotations;
    public class ImportTripDto
    {
        [Required]
        [Range(1, 10)]
        public string Train { get; set; }

        [Required]
        public string OriginStation { get; set; }

        [Required]
        public string DestinationStation { get; set; }

        [Required]
        public string Departure { get; set; }

        [Required]
        public string ArrivalTime { get; set; }

        [Required]
        public string Status { get; set; }

        public string TimeDifference { get; set; }
    }
}
