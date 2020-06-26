using BankContext;
using Models.Dto;
using Models.Request;
using Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace BusinessLogic
{
    public class ProductService : IProductService
    {
        private readonly BankDbContext _context;

        public ProductService(BankDbContext context)
        {
            _context = context;
        }

        public EligibleProductsResponse GetProducts(EligibleProductsRequest request)
        {
            //Check we are of age... or return nothing
            if (!ValidateRequest(request))
                return new EligibleProductsResponse()
                {
                    BanksWithProducts = new List<BankDTO>()
                };

            return new EligibleProductsResponse()
            {
                BanksWithProducts = GetBanksProductsForLTV(Helpers.Helpers.CalculateLoanToValue(request.Deposit, request.HouseValue))
            };
        }

        private List<BankDTO> GetBanksProductsForLTV(double ltv)
        {
            var eligibleBanks = _context.Products.Where(x => x.MaximumLTV > ltv).Select(x => x.BankId).Distinct();

            var banks = _context.Banks.Include(x => x.Products).Where(x => eligibleBanks.Contains(x.Id)).Select(x => new BankDTO()
            {
                AvailableProducts = x.Products.Select(y => new ProductDTO()
                {
                    InterestRate = y.InterestRate,
                    Type = y.Type
                }).ToList(),
                BankAddress = new AddressDTO()
                {
                    Address1 = x.Address1,
                    Address2 = x.Address2,
                    Address3 = x.Address3,
                    Address4 = x.Address4,
                    PostCode = x.PostCode
                },
                BankName = x.BankName
            });

            return banks.ToList();
        }

        private bool ValidateRequest(EligibleProductsRequest request)
        {
            var users = _context.Users.ToList();

            var user = _context.Users.FirstOrDefault(x => x.Id == request.UserId);

            // Save today's date.
            var today = DateTime.UtcNow;
            // Calculate the age.
            var age = today.Year - user.DateOfBirth.Year;
            // Go back to the year the person was born in case of a leap year
            if (user.DateOfBirth.Date > today.AddYears(-age)) age--;

            var lowestLTVProduct = _context.Products.OrderByDescending(x => x.MaximumLTV).FirstOrDefault();
            if (lowestLTVProduct == null || Helpers.Helpers.CalculateLoanToValue(request.Deposit, request.HouseValue) >= lowestLTVProduct.MaximumLTV)
                return false;

            return age > 17;
        }
    }
}
