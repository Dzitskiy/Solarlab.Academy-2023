using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Board.Infrastucture.DataAccess.Contexts.Advert.Configuration
{
    using Advert = Domain.Adverts.Advert;

    /// <summary>
    /// Конфигурация сущности объявления.
    /// </summary>
    public class AdvertConfiguration : IEntityTypeConfiguration<Advert>
    {
        public void Configure(EntityTypeBuilder<Advert> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Name).HasMaxLength(256).IsRequired();
            builder.Property(a => a.Description).HasMaxLength(1024).IsRequired();
            builder.Property(a => a.Price).IsRequired(false);
            builder.Property(a => a.ImageUrl).HasMaxLength(250).IsRequired(false);
            builder.Property(a => a.Address).HasMaxLength(250).IsRequired();
            builder.Property(a => a.Created).HasConversion(s => s, s => DateTime.SpecifyKind(s, DateTimeKind.Utc));
        }
    }
}
