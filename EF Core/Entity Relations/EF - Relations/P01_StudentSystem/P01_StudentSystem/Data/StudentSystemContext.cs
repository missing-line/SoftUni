namespace P01_StudentSystem.Data
{
    using Microsoft.EntityFrameworkCore;
    using P01_StudentSystem.Data.Models;

    public class StudentSystemContext : DbContext
    {
        public StudentSystemContext() { }
        public StudentSystemContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Homework> HomeworkSubmissions { get; set; }
        public DbSet<Resource> Resources { get; set; }
        public DbSet<StudentCourse> StudentCourses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Config.Connection);
            }

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            OnModelCreatingStudent(modelBuilder);

            OnModelCreatingCourse(modelBuilder);

            OnModelCreatingResources(modelBuilder);

            OnModelCreatingHomework(modelBuilder);

            OnModelCreatingStudentCourse(modelBuilder);
        }

        private void OnModelCreatingStudentCourse(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StudentCourse>(entity =>
            {
                entity.HasKey(e => new { e.StudentId, e.CourseId });

                entity.HasOne(e => e.Student)
                .WithMany(e => e.CourseEnrollments)
                .HasForeignKey(e => e.StudentId);

                entity.HasOne(e => e.Course)
                .WithMany(e => e.StudentsEnrolled)
                .HasForeignKey(e => e.CourseId);

            });
        }

        private void OnModelCreatingHomework(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Homework>(entity =>
            {
                entity.HasKey(e => e.HomeworkId);

                entity.Property(e => e.Content)
                .IsRequired();


                entity.HasOne(e => e.Student)
                .WithMany(e => e.HomeworkSubmissions);

                entity.HasOne(e => e.Course)
                .WithMany(e => e.HomeworkSubmissions);

            });
        }

        private static void OnModelCreatingResources(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Resource>(entity =>
            {
                entity.HasKey(e => e.ResourceId);

                entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(true)
                .IsRequired();

                entity.Property(e => e.Url)
                .IsRequired();

                entity.HasOne(e => e.Course)
                .WithMany(e => e.Resources);

            });
        }

        private static void OnModelCreatingCourse(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>(entity =>
            {
                entity.HasKey(e => e.CourseId);

                entity.Property(e => e.Name)
                .HasMaxLength(80)
                .IsRequired()
                .IsUnicode();

                entity.Property(e => e.Description)
                .IsUnicode();

            });
        }

        private static void OnModelCreatingStudent(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>(entity =>
            {
                entity.HasKey(e => e.StudentId);

                entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsRequired()
                .IsUnicode();

                entity.Property(e => e.PhoneNumber)
                .HasColumnType("CHAR(10)");
            });
        }
    }
}
