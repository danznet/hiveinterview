using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using hive_interview.Data;
using hive_interview.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace hive_interview
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
            // Add functionality to inject IOptions<T>
            services.AddOptions();

            // Add our Config object so it can be injected
            var configSection = Configuration.GetSection("Config");
            services.Configure<ConfigModel>(configSection);

            services.AddControllersWithViews();

            services.AddDbContext<HiveInterviewContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("HiveInterviewContext")));

            // Ideally you would use a factory here to determine which repo to use
            // This could be based off a config setting, for instance: DB, JsonFile, TestData
            //services.AddScoped<ILocationRepository, LocationTestRepository>();
            //services.AddScoped<ILocationRepository, LocationJsonRepository>();
            services.AddScoped<ILocationRepository, LocationSqlRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
