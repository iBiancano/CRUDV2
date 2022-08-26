using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Passenger.ApplicationServices;
using Passenger.DataAccess;
using Passenger.DataAccess.Repositories;
using System.Reflection;
namespace Passenger.Test
{
    public  class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers().AddApplicationPart(Assembly.Load("Passenger.Api")).AddControllersAsServices();
            string connectionString = Configuration.GetConnectionString("Development");
            services.AddDbContext<PassengerDataContext>(options =>
            options.UseInMemoryDatabase("DataTest")
            );
            services.AddTransient<IPassengerAppService, PassengerAppService>();
            services.AddTransient<IRepository<int, Passenger.Core.Entities.Passenger>, Repository<int, Passenger.Core.Entities.Passenger>>();
            services.AddAutoMapper(typeof(MapperPassenger));
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
