using BankContext.Plumbing;
using Microsoft.Extensions.DependencyInjection;

namespace BusinessLogic.Plumbing
{
    public static class ServicesInstaller
    {
        public static void InstallServices(this IServiceCollection services)
        {
            //Install the BankContext db context... install it here so the main api cannot access the DB context
            services.InstallDbContext();
        }
    }
}
