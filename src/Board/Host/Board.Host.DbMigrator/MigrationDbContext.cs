using Board.Infrastucture.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Board.Host.DbMigrator
{
    /// <summary>
    /// Контест БД для мигратора.
    /// </summary>
    public class MigrationDbContext : BoardDbContext
    {
        public MigrationDbContext(Microsoft.EntityFrameworkCore.DbContextOptions options) : base(options)
        {
        }
    }
}
