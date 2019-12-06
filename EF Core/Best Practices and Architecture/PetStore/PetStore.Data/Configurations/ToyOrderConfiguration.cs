namespace PetStore.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using PetStore.Models;
    using System;


    public class ToyOrderConfiguration : IEntityTypeConfiguration<ToyOrder>
    {
        public void Configure(EntityTypeBuilder<ToyOrder> builder)
        {
            builder
                .HasKey(e => new { e.OrderId, e.ToyId });

            builder
                .HasOne(e => e.Toy)
                .WithMany(e => e.ToyOrders)
                .HasForeignKey(e => e.ToyId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
              .HasOne(e => e.Order)
              .WithMany(e => e.ToyOrders)
              .HasForeignKey(e => e.OrderId)
              .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
