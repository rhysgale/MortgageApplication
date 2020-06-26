using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Models.Request;
using Models.Response;
using Newtonsoft.Json;

namespace MortgageApplication.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ApiController : ControllerBase
    {

        [HttpPost("NewUser")]
        public async Task<NewUserResponse> NewUser(NewUserRequest request)
        {
            using var httpClient = new HttpClient();

            StringContent content = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json");

            using var response = await httpClient.PostAsync("https://localhost:44396/user/newuser", content);
            
            string apiResponse = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<NewUserResponse>(apiResponse);
        }

        [HttpPost("GetEligibleProducts")]
        public async Task<EligibleProductsResponse> GetEligibleProducts(EligibleProductsRequest request)
        {
            using var httpClient = new HttpClient();
            
            StringContent content = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json");

            using var response = await httpClient.PostAsync("https://localhost:44396/Products/EligibleProducts", content);
            
            string apiResponse = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<EligibleProductsResponse>(apiResponse);
        }
    }
}
