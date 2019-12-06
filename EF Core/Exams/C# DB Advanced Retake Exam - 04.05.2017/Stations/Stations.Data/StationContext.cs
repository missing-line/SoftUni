namespace Stations.Data
{
    using Microsoft.EntityFrameworkCore;
    using Stations.Data.EntityConfiguration;
    using Stations.Models.Models;

    public class StationContext : DbContext
    {
        public StationContext() { }

        public StationContext(DbContextOptions options)
            : base(options) { }

        public DbSet<Train> Trains { get; set; }
        public DbSet<CustomerCard> CustomerCards { get; set; }
        public DbSet<Trip> Trips { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Station> Stations { get; set; }
        public DbSet<SeatClass> SeatClasses { get; set; }
        public DbSet<TrainSeat> TrainSeats { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Configuration.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new TrainConfiguration());

            modelBuilder.ApplyConfiguration(new TripConfiguration());

            modelBuilder.ApplyConfiguration(new TrainSeatConfiguration());

            modelBuilder.ApplyConfiguration(new SeatClassConfiguretion());

            modelBuilder.ApplyConfiguration(new StationConfiguration());

            modelBuilder.ApplyConfiguration(new TicketConfiguration());       
        }
    }
}
