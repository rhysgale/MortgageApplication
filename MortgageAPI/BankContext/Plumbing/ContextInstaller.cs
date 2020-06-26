using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace BankContext.Plumbing
{
    public static class ContextInstaller
    {
        public static void InstallDbContext(this IServiceCollection services)
        {
            services.AddDbContext<BankDbContext>(options => options.UseInMemoryDatabase("BankDatabase"));
        }
    }
}
