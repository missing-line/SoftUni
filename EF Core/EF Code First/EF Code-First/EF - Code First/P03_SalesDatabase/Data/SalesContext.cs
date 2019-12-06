namespace P03_SalesDatabase.Data
{   
    using Microsoft.EntityFrameworkCore;
    using P03_SalesDatabase.Data.Models;

    public class SalesContext : DbContext
    {
        public SalesContext() { }

        public SalesContext(DbContextOptions options)
            : base(options) { }

        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Store> Stores { get; set; }
        public DbSet<Sale> Sales { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Config.connecttion);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            ConfinProductModel(modelBuilder);

            ConfinSaleModel(modelBuilder);

            ConfinCustomerModel(modelBuilder);

            ConfinStoreModel(modelBuilder);
        }

        private void ConfinStoreModel(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Store>()
               .HasKey(s => s.StoreId);


            modelBuilder.Entity<Store>()
              .Property(s => s.Name)
              .HasMaxLength(80)
              .IsUnicode();

            modelBuilder.Entity<Store>()
                .HasMany(s => s.Sales)
                .WithOne(s => s.Store);

             
        }

        private void ConfinCustomerModel(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>()
                .HasKey(c => c.CustomerId);

            modelBuilder.Entity<Customer>()
              .Property(c => c.Name)
              .HasMaxLength(100)
              .IsRequired()
              .IsUnicode();


            modelBuilder.Entity<Customer>()
             .Property(c => c.Email)
             .IsUnicode(false)
             .HasMaxLength(80);                  
           

            modelBuilder.Entity<Customer>()
                .HasMany(c => c.Sales)
                .WithOne(p => p.Customer);
        }

        private void ConfinSaleModel(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Sale>()
                .HasKey(s => s.SaleId);

            modelBuilder.Entity<Sale>()
                .Property(p => p.Date)
                .HasDefaultValueSql("GETDATE()");
                
        }

        private void ConfinProductModel(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .HasKey(p => p.ProductId);

            modelBuilder.Entity<Product>()
                .Property(p => p.Name)
                .HasMaxLength(50)            
                .IsUnicode();

            modelBuilder.Entity<Product>()
                .Property(p => p.Description)
                .HasMaxLength(250)
                .HasDefaultValue("No description");

            modelBuilder.Entity<Product>()
                .HasMany(p => p.Sales)
                .WithOne(p => p.Product);
        }
    }
}
