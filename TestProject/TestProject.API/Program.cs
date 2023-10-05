using Microsoft.EntityFrameworkCore;
using TestProject.API.Hosting;
using TestProject.DataAccess;

var builder = WebApplication.CreateBuilder(args);

var connectionString = Environment.GetEnvironmentVariable("PRODUCTION_DB_CONNECTION_STRING");

if (connectionString is null)
{
    connectionString = builder.Configuration.GetConnectionString(nameof(ApplicationDbContext));
}

// Add services to the container.

builder.Services.AddDbContext<ApplicationDbContext>(
    o => o.UseSqlServer(connectionString)
);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

await app.MigrateDatabase<ApplicationDbContext>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
