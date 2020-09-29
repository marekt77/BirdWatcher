using BirdWatcherBackend.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using Pomelo.EntityFrameworkCore.MySql.Internal;
using Pomelo.EntityFrameworkCore.MySql.Storage;
using System;

namespace BirdWatcherBackend
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
            services
                .AddControllers()
                .SetCompatibilityVersion(CompatibilityVersion.Version_3_0);

            //services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_3_0);

            services.AddDbContext<BirdWatcherContext>(options =>
                //MySQL Context
                options.UseMySql(Configuration.GetSection("ConnectionStrings:devMySQLConnection").Value,
                MySqlOptions =>
                    MySqlOptions.ServerVersion(new ServerVersion(new Version(10, 1, 44), ServerType.MariaDb)))
                //Using Postgre instead of MySQL
                //options.UseNpgsql(Configuration.GetSection("ConnectionStrings:devPostgreConnection").Value
                //North:
                //options.UseNpgsql(Configuration.GetSection("ConnectionStrings:wisPostgreConnection").Value
            );
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, BirdWatcherContext context)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseStaticFiles();
            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
