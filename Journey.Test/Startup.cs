
using Journey.ApplicationServices;
using Journey.Core.Entities;
using Journey.DataAccess;
using Journey.DataAccess.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Reflection;

namespace Journey.Test
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
            services.AddControllers().AddApplicationPart(Assembly.Load("Journey.Api")).AddControllersAsServices();
            string connectionString = Configuration.GetConnectionString("Development");
            services.AddDbContext<JourneyDataContext>(options =>
            options.UseInMemoryDatabase("DataTest")
            );
            services.AddTransient<IJourneyAppService, JourneyAppService>();
            services.AddTransient<IRepository<int, Jorney>, Repository<int, Jorney>>();
            services.AddAutoMapper(typeof(Journey.ApplicationServices.MapperJourney));
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
