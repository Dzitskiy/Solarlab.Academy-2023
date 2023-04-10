using Board.Infrastucture.DataAccess;
using Board.Infrastucture.DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Board.Api.Tests
{
    public class TestBoardDbContextConfiguration : IDbContextOptionsConfigurator<BoardDbContext>
    {
        public const string InMemoryDatabaseName = "BoardDb";

        private readonly ILoggerFactory _loggerFactory;

        public TestBoardDbContextConfiguration(ILoggerFactory loggerFactory)
        {
            _loggerFactory = loggerFactory;
        }

        public void Configure(DbContextOptionsBuilder<BoardDbContext> options)
        {
            options.UseInMemoryDatabase(InMemoryDatabaseName);
            options.UseLoggerFactory(_loggerFactory);
            options.EnableSensitiveDataLogging();
        }
    }
}