using System.Collections.Generic;

namespace Auth.Data
{
    public class Permission
    {
        public PermissionType PermissionTypeId { get; set; }

        public string Title { get; set; }

        public ICollection<Role> Roles { get; set; }
    }
}