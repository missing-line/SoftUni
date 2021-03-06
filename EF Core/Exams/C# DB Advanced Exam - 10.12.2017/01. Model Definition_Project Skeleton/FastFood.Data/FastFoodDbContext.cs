﻿namespace FastFood.Data
{
    using FastFood.Models;
    using Microsoft.EntityFrameworkCore;

    public class FastFoodDbContext : DbContext
    {
        public FastFoodDbContext() { }

        public FastFoodDbContext(DbContextOptions options)
            : base(options) { }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Position> Positions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            if (!builder.IsConfigured)
            {
                builder.UseSqlServer(Configuration.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {

            builder.Entity<Position>()
                .HasAlternateKey(p => p.Name);

            builder.Entity<Item>()
            .HasAlternateKey(p => p.Name);

            builder.Entity<OrderItem>()
                .HasKey(e => new { e.ItemId, e.OrderId });

            builder.Entity<Order>()
                .HasMany(e => e.OrderItems)
                .WithOne(e => e.Order)
                .HasForeignKey(e => e.OrderId);

            builder.Entity<Item>()
               .HasMany(e => e.OrderItems)
               .WithOne(e => e.Item)
               .HasForeignKey(e => e.ItemId);
        }
    }
}