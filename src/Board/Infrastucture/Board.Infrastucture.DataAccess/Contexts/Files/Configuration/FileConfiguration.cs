using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Board.Infrastucture.DataAccess.Contexts.Files.Configuration
{
    /// <summary>
    /// Конфигурация сущности Файла.
    /// </summary>
    public class FileConfiguration : IEntityTypeConfiguration<Domain.Files.File>
    {
        /// <inheritdoc/>
        public void Configure(EntityTypeBuilder<Domain.Files.File> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Name).HasMaxLength(256).IsRequired();
            builder.Property(a => a.ContentType).HasMaxLength(256).IsRequired();
            builder.Property(a => a.Created).HasConversion(s => s, s => DateTime.SpecifyKind(s, DateTimeKind.Utc));
        }
    }
}
