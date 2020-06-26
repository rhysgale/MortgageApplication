using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace BankContext
{
    public class DataGenerator
    {
        /// <summary>
        /// Just a temp class that populates the "Database". Rather than setting up one locally using SQL Server... for simplicities sake
        /// </summary>
        /// <param name="serviceProvider"></param>
        public static void Initialise(IServiceProvider serviceProvider)
        {
            using var context = new BankDbContext(serviceProvider.GetRequiredService<DbContextOptions<BankDbContext>>());
            
            if (context.Banks.Any())
                return;

            SetupBanks(context);
        }

        private static void SetupBanks(BankDbContext ctx)
        {
            var bank = new Bank()
            {
                Id = Guid.NewGuid(),
                BankName = "Bank1",
                Address1 = "1 High Street",
                Address2 = "Long Eaton",
                Address3 = "Nottinghamshire",
                PostCode = "NG103WT"
            };
            var bank2 = new Bank()
            {
                Id = Guid.NewGuid(),
                BankName = "Bank2",
                Address1 = "2 High Street",
                Address2 = "Long Eaton",
                Address3 = "Nottinghamshire",
                PostCode = "NG103WT"
            };
            var bank3 = new Bank()
            {
                Id = Guid.NewGuid(),
                BankName = "Bank3",
                Address1 = "3 High Street",
                Address2 = "Long Eaton",
                Address3 = "Nottinghamshire",
                PostCode = "NG103WT"
            };

            var product = new Product()
            {
                Id = Guid.NewGuid(),
                BankId = bank.Id,
                InterestRate = 2,
                Type = MortgageType.Variable,
                MaximumLTV = 0.6
            };

            var product2 = new Product()
            {
                Id = Guid.NewGuid(),
                BankId = bank2.Id,
                InterestRate = 3,
                Type = MortgageType.Fixed,
                MaximumLTV = 0.6
            };

            var product3 = new Product()
            {
                Id = Guid.NewGuid(),
                BankId = bank3.Id,
                InterestRate = 4,
                Type = MortgageType.Variable,
                MaximumLTV = 0.9
            };

            ctx.Banks.Add(bank);
            ctx.Banks.Add(bank2);
            ctx.Banks.Add(bank3);
            ctx.Products.Add(product);
            ctx.Products.Add(product2);
            ctx.Products.Add(product3);
        }
    }
}
