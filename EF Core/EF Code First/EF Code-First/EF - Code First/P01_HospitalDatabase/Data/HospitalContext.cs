namespace P01_HospitalDatabase.Data
{
    using System;
    using Microsoft.EntityFrameworkCore;
    using P01_HospitalDatabase.Data.Models;

    public class HospitalContext : DbContext
    {
        public HospitalContext() { }

        public DbSet<Patient> Patients { get; set; }
        public DbSet<Visitation> Visitations { get; set; }
        public DbSet<Diagnose> Diagnoses { get; set; }
        public DbSet<Medicament> Medicaments { get; set; }
        public DbSet<PatientMedicament> Prescriptions { get; set; }
        public DbSet<Doctor> Doctors { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(Config.connecttion);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            ConfPatientEntity(modelBuilder);

            ConfVisitaionEntity(modelBuilder);

            ConfDiagoseEntity(modelBuilder);

            ConfMedicamentEntity(modelBuilder);

            ConfPatientMedicamentEntity(modelBuilder);

            ConfDoctortEntity(modelBuilder);

        }

        private void ConfDoctortEntity(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Doctor>()
                .HasKey(d => d.DoctorId);

            modelBuilder
                .Entity<Doctor>()
                .Property(d => d.Name)
                .HasMaxLength(100)
                .IsUnicode()
                .IsRequired();

            modelBuilder
                .Entity<Doctor>()
                .Property(d => d.Specialty)
                .HasMaxLength(100)
                .IsUnicode()
                .IsRequired();

            modelBuilder
                .Entity<Doctor>()
                .HasMany(d => d.Visitations)
                .WithOne(d => d.Doctor);

        }

        private void ConfPatientMedicamentEntity(ModelBuilder modelBuilder)
        {
            modelBuilder
               .Entity<PatientMedicament>()
               .HasKey(pm => new
               {
                   pm.PatientId,
                   pm.MedicamentId
               });

            modelBuilder
                .Entity<PatientMedicament>()
                .HasOne(pm => pm.Patient)
                .WithMany(pm => pm.Prescriptions)
                .HasForeignKey(pm => pm.PatientId);

            modelBuilder
               .Entity<PatientMedicament>()
               .HasOne(pm => pm.Medicament)
               .WithMany(pm => pm.Prescriptions)
               .HasForeignKey(pm => pm.MedicamentId);
        }

        private void ConfMedicamentEntity(ModelBuilder modelBuilder)
        {
            modelBuilder
                 .Entity<Medicament>()
                 .HasKey(m => m.MedicamentId);

            modelBuilder
               .Entity<Medicament>()
               .Property(m => m.Name)
               .HasMaxLength(50)
               .IsUnicode()
               .IsRequired();
        }

        private void ConfDiagoseEntity(ModelBuilder modelBuilder)
        {
            modelBuilder
                 .Entity<Diagnose>()
                 .HasKey(d => d.DiagnoseId);

            modelBuilder
                 .Entity<Diagnose>()
                 .Property(d => d.Name)
                 .HasMaxLength(50)
                 .IsUnicode()
                 .IsRequired();

            modelBuilder
                 .Entity<Diagnose>()
                 .Property(d => d.Comments)
                 .HasMaxLength(250)
                 .IsUnicode()
                 .IsRequired();


        }

        private void ConfVisitaionEntity(ModelBuilder modelBuilder)
        {
            modelBuilder
                 .Entity<Visitation>()
                 .HasKey(v => v.VisitationId);

            modelBuilder
                .Entity<Visitation>()
                .Property(v => v.Comments)
                .HasMaxLength(250)
                .IsUnicode()
                .IsRequired();
        }

        private void ConfPatientEntity(ModelBuilder modelBuilder)
        {
            modelBuilder
                 .Entity<Patient>()
                 .HasKey(p => p.PatientId);

            modelBuilder
                .Entity<Patient>()
                .HasMany(p => p.Visitations)
                .WithOne(p => p.Patient);


            modelBuilder
                .Entity<Patient>()
                .HasMany(p => p.Diagnoses)
                .WithOne(p => p.Patient);


            modelBuilder
               .Entity<Patient>()
               .Property(p => p.FirstName)
               .HasMaxLength(50)
               .IsUnicode()
               .IsRequired();

            modelBuilder
               .Entity<Patient>()
               .Property(p => p.LastName)
               .HasMaxLength(50)
               .IsUnicode()
               .IsRequired();

            modelBuilder
            .Entity<Patient>()
            .Property(p => p.Address)
            .HasMaxLength(250)
            .IsUnicode()
            .IsRequired();

            modelBuilder
            .Entity<Patient>()
            .Property(p => p.Email)
            .HasMaxLength(80);
        }
    }
}
