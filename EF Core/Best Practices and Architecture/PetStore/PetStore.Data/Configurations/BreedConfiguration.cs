namespace PetStore.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using PetStore.Models;

    public class BreedConfiguration : IEntityTypeConfiguration<Breed>
    {
        public void Configure(EntityTypeBuilder<Breed> builder)
        {
            builder              
              .HasMany(e => e.Pets)
              .WithOne(e => e.Breed)
              .HasForeignKey(e => e.BreedId)
              .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
