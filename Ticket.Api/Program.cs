using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Ticket.ApplicationServices;
using Ticket.ApplicationServices.Journies;
using Ticket.ApplicationServices.Passenger;
using Ticket.ApplicationServices.Ticket;
using Ticket.DataAccess;
using Ticket.DataAccess.Repositories;

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

builder.Services.AddDbContext<TicketDataContext>(options =>
options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString))
);

builder.Services.AddTransient<ITickerAppService, TicketAppService>();
builder.Services.AddTransient<IJourneyAppService, JourneyAppService>();
builder.Services.AddTransient<IPassengerAppService, PassengerAppService>();

builder.Services.AddTransient<IRepository<int, Ticket.Core.Entities.Ticket>, Repository<int, Ticket.Core.Entities.Ticket>>();

builder.Services.AddAutoMapper(typeof(MapperTicket));

builder.Services.AddHttpClient("journey", client =>
{
    client.BaseAddress = new Uri(builder.Configuration["AppSettings:JourneyUrlBase"]);
}).ConfigurePrimaryHttpMessageHandler((c)=>
    new HttpClientHandler()
    {
        ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; }
    });

builder.Services.AddHttpClient("passenger", client =>
{
    client.BaseAddress = new Uri(builder.Configuration["AppSettings:PassengerUrlBase"]);
}).ConfigurePrimaryHttpMessageHandler((c) =>
    new HttpClientHandler()
    {
        ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; }
    });

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
