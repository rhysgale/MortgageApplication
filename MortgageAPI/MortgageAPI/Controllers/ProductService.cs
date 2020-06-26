using Microsoft.AspNetCore.Mvc;
using Models.Response;

namespace MortgageAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        [HttpPost("EligibleProducts")]
        public ElegibleProductsResponse ElegibleProducts()
        {
            throw new System.Exception("Not implemented");
        }
    }
}
