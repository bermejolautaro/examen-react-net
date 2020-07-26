using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExamenReactNet.Core.Models;
using ExamenReactNet.Core.Repositories;
using ExamenReactNet.Core.Services;
using ExamenReactNet.Data;
using ExamenReactNet.Data.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace ExamenReactNet.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddScoped<DbContext, ExamenReactNetDbContext>();
            services.AddScoped<ICarService, CarService>();
            services.AddScoped<IRepository<Car>, CarRepository>();

            services.AddDbContext<ExamenReactNetDbContext>(options =>
            {
                options.UseSqlServer(
                    Configuration.GetConnectionString("Default"),
                    o => o.MigrationsAssembly("ExamenReactNet.Data")
                );
            });

            services.AddCors();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseCors(options => options.AllowAnyOrigin()
                                          .AllowAnyMethod()
                                          .AllowAnyHeader());
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

        }
    }
}
