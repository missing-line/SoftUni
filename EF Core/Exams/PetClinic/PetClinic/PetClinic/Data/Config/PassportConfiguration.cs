namespace PetClinic.Data.Config
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using PetClinic.Models;
    using System;
    public class PassportConfiguration : IEntityTypeConfiguration<Passport>
    {
        public void Configure(EntityTypeBuilder<Passport> builder)
        {
            builder
                .HasOne(e => e.Animal)
                .WithOne(e => e.Passport)
                .HasForeignKey<Passport>(e => e.AnimalId);
        }
    }
}
