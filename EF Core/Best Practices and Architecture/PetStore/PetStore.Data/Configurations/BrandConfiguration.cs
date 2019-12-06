namespace PetStore.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using PetStore.Models;
    public class BrandConfiguration : IEntityTypeConfiguration<Brand>
    {
        public void Configure(EntityTypeBuilder<Brand> builder)
        {
            builder
                 .HasMany(e => e.Toys)
                 .WithOne(e => e.Brand)
                 .HasForeignKey(e => e.BrandId)
                 .OnDelete(DeleteBehavior.Restrict);

            builder
                 .HasMany(e => e.Foods)
                 .WithOne(e => e.Brand)
                 .HasForeignKey(e => e.BrandId)
                 .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
