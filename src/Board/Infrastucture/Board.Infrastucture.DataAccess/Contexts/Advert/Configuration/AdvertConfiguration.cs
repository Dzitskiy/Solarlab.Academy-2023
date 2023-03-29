using Board.Domain.Adverts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Board.Infrastucture.DataAccess.Contexts.Posts.Configuration
{
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
            builder.Property(a => a.Created).HasConversion(s => s, s => DateTime.SpecifyKind(s, DateTimeKind.Utc));
        }
    }
}
