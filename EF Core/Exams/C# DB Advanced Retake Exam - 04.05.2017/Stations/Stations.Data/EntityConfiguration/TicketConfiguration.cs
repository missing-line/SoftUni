namespace Stations.Data
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Stations.Models.Models;
    using System;

    internal class TicketConfiguration : IEntityTypeConfiguration<Ticket>
    {
        public void Configure(EntityTypeBuilder<Ticket> builder)
        {
            builder
                .HasOne(e => e.CustomerCard)
                .WithMany(e => e.BoughtTickets)
                .HasForeignKey(e => e.CustomerCardId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired(false);

            builder
                .HasOne(e => e.Trip)
                .WithMany(e => e.Tickets)
                .HasForeignKey(e => e.TripId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
