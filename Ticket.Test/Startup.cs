using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Reflection;
using Ticket.ApplicationServices;
using Ticket.ApplicationServices.Journies;
using Ticket.ApplicationServices.Passenger;
using Ticket.ApplicationServices.Ticket;
using Ticket.DataAccess;
using Ticket.DataAccess.Repositories;

namespace Ticket.Test
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers().AddApplicationPart(Assembly.Load("Ticket.Api")).AddControllersAsServices();
            string connectionString = Configuration.GetConnectionString("Development");
            services.AddDbContext<TicketDataContext>(options =>
            options.UseInMemoryDatabase("DataTest")
            );

            services.AddTransient<ITickerAppService, TicketAppService>();
            services.AddTransient<IJourneyAppService, JourneyAppService>();
            services.AddTransient<IPassengerAppService, PassengerAppService>();
            services.AddTransient<IRepository<int, Ticket.Core.Entities.Ticket>, Repository<int, Ticket.Core.Entities.Ticket>>();
            services.AddAutoMapper(typeof(MapperTicket));
            services.AddHttpClient("journey", client =>
            {
                client.BaseAddress = new Uri(Configuration["AppSettings:JourneyUrlBase"]);
            }).ConfigurePrimaryHttpMessageHandler((c) =>
                new HttpClientHandler()
                {
                    ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; }
                });

            services.AddHttpClient("passenger", client =>
            {
                client.BaseAddress = new Uri(Configuration["AppSettings:PassengerUrlBase"]);
            }).ConfigurePrimaryHttpMessageHandler((c) =>
                new HttpClientHandler()
                {
                    ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; }
                });
        }


        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseExceptionHandler("/error-development");
            }
            else
            {
                app.UseExceptionHandler("/error");
            }
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
