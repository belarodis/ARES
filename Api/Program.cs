using Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<ARESDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<Api.Services.Interfaces.ILaboratorioService, Api.Services.Implementations.LaboratorioService>();
builder.Services.AddScoped<Api.Services.Interfaces.IReservaLaboratorioService, Api.Services.Implementations.ReservaLaboratorioService>();
builder.Services.AddScoped<Api.Services.Interfaces.INotebookService, Api.Services.Implementations.NotebookService>();
builder.Services.AddScoped<Api.Services.Interfaces.IReservaNotebookService, Api.Services.Implementations.ReservaNotebookService>();
builder.Services.AddScoped<Api.Services.Interfaces.IFuncionarioService, Api.Services.Implementations.FuncionarioService>();
builder.Services.AddScoped<Api.Services.Interfaces.ISalaService, Api.Services.Implementations.SalaService>();
builder.Services.AddScoped<Api.Services.Interfaces.IReservaSalaService, Api.Services.Implementations.ReservaSalaService>();
builder.Services.AddScoped<Api.Services.Interfaces.IStatusService, Api.Services.Implementations.StatusService>();

builder.Services.AddScoped<Data.Repositories.Interfaces.ILaboratorioRepository, Data.Repositories.Implementations.LaboratorioRepository>();
builder.Services.AddScoped<Data.Repositories.Interfaces.IReservaLaboratorioRepository, Data.Repositories.Implementations.ReservaLaboratorioRepository>();
builder.Services.AddScoped<Data.Repositories.Interfaces.INotebookRepository, Data.Repositories.Implementations.NotebookRepository>();
builder.Services.AddScoped<Data.Repositories.Interfaces.IReservaNotebookRepository, Data.Repositories.Implementations.ReservaNotebookRepository>();
builder.Services.AddScoped<Data.Repositories.Interfaces.IFuncionarioRepository, Data.Repositories.Implementations.FuncionarioRepository>();
builder.Services.AddScoped<Data.Repositories.Interfaces.ISalaRepository, Data.Repositories.Implementations.SalaRepository>();
builder.Services.AddScoped<Data.Repositories.Interfaces.IReservaSalaRepository, Data.Repositories.Implementations.ReservaSalaRepository>();



builder.Services.AddOpenApi();

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

//permitindo q o front consuma a api
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.WithOrigins("http://localhost:4200") // frontend
                                .AllowAnyHeader()
                                .AllowAnyMethod();
                      });
});

var app = builder.Build();
app.UseCors(MyAllowSpecificOrigins);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

// Map controllers
app.MapControllers();

// (Opcional) Endpoint de exemplo pode ser mantido ou removido
var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", () =>
{
    var forecast = Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();
    return forecast;
})
.WithName("GetWeatherForecast");

app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
