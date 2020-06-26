using BankContext;
using Models.Dto;
using Models.Request;
using Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLogic
{
    public class ProductService
    {
        private readonly BankDbContext _context;

        public ProductService(BankDbContext context)
        {
            _context = context;
        }

        public ElegibleProductsResponse GetProducts(ElegibleProductsRequest request)
        {
            //Check we are of age... or return nothing
            if (!ValidateRequest(request))
                return new ElegibleProductsResponse()
                {
                    BanksWithProducts = new List<BankDTO>()
                };



            return new ElegibleProductsResponse()
            {

            };
        }

        private bool ValidateRequest(ElegibleProductsRequest request)
        {
            var user = _context.Users.FirstOrDefault(x => x.Id == request.UserId);

            // Save today's date.
            var today = DateTime.UtcNow;
            // Calculate the age.
            var age = today.Year - user.DateOfBirth.Year;
            // Go back to the year the person was born in case of a leap year
            if (user.DateOfBirth.Date > today.AddYears(-age)) age--;

            var lowestLTVProduct = _context.Products.OrderByDescending(x => x.MaximumLTV).First();
            if (Helpers.Helpers.CalculateLoanToValue(request.Deposit, request.HouseValue) > lowestLTVProduct)
                return false;

            return age > 17;
        }
    }
}
