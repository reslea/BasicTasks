using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Auth.Data.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly AuthDbContext _context;

        public UserRepository(AuthDbContext context)
        {
            _context = context;
        }

        public User Get(string username)
        {
            return _context.Users
                .Include(u => u.Roles)
                .ThenInclude(r => r.Permissions)
                .FirstOrDefault(u =>
                    u.Username.Equals(username));
        }

        public void Add(User user)
        {
            _context.Users.Add(user);
        }
    }
}