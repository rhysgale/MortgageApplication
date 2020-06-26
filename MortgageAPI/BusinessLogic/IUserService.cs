using Models.Request;
using Models.Response;

namespace BusinessLogic
{
    public interface IUserService
    {
        NewUserResponse NewUser(NewUserRequest request);
    }
}