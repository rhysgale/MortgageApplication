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

        [HttpPost("NewUser")]
        public NewUserResponse NewUser(NewUserRequest request)
        {
            try
            {
                return _userService.NewUser(request);
            }
            catch (System.Exception)
            {
                return new NewUserResponse()
                {
                    ErrorMessage = "Api Error"
                };
            }
        }
    }
}
