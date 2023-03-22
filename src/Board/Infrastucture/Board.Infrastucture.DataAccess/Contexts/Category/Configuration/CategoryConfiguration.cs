using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Board.Infrastucture.DataAccess.Contexts.Category.Configuration
{
    /// <summary>
    /// Конфигурация сущности категории.
    /// </summary>
    public class CategoryConfiguration : IEntityTypeConfiguration<Domain.Categories.Category>
    {
        public void Configure(EntityTypeBuilder<Domain.Categories.Category> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Name).HasMaxLength(256).IsRequired();
            builder.Property(a => a.Created).HasConversion(s => s, s => DateTime.SpecifyKind(s, DateTimeKind.Utc));

            builder.HasMany(s => s.Adverts).WithOne(s => s.Category).HasForeignKey(c => c.CategoryId).IsRequired().OnDelete(DeleteBehavior.Cascade);
        }
    }
}
