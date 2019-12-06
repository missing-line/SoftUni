namespace Stations.Models.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    public class Station
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 1)]
        public string Name { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 1)]
        public string Town { get; set; }


        public ICollection<Trip> TripsTo { get; set; } = new List<Trip>();

        public ICollection<Trip> TripsFrom { get; set; } = new List<Trip>();  
    }
}
