namespace BookShop.Data
{
    using BookShop.Data.Models;
    using Microsoft.EntityFrameworkCore;

    public class BookShopContext : DbContext
    {
        public BookShopContext() { }

        public BookShopContext(DbContextOptions options)
            : base(options) { }


        public DbSet<Author> Authors  { get; set; }
        public DbSet<AuthorBook> AuthorsBooks  { get; set; }
        public DbSet<Book> Books  { get; set; }
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
            model.Entity<AuthorBook>()
                .HasKey(e => new { e.AuthorId, e.BookId });


            model.Entity<AuthorBook>()
                .HasOne(e => e.Author)
                .WithMany(e => e.AuthorsBooks)
                .HasForeignKey(e => e.AuthorId);

            model.Entity<AuthorBook>()
               .HasOne(e => e.Book)
               .WithMany(e => e.AuthorsBooks)
               .HasForeignKey(e => e.BookId);
        }
    }
}