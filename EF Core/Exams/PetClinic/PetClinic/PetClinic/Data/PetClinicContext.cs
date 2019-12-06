namespace PetClinic.Data
{
    using Microsoft.EntityFrameworkCore;
    using PetClinic.Data.Config;
    using PetClinic.Models;

    public class PetClinicContext : DbContext
    {
        public PetClinicContext(DbContextOptions options)
            : base(options) { }

        public PetClinicContext() { }

        public DbSet<Procedure> Procedures { get; set; }
        public DbSet<Animal> Animals { get; set; }
        public DbSet<AnimalAid> AnimalAids { get; set; }
        public DbSet<Vet> Vets { get; set; }
        public DbSet<ProcedureAnimalAid> ProcedureAnimalAids { get; set; }
        public DbSet<Passport> Passports { get; set; }     

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Configuretion.connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AnimalAidConfiguration());
            modelBuilder.ApplyConfiguration(new PassportConfiguration());
            modelBuilder.ApplyConfiguration(new AnimalConfiguration());
            modelBuilder.ApplyConfiguration(new ProcedureAnimalAidConfig());         
            modelBuilder.ApplyConfiguration(new VetConfiguration());         
        }
    }
}
