namespace P03_FootballBetting.Data
{
    using Microsoft.EntityFrameworkCore;
    using P03_FootballBetting.Data.Models;

    public class FootballBettingContext : DbContext
    {
        public FootballBettingContext() { }

        public FootballBettingContext(DbContextOptions options)
        : base(options) { }

        public DbSet<Team> Teams { get; set; }
        public DbSet<Town> Towns { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<Bet> Bets { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<PlayerStatistic> PlayerStatistics { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Config.Connection);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            OnModelCreatingTeam(modelBuilder);

            OnModelCreatingTown(modelBuilder);

            OnModelCreatingPlayer(modelBuilder);

            OnModelCreatingCountry(modelBuilder);

            OnModelCreatingColor(modelBuilder);

            OnModelCreatingUser(modelBuilder);

            OnModelCreatingBet(modelBuilder);

            OnModelCreatingPosition(modelBuilder);

            OnModelCreatingGame(modelBuilder);

            OnModelCreatingPlayerStatistic(modelBuilder);

        }

        private void OnModelCreatingPlayerStatistic(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PlayerStatistic>(entity =>
            {
                entity.HasKey(e => new { e.GameId, e.PlayerId });

                entity.HasOne(e => e.Game)
                      .WithMany(g => g.PlayerStatistics)
                      .HasForeignKey(e => e.GameId);

                entity.HasOne(e => e.Player)
                    .WithMany(p => p.PlayerStatistics)
                    .HasForeignKey(e => e.PlayerId);

            });
        }

        private void OnModelCreatingGame(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Game>(entity =>
            {
                entity.HasKey(e => e.GameId);

                entity.HasOne(e => e.HomeTeam)
                    .WithMany(e => e.HomeGames)
                    .HasForeignKey(e => e.HomeTeamId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(e => e.AwayTeam)
                   .WithMany(e => e.AwayGames)
                   .HasForeignKey(e => e.AwayTeamId)
                   .OnDelete(DeleteBehavior.Restrict);

            });
        }

        private void OnModelCreatingPosition(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Position>(entity =>
            {
                entity.HasKey(e => e.PositionId);
            });
        }

        private void OnModelCreatingBet(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Bet>(entity =>
            {
                entity.HasKey(e => e.BetId);

                entity.HasOne(e => e.Game)
                .WithMany(e => e.Bets)
                .HasForeignKey(e => e.GameId);

                entity.HasOne(e => e.User)
                .WithMany(e => e.Bets)
                .HasForeignKey(e => e.UserId);

            });
        }

        private void OnModelCreatingUser(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.UserId);
            });
        }

        private void OnModelCreatingColor(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Color>(entity =>
            {
                entity.HasKey(e => e.ColorId);
            });
        }

        private void OnModelCreatingCountry(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Country>(entity =>
            {
                entity.HasKey(e => e.CountryId);
            });
        }

        private void OnModelCreatingPlayer(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Player>(entity =>
            {
                entity.HasKey(e => e.PlayerId);

                entity.HasOne(e => e.Position)
                .WithMany(e => e.Players)
                .HasForeignKey(e => e.PositionId);

                entity.HasOne(e => e.Team)
               .WithMany(e => e.Players)
               .HasForeignKey(e => e.TeamId);
            });
        }

        private void OnModelCreatingTown(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Town>(entity =>
            {
                entity.HasKey(e => e.TownId);

                entity.HasOne(e => e.Country)
                .WithMany(e => e.Towns)
                .HasForeignKey(e => e.CountryId);
            });
        }

        private static void OnModelCreatingTeam(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Team>(entity =>
            {
                entity.HasKey(e => e.TeamId);

                entity.HasOne(e => e.PrimaryKitColor)
                .WithMany(e => e.PrimaryKitTeams)
                .HasForeignKey(e => e.PrimaryKitColorId);

                entity.HasOne(e => e.SecondaryKitColor)
              .WithMany(e => e.SecondaryKitTeams)
              .HasForeignKey(e => e.SecondaryKitColorId)
              .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(e => e.Town)
               .WithMany(t => t.Teams)
               .HasForeignKey(e => e.TownId)
               .OnDelete(DeleteBehavior.Restrict);

            });
        }
    }
}
