using Board.Domain.Account;
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
    public class AccountConfiguration : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Name).HasMaxLength(256).IsRequired();
            builder.Property(a => a.Login).HasMaxLength(50).IsRequired();
            builder.Property(a => a.Password).HasMaxLength(50).IsRequired();
            builder.Property(a => a.Created).HasConversion(s => s, s => DateTime.SpecifyKind(s, DateTimeKind.Utc));
        }
    }
}
