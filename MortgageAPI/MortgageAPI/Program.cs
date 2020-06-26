using BankContext;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace MortgageAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateWebHostBuilder(args).Build();

            //Populate the in memory database with data on startup...
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;

                var ctx = services.GetRequiredService<BankDbContext>();

                DataGenerator.Initialise(services);
            }

            host.Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
