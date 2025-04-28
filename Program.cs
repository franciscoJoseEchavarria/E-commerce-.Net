using Microsoft.EntityFrameworkCore;
using NuevoProyecto.API.Data;
using NuevoProyecto.API.Interface;
using NuevoProyecto.API.IServices;
using NuevoProyecto.API.Models;
using NuevoProyecto.API.Repository;
using NuevoProyecto.API.Services;
using NuevoProyecto.API.Application.Mappings;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container
// Registrar AutoMapper con los perfiles de la capa Application
builder.Services.AddAutoMapper(typeof(UserProfile)); // Asegúrate de usar el namespace correcto
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Title = "E-commerce API",
        Version = "v1",
        Description = "An e-commerce API for learning purposes"
    });
});

// PostgreSQL configuration
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
    
// Register repositories
builder.Services.AddScoped<IRepository<Users>, UserRepository>();

// Register services
builder.Services.AddScoped<IUserService, UserServices>();

// Make sure controllers are registered
builder.Services.AddControllers();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins",
        builder => builder.AllowAnyOrigin()
                          .AllowAnyMethod()
                          .AllowAnyHeader());
});

var app = builder.Build();

// Now you can use app
app.UseCors("AllowAllOrigins");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "E-commerce API v1"));
}

app.UseHttpsRedirection();
app.MapControllers();

// Keep your existing WeatherForecast endpoint for now
var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", () =>
{
    var forecast =  Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();
    return forecast;
})
.WithName("GetWeatherForecast")
.WithOpenApi();

app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}