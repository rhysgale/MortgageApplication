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

        public NewUserResponse NewUserResponse(NewUserRequest request)
        {
            var id = UserExists(request.Email) ?? Guid.NewGuid();

            if (id == null)
            {
                var entity = new Users()
                {
                    DateOfBirth = request.DateOfBirth,
                    Email = request.Email,
                    FirstName = request.FirstName,
                    LastName = request.LastName,
                    Id = id
                };

                _context.Users.Add(entity);
                _context.SaveChanges();
            }

            return new NewUserResponse()
            {
                NewUserId = id
            };
        }

        private Guid? UserExists(string emailAddress)
        {
            return _context.Users.FirstOrDefault(x => x.Email == emailAddress).Id;
        }
    }
}
