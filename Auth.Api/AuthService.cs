using Auth.Api.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Auth.Data;
using Auth.Data.Repository;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;

namespace Auth.Api
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly IRoleRepository _roleRepository;
        private readonly AuthDbContext _context;
        private readonly RNGCryptoServiceProvider _cryptoServiceProvider;

        public AuthService(
            IUserRepository userRepository,
            IRoleRepository roleRepository,
            AuthDbContext context,
            RNGCryptoServiceProvider cryptoServiceProvider)
        {
            _userRepository = userRepository;
            _roleRepository = roleRepository;
            _context = context;
            _cryptoServiceProvider = cryptoServiceProvider;
        }

        public User Authenticate(LoginModel model)
        {
            var user = _userRepository.Get(model.Username);

            var hashedPassword = GetHashedPassword(model.Password, user.Salt);

            return hashedPassword.Equals(user.HashedPassword) 
                ? user 
                : null;
        }

        public List<Claim> CreateClaims(User model)
        {
            var usualClaims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, model.Id.ToString(), ClaimValueTypes.Integer),
                new Claim(ClaimTypes.Name, model.Username)
            };

            var permissions = model.Roles
                .SelectMany(r => r.Permissions)
                .Distinct()
                .Select(p => new Claim("permissions", p.PermissionTypeId.ToString()));

            return usualClaims.Concat(permissions).ToList();
        }

        public ClaimsPrincipal CreatePrincipal(User model, string authScheme)
        {
            var claims = CreateClaims(model);

            var identity = new ClaimsIdentity(claims, authScheme);

            return new ClaimsPrincipal(identity);
        }

        public string CreateJwt(List<Claim> claims, string signingKey)
        {
            var now = DateTime.Now;

            var jwt = new JwtSecurityToken(
                notBefore: now,
                expires: now.AddDays(365),
                claims: claims,
                signingCredentials: new SigningCredentials(
                    new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes(signingKey)),
                    SecurityAlgorithms.HmacSha256)
                );

            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);
            return encodedJwt;
        }

        public User Register(RegistrationModel model, string asRole)
        {
            var userRole = _roleRepository.Get(asRole);

            var salt = new byte[512 / 8];
            _cryptoServiceProvider.GetNonZeroBytes(salt);

            var hashedPass = GetHashedPassword(model.Password, salt);

            var user = new User
            {
                Username = model.Username,
                Email =  model.Email,
                Salt = salt,
                HashedPassword = hashedPass,
                Roles = new List<Role> { userRole }
            };

            _userRepository.Add(user);
            _context.SaveChanges();

            return user;
        }

        private static string GetHashedPassword(string password, byte[] salt)
        {
            return Convert.ToBase64String(
                KeyDerivation.Pbkdf2(
                    password,
                    salt,
                    KeyDerivationPrf.HMACSHA512,
                    100_000,
                    1024 / 8));
        }
    }
}
