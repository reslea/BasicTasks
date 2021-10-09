using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Auth.Data.Repository
{
    public class RoleRepository : IRoleRepository
    {
        private readonly AuthDbContext _context;

        public RoleRepository(AuthDbContext context)
        {
            _context = context;
        }

        public Role Get(string title)
        {
            return _context.Roles
                .Include(r => r.Permissions)
                .FirstOrDefault(r => r.Title == title);
        }
    }
}