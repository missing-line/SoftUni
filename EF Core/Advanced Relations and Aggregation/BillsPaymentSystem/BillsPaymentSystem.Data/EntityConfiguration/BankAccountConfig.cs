namespace BillsPaymentSystem.Data.EntityConfiguration
{
    using BillsPaymentSystem.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class BankAccountConfig : IEntityTypeConfiguration<BankAccount>
    {
        public void Configure(EntityTypeBuilder<BankAccount> builder)
        {
            builder.HasKey(k => k.BankAccountId);

            builder.Property(p => p.BankName)
                .HasMaxLength(50)
                .IsUnicode(true)
                .IsRequired();

            builder.Property(p => p.SWIFT)
               .HasMaxLength(20)
               .IsUnicode(false)
               .IsRequired();
        }

    }
}
