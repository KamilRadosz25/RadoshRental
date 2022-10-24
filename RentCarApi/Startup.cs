using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using RentCarApi.Entities;
using RentCarApi.Middleware;
using RentCarApi.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace RentCarApi
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
            services.AddDbContext<RentalDbContext>();
            services.AddControllers();
            services.AddScoped<RentalSeeder>();
            services.AddAutoMapper(this.GetType().Assembly);
            services.AddScoped<IPackageService, PackageService>();
            services.AddScoped<IRentalService, RentalService>();
            services.AddScoped<ICarService, CarService>();
            services.AddScoped<ErrorHandlingMiddleware>();
           

        }


        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, RentalSeeder seeder)
        {
            seeder.Seed();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseMiddleware<ErrorHandlingMiddleware>();

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
