using System.Collections.Generic;
using System.Text;

namespace Auth.Data.Repository
{
    public interface IUserRepository
    {
        void Add(User user);
        User Get(string username);
    }
}
