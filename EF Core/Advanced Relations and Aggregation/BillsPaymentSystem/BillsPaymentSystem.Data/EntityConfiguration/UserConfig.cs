namespace BillsPaymentSystem.Data.EntityConfiguration
{
    using BillsPaymentSystem.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    public class UserConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(e => e.UserId);

            builder.Property(p => p.FirstName)
                .HasMaxLength(50)             
                .IsUnicode(true)
                .IsRequired();

            builder.Property(p => p.LastName)
               .HasMaxLength(50)
               .IsUnicode(true)
               .IsRequired();

            builder.Property(p => p.Email)
               .HasMaxLength(80)
               .IsUnicode(false)
               .IsRequired();

            builder.Property(p => p.Password)
               .HasMaxLength(25)
               .IsUnicode(false)
               .IsRequired();
        }
    }
}
