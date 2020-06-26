using Microsoft.AspNetCore.Mvc;
using Models.Response;

namespace MortgageAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        [HttpPost("EligibleProducts")]
        public EligibleProductsResponse ElegibleProducts()
        {
            throw new System.Exception("Not implemented");
        }
    }
}
