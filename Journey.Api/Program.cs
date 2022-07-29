using Journey.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Journey.ApplicationServices;
using Journey.DataAccess.Repositories;
using Journey.Core.Entities;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "My Api", Version = "v1" });
});

string connectionString = builder.Configuration.GetConnectionString("Default");

builder.Services.AddDbContext<JourneyDataContext>(options =>
options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString))
);

builder.Services.AddTransient<IJourneyAppService, JourneyAppService>();

builder.Services.AddTransient<IRepository<int, Jorney>, Repository<int, Jorney>>();

builder.Services.AddAutoMapper(typeof(Journey.ApplicationServices.MapperJourney));

var app = builder.Build();

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
