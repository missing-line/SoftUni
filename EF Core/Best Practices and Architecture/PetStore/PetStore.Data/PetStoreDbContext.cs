namespace PetStore.Data
{
    using Microsoft.EntityFrameworkCore;
    using PetStore.Data.Configurations;
    using PetStore.Models;

    public class PetStoreDbContext : DbContext
    {
        public PetStoreDbContext() { }

        public PetStoreDbContext(DbContextOptions options)
            : base(options) { }

        public DbSet<Brand> Brands { get; set; }
        public DbSet<Breed> Breeds { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Food> Foods { get; set; }
        public DbSet<FoodOrder> FoodOrders { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Pet> Pets { get; set; }
        public DbSet<Toy> Toys { get; set; }
        public DbSet<ToyOrder> ToyOrders { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            if (!builder.IsConfigured)
            {
                builder.UseSqlServer(ConnectionURL.Connection);
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);

            //builder.ApplyConfiguration(new BrandConfiguration());
            //builder.ApplyConfiguration(new BreedConfiguration());
            //builder.ApplyConfiguration(new CategoryConfiguration());
            //builder.ApplyConfiguration(new FoodOrderConfiguration());
            //builder.ApplyConfiguration(new OrderConfiguration());
            //builder.ApplyConfiguration(new ToyOrderConfiguration());
            //builder.ApplyConfiguration(new UserConfiguration());         
        }
    }
}
