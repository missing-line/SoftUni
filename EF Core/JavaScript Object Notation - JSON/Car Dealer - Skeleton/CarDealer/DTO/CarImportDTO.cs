﻿namespace CarDealer.DTO
{
    using System.Collections.Generic;
    public class CarImportDTO
    {
        public string Make { get; set; }

        public string Model { get; set; }

        public long TravelledDistance { get; set; }

        public ICollection<int> PartsId { get; set; } = new List<int>();

    }
}
