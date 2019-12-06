namespace Stations.Models.Models
{
    using Stations.Models.Models.Enums;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Trip
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int OriginStationId { get; set; }
        public Station OriginStation { get; set; }

        [Required]
        public int DestinationStationId { get; set; }
        public Station DestinationStation { get; set; }

        [Required]
        public DateTime Departure { get; set; }

        [Required]
        public DateTime ArrivalTime { get; set; }
         
        [Required]
        public int TrainId { get; set; }
        public Train Train { get; set; }

        [Required]
        public StatusType Status { get; set; }


        public TimeSpan? TimeDifference { get; set; }
       

        public ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
    }
}
