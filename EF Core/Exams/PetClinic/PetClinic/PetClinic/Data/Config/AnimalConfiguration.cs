namespace PetClinic.Data.Config
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using PetClinic.Models;

    public class AnimalConfiguration : IEntityTypeConfiguration<Animal>
    {
        public void Configure(EntityTypeBuilder<Animal> builder)
        {
            builder
                .HasOne(e => e.Passport)
                .WithOne(e => e.Animal)
                .HasForeignKey<Animal>(e => e.PassportSerialNumber);
        }
    }
}
