using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Bookstore.App.Services;
using Bookstore.App.Repository;
using Bookstore.Data.Contexts;
using Bookstore.Domain.Entities;

namespace Bookstore.App
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
            
            services.AddDbContext<BookStoreDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("BookStoreConnection"));
            });
            services.AddDbContext<AppUserDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("IdentityConnection"));
            });


            services.AddIdentity<AppUser, IdentityRole>().AddEntityFrameworkStores<AppUserDbContext>();
            services.ConfigureIdentityOptions();



            services.AddTransient<IStoreRepository, StoreRepository>();



            services.AddControllersWithViews().AddRazorRuntimeCompilation();
            services.AddRazorPages().AddRazorRuntimeCompilation();
        }

        
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, BookStoreDbContext ctx)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                StoreSeeder.SeedData(ctx);
            }

            app.UseStatusCodePages();

            app.UseStaticFiles();
            app.UseRouting();


            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(cfg =>
            {
                cfg.MapDefaultControllerRoute();
                cfg.MapRazorPages();               
            });
        }
    }
}
