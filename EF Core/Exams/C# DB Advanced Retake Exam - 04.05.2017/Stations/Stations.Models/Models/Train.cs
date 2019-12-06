namespace Stations.Models.Models
{
    using Stations.Models.Models.Enums;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Train
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Range(1, 10)]
        public string Number { get; set; }

        public TrainType? Type { get; set; }

        public ICollection<TrainSeat> TrainSeats { get; set; } = new List<TrainSeat>();

        public ICollection<Trip> Trips { get; set; } = new List<Trip>();

    }
}
