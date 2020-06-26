using BankContext;
using Models.Request;
using Models.Response;
using System;
using System.Linq;

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

        private Guid? UserExists(string emailAddress)
        {
            return _context.Users.FirstOrDefault(x => x.Email == emailAddress)?.Id;
        }
    }
}
