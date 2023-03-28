using Board.Application.AppData.Contexts.Adverts.Services;
using Board.Application.AppData.Services;
using Board.Contracts.Advert;
using Board.Contracts.Interfaces;
using Board.Infrastucture.DataAccess;
using Board.Infrastucture.DataAccess.Interfaces;
using Board.Infrastucture.Repository;
using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Добавляем DbContext
builder.Services.AddSingleton<IDbContextOptionsConfigurator<BoardDbContext>, BoardDbContextConfiguration>();
        
builder.Services.AddDbContext<BoardDbContext>((Action<IServiceProvider, DbContextOptionsBuilder>)
    ((sp, dbOptions) => sp.GetRequiredService<IDbContextOptionsConfigurator<BoardDbContext>>()
        .Configure((DbContextOptionsBuilder<BoardDbContext>)dbOptions)));

builder.Services.AddScoped((Func<IServiceProvider, DbContext>) (sp => sp.GetRequiredService<BoardDbContext>()));

builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

// Add services to the container.
builder.Services.AddScoped<IAdvertService, AdvertService>();
builder.Services.AddScoped<IForbiddenWordsService, ForbiddenWordsService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo { Title = "Advert Api", Version = "V1" });
    options.IncludeXmlComments(Path.Combine(Path.Combine(AppContext.BaseDirectory,
        $"{typeof(CreateAdvertDto).Assembly.GetName().Name}.xml")));
    options.IncludeXmlComments(Path.Combine(Path.Combine(AppContext.BaseDirectory, "Documentation.xml")));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment() || app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHsts();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();