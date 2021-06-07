using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using StoreApp.Data;
using StoreApp.Data.Repository;
using StoreApp.Models;
using StoreApp.Services;
using System;
using Microsoft.AspNetCore.Mvc.Razor;

namespace StoreApp
{
    public class Startup
    {
        private IConfiguration configuration;

        public Startup(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            
            services.AddDbContext<StoreDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("StoreConnection"));
            });
            services.AddDbContext<AppUSerDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("IdentityConnection"));
            });
            services.AddIdentity<AppUser, IdentityRole>().AddEntityFrameworkStores<AppUSerDbContext>();



            services.AddTransient<IStoreRepository, StoreRepository>();

            services.AddControllersWithViews().AddRazorRuntimeCompilation();
            services.AddRazorPages().AddRazorRuntimeCompilation();
        }

        
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, StoreDbContext ctx)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                StoreSeeder.SeedData(ctx);
            }

            app.UseStaticFiles();


            app.UseRouting();


            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(cfg =>
            {
                cfg.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action}/{id?}");
                cfg.MapRazorPages();               
            });
        }
    }
}
