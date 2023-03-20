using Board.Infrastucture.DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
namespace Board.Infrastucture.DataAccess;

public class BoardDbContextConfiguration : IDbContextOptionsConfigurator<BoardDbContext>
{
    
    private const string PostgesConnectionStringName = "PostgresBoardDb";
    
    private readonly IConfiguration _configuration;
    private readonly ILoggerFactory _loggerFactory;

    public BoardDbContextConfiguration(IConfiguration configuration, ILoggerFactory loggerFactory)
    {
        _configuration = configuration;
        _loggerFactory = loggerFactory;
    }

    public void Configure(DbContextOptionsBuilder<BoardDbContext> options)
    {
        var connectionString = _configuration.GetConnectionString(PostgesConnectionStringName);
        if (string.IsNullOrWhiteSpace(connectionString))
        {
            throw new InvalidOperationException(
                $"Не найдена строка подключения с именем '{PostgesConnectionStringName}'");
        }
        options.UseNpgsql(connectionString);
        options.UseLoggerFactory(_loggerFactory);
    }
}