using Auth.Api.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Auth.Data;

namespace Auth.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthTokenController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly IConfiguration _configuration;

        public AuthTokenController(IAuthService authService, IConfiguration configuration)
        {
            _authService = authService;
            _configuration = configuration;
        }

        [HttpPost("register")]
        public IActionResult Register(RegistrationModel model)
        {
            User user = _authService.Register(model, "Usual");

            var claims = _authService.CreateClaims(user);
            string encodedJwt = _authService.CreateJwt(claims, _configuration["SigningKey"]);

            return Ok(new { Token = encodedJwt });
        }

        [HttpPost("login")]
        public IActionResult Login(LoginModel model)
        {
            var user = _authService.Authenticate(model);
            if (user is null)
            {
                return Unauthorized();
            }

            var claims = _authService.CreateClaims(user);
            string encodedJwt = _authService.CreateJwt(claims, _configuration["SigningKey"]);

            return Ok(new { Token = encodedJwt });
        }
    }
}
