namespace Stations.Models.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class TrainSeat
    {
        [Required]
        public int TrainId { get; set; }
        public Train Train { get; set; }

        [Required]
        public int SeatClassId { get; set; }
        public SeatClass SeatClass { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int Quantity { get; set; }

    }
}
