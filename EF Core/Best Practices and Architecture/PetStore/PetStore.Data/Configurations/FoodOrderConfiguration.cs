namespace PetStore.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using PetStore.Models;
    public class FoodOrderConfiguration : IEntityTypeConfiguration<FoodOrder>
    {
        public void Configure(EntityTypeBuilder<FoodOrder> builder)
        {
            builder
                .HasKey(e => new { e.OrderId, e.FoodId });

            builder
                .HasOne(e => e.Food)
                .WithMany(e => e.FoodOrders)
                .HasForeignKey(e => e.FoodId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
              .HasOne(e => e.Order)
              .WithMany(e => e.FoodOrders)
              .HasForeignKey(e => e.OrderId)
              .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
