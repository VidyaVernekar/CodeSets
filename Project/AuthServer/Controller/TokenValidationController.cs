using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AuthServer.Models;

namespace AuthServer.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenValidationController : ControllerBase
    {
        private readonly ProjectDBContext _context;
        public IConfiguration _configuration;
        public TokenValidationController(ProjectDBContext context,IConfiguration config)
        {
            _configuration = config;
            _context = context;
        }
        [HttpPost]
        public async Task<ActionResult> Post(UserTable _userData)
        {
            if (_userData != null && _userData.EmailId != null && _userData.Password != null)
            {
                var user = await GetUser(_userData.EmailId, _userData.Password);

                if (user != null)
                {
                    //create claims details based on the user information
                    var claims = new[] {
                        new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                        new Claim("UserId", user.UserId.ToString()),
                        new Claim("DisplayName", user.FirstName),
                        new Claim("UserName", user.UserName),
                        new Claim("Email", user.EmailId)
                    };

                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
                    var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                    var token = new JwtSecurityToken(
                        _configuration["Jwt:Issuer"],
                        _configuration["Jwt:Audience"],
                        claims,
                        expires: DateTime.UtcNow.AddMinutes(10),
                        signingCredentials: signIn);

                    return Ok(new JwtSecurityTokenHandler().WriteToken(token));
                }
                else
                {
                    return BadRequest("Invalid credentials");
                }
            }
            else
            {
                return BadRequest();
            }
        }

        private async Task<UserTable> GetUser(string email, string password)
        {
            return await _context.UserTables.FirstOrDefaultAsync(u => u.EmailId == email && u.Password == password);
        }

        
    }
}
