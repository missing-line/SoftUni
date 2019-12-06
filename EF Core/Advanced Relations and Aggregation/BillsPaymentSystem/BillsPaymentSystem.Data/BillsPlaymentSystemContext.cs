namespace BillsPaymentSystem.Data
{
    using System;
    using BillsPaymentSystem.Data.EntityConfiguration;
    using BillsPaymentSystem.Models;
    using Microsoft.EntityFrameworkCore;
    public class BillsPlaymentSystemContext : DbContext
    {
        public BillsPlaymentSystemContext() { }
        public BillsPlaymentSystemContext(DbContextOptions options)
            :base() {}

       
        public DbSet<User> Users { get; set; }
        public DbSet<BankAccount> BankAccounts { get; set; }
        public DbSet<CreditCard> CreditCards { get; set; }

        public string FirstOrDefault(Func<object, object> p)
        {
            throw new NotImplementedException();
        }

        public DbSet<PaymentMethod> PaymentMethods { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Config.Connection);
            }
           
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfig());
            modelBuilder.ApplyConfiguration(new PaymentMethodConfig());
            modelBuilder.ApplyConfiguration(new BankAccountConfig());
            modelBuilder.ApplyConfiguration(new CreditCardConfig());

            //base.OnModelCreating(modelBuilder);
        }
    }
}
