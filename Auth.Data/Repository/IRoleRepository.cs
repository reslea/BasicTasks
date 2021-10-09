using System;
using System.Collections.Generic;
using System.Text;

namespace Auth.Data.Repository
{
    public interface IRoleRepository
    {
        Role Get(string title);
    }
}
