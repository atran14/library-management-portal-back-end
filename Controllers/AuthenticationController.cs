using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using back_end.DatabaseContexts;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using back_end.Models;
using Microsoft.AspNetCore.Authorization;

namespace back_end.Controllers
{
    [AllowAnonymous]
    [Route("/api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        LibraryContext _context;
        public AuthenticationController(LibraryContext context)
        {
            _context = context;
        }

        [HttpPost]
        [Route("/login")]
        public async Task<ActionResult<UserResponse>> Login([FromBody] LoginViewModel loginUser)
        {
            var username = loginUser.Username;
            var password = loginUser.Password;

            if (username == null || password == null)
            {
                return Unauthorized("Missing username/password");
            }

            var user = await _context.User
                .Where(u => u.Username == username && u.Password == password)
                .FirstOrDefaultAsync();

            if (user == null)
            {
                return Unauthorized("Either username or password is wrong");
            }

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Username),
                new Claim("FullName", $"{user.FirstName} {user.LastName}"),
                new Claim(ClaimTypes.Role, user.Role.ToString())
            };

            var claimsIdentity = new ClaimsIdentity(
                claims, CookieAuthenticationDefaults.AuthenticationScheme);

            var authProperties = new AuthenticationProperties
            {
                AllowRefresh = true,
                ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(10),
                IssuedUtc = DateTimeOffset.UtcNow,
                IsPersistent = true
            };

            await HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity),
                    authProperties);

            var userResponse = new LoggedInUserResponse
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                DOB = user.DOB,
                Role = user.Role.ToString()
            };
            return Ok(userResponse);
        }

        [HttpPut]
        [Route("/logout")]
        public async Task Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        }
    }
}