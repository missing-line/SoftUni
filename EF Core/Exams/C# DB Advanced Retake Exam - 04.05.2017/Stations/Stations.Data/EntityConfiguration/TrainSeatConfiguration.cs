namespace Stations.Data.EntityConfiguration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Stations.Models.Models;
    using System;
    internal class TrainSeatConfiguration : IEntityTypeConfiguration<TrainSeat>
    {
        public void Configure(EntityTypeBuilder<TrainSeat> builder)
        {
            builder
                 .HasKey(e => new { e.TrainId, e.SeatClassId });

            builder
                .HasOne(e => e.Train)
               .WithMany(e => e.TrainSeats)
               .HasForeignKey(e => e.TrainId);

            builder
               .HasOne(e => e.SeatClass)
               .WithMany(e => e.TrainSeats)
               .HasForeignKey(e => e.SeatClassId);
        }
    }
}
