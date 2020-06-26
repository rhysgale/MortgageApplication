using BusinessLogic;
using Microsoft.AspNetCore.Mvc;
using Models.Request;
using Models.Response;

namespace MortgageAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("EligibleProducts")]
        public NewUserResponse NewUser(NewUserRequest request)
        {
            return _userService.NewUser(request);
        }
    }
}
