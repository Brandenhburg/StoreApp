using Bookstore.Data.Contexts;
using Bookstore.API.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using AutoMapper;
using System;

namespace Bookstore.API
{
    public class Startup
    {
        private readonly IConfiguration config;

        public Startup(IConfiguration config)
        {
            this.config = config;
        }

        public void ConfigureServices(IServiceCollection services)
        {

            services.AddDbContext<BookStoreDbContext>(options =>
            {
                options.UseSqlServer(config["ConnectionStrings:BookStoreConnection"]);
            });

            services.AddTransient<ILibraryRepository, LibraryRepository>();

            services.AddControllers(mvcOptions => 
            {
                mvcOptions.ReturnHttpNotAcceptable = true;
                mvcOptions.OutputFormatters.Add(new XmlDataContractSerializerOutputFormatter());
            });


            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler(appBuilder =>
                {
                    appBuilder.Run(async context =>
                    {
                        context.Response.StatusCode = 500;
                        await context.Response.WriteAsync("An unexpected fault happened, Try again later...");
                    });
                });

            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
