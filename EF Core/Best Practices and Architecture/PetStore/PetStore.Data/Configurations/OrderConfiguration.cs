namespace PetStore.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using PetStore.Models;
  
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder
                 .HasOne(e => e.User)
                 .WithMany(e => e.Orders)
                 .HasForeignKey(e => e.UserId)
                 .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasMany(e => e.Pets)
                .WithOne(e => e.Order)
                .HasForeignKey(e => e.OrderId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
