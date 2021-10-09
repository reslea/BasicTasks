using System.Collections.Generic;

namespace Auth.Data
{
    public class Role
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public ICollection<Permission> Permissions { get; set; }

        public ICollection<User> Users { get; set; }
    }
}