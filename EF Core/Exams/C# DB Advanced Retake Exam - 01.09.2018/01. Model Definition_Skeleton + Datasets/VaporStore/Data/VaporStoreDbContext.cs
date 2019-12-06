﻿namespace VaporStore.Data
{
    using Microsoft.EntityFrameworkCore;
    using VaporStore.Data.Models;

    public class VaporStoreDbContext : DbContext
    {
        public VaporStoreDbContext() { }

        public VaporStoreDbContext(DbContextOptions options)
            : base(options) { }


        public DbSet<GameTag> GameTags { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<Developer> Developers { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Card> Cards { get; set; }
        public DbSet<Purchase> Purchases { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            if (!options.IsConfigured)
            {
                options
                    .UseSqlServer(Configuration.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder model)
        {
            model.Entity<GameTag>()
                 .HasKey(gt => new { gt.GameId, gt.TagId });

            model.Entity<Game>()
                .HasMany(g => g.GameTags)
                .WithOne(gt => gt.Game)
                .HasForeignKey(gt => gt.GameId);

            model.Entity<Tag>()
                .HasMany(g => g.GameTags)
                .WithOne(gt => gt.Tag)
                .HasForeignKey(gt => gt.TagId);
        }
    }
}