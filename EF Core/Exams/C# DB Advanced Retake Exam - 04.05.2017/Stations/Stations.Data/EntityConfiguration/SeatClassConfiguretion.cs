namespace Stations.Data.EntityConfiguration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Stations.Models.Models;
    internal class SeatClassConfiguretion : IEntityTypeConfiguration<SeatClass>
    {
        public void Configure(EntityTypeBuilder<SeatClass> builder)
        {
            builder
               .HasAlternateKey(e => e.Name);
        }
    }
}
