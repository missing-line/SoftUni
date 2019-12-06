namespace PetClinic.Data.Config
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using PetClinic.Models;
    public class ProcedureAnimalAidConfig : IEntityTypeConfiguration<ProcedureAnimalAid>
    {
        public void Configure(EntityTypeBuilder<ProcedureAnimalAid> builder)
        {
            builder
                .HasKey(e => new { e.AnimalAidId, e.ProcedureId });

            builder
              .HasOne(e => e.AnimalAid)
              .WithMany(e => e.AnimalAidProcedures)
              .HasForeignKey(e => e.AnimalAidId);

            builder
                .HasOne(e => e.Procedure)
                .WithMany(e => e.ProcedureAnimalAids)
                .HasForeignKey(e => e.ProcedureId);

           
        }
    }
}
