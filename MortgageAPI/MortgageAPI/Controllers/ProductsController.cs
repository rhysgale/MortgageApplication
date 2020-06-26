using BusinessLogic;
using Microsoft.AspNetCore.Mvc;
using Models.Request;
using Models.Response;

namespace MortgageAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpPost("EligibleProducts")]
        public EligibleProductsResponse EligibleProducts(EligibleProductsRequest request)
        {
            return _productService.GetProducts(request);
        }
    }
}
