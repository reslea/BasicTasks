using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Auth.Api.Auth;
using Auth.Api.Models;
using Auth.Data;

namespace Auth.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthTestController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            var userIdentity = HttpContext.User.Identity;
            if (userIdentity.IsAuthenticated)
            {
                return Ok(userIdentity.Name);
            }
            return Unauthorized();
        }

        [HttpGet("extended")]
        [RequirePermission(PermissionType.AccessExtended)]
        public IActionResult GetExtended()
        {
            return Ok();
        }
    }
}
