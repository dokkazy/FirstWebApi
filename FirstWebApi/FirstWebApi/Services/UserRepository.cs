using FirstWebApi.Data;
using FirstWebApi.Models;
using FirstWebApi.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FirstWebApi.Services
{
    public class UserRepository : IUserRepository
    {
        private readonly MyDbContext _context;
        public UserRepository(MyDbContext context)
        {
            _context = context;
        }
        public User Validate(Login login)
        {
            var user = _context.Users
                .AsNoTracking().SingleOrDefault(x => x.Username == login.Username && x.Password == login.Password);
#pragma warning disable CS8603 // Possible null reference return.
            return (user != null) ? user : null;
#pragma warning restore CS8603 // Possible null reference return.

        }
    }
}
