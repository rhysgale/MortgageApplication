using BankContext;
using Models.Request;
using Models.Response;
using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace BusinessLogic
{
    public class UserService : IUserService
    {
        private readonly BankDbContext _context;

        public UserService(BankDbContext context)
        {
            _context = context;
        }

        public NewUserResponse NewUser(NewUserRequest request)
        {
            var id = UserExists(request.Email);

            if (id == null)
            {
                var val = ValidateUser(request);
                if (val != null)
                    return new NewUserResponse()
                    {
                        ErrorMessage = val
                    };

                id = Guid.NewGuid();

                var entity = new Users()
                {
                    DateOfBirth = request.DateOfBirth,
                    Email = request.Email,
                    FirstName = request.FirstName,
                    LastName = request.LastName,
                    Id = id.Value
                };

                _context.Users.Add(entity);
                _context.SaveChanges();
            }

            return new NewUserResponse()
            {
                NewUserId = id.Value
            };
        }

        private string ValidateUser(NewUserRequest model)
        {
            var reg = new Regex(@"^\S+@\S+$");

            if (!reg.Match(model.Email).Success)
                return "Invalid Email";

            return null;
        }

        private Guid? UserExists(string emailAddress)
        {
            return _context.Users.FirstOrDefault(x => x.Email == emailAddress)?.Id;
        }
    }
}
