namespace TeisterMask.Data
{
    using Microsoft.EntityFrameworkCore;
    using TeisterMask.Data.Models;

    public class TeisterMaskContext : DbContext
    {
        public TeisterMaskContext() { }

        public TeisterMaskContext(DbContextOptions options)
            : base(options) { }


        public DbSet<Employee> Employees { get; set; }
        public DbSet<EmployeeTask> EmployeesTasks { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Task> Tasks { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseSqlServer(Configuration.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder model)
        {
            model.Entity<EmployeeTask>()
                .HasKey(e => new { e.EmployeeId, e.TaskId });

            model.Entity<EmployeeTask>()
                .HasOne(e => e.Employee)
                .WithMany(e => e.EmployeesTasks)
                .HasForeignKey(e => e.EmployeeId);


            model.Entity<EmployeeTask>()
                .HasOne(e => e.Task)
                .WithMany(e => e.EmployeesTasks)
                .HasForeignKey(e => e.TaskId);
                
        }
    }
}