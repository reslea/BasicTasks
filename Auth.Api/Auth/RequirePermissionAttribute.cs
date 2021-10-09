using System;
using System.Linq;
using Auth.Api.Models;
using Auth.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Auth.Api.Auth
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class)]
    public class RequirePermissionAttribute : TypeFilterAttribute
    {
        public RequirePermissionAttribute(params PermissionType[] permissions) : base(typeof(PermissionFilter))
        {
            Arguments = new object[] { permissions };
        }
    }

    public class PermissionFilter : IAuthorizationFilter
    {
        private readonly PermissionType[] _permissions;

        public PermissionFilter(PermissionType[] permissions)
        {
            _permissions = permissions;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var user = context.HttpContext.User;

            var hasExtendedPermissions =
                _permissions.All(p =>
                    user.HasClaim("permissions", p.ToString()));

            if (!hasExtendedPermissions)
            {
                context.Result = new ForbidResult();
            }
        }
    }
}
