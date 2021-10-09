using Auth.Api.Models;
using System.Collections.Generic;
using System.Security.Claims;
using Auth.Data;

namespace Auth.Api
{
    public interface IAuthService
    {
        User Authenticate(LoginModel model);
        ClaimsPrincipal CreatePrincipal(User model, string authScheme);
        List<Claim> CreateClaims(User user);
        string CreateJwt(List<Claim> claims, string signingKey);
        User Register(RegistrationModel model, string asRole);
    }
}