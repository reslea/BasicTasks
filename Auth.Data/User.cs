using System.Collections.Generic;

namespace Auth.Data
{
    public class User
    {
        public int Id { get; set; }

        public string Email { get; set; }

        public string Username { get; set; }

        public byte[] Salt { get; set; }

        public string HashedPassword { get; set; }

        public ICollection<Role> Roles { get; set; }
    }
}