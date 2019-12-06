namespace Stations.Models.Models
{
    using Stations.Models.Models.Enums;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class CustomerCard
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(128)]
        public string Name { get; set; }

        [Required]
        [Range(0 , 120)]
        public int Age { get; set; }


        public CardType Type { get; set; }


        public ICollection<Ticket> BoughtTickets { get; set; } = new List<Ticket>();

    }
}
