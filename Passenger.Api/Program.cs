using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Passenger.ApplicationServices;
using Passenger.DataAccess;
using Passenger.DataAccess.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

string connectionString = builder.Configuration.GetConnectionString("Default");

builder.Services.AddDbContext<PassengerDataContext>(options =>
options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString))
);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "My Api", Version = "v1" });
});

builder.Services.AddTransient<IPassengerAppService, PassengerAppService>();

builder.Services.AddTransient<IRepository<int, Passenger.Core.Entities.Passenger>, Repository<int, Passenger.Core.Entities.Passenger>>();

builder.Services.AddAutoMapper(typeof(MapperPassenger));

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
