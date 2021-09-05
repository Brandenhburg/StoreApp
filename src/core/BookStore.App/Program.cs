using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace Bookstore.App
{
    public class Program
    {
        
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            host.Run();          
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(configure =>
                {
                    configure.UseStartup<Startup>();
                });
    }
}
