using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPIProjectApplication.Models;

namespace WebAPIProjectApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class UserLoginController : ControllerBase
    {
        private readonly ProjectDBContext _context;

        public UserLoginController(ProjectDBContext context)
        {
            _context = context;
        }

        // GET: api/UserLogin
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserTable>>> GetUserTables()
        {
            if (_context.UserTables == null)
            {
                return NotFound();
            }
            return await _context.UserTables.ToListAsync();
        }

        // GET: api/UserLogin/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserTable>> GetUserTable(int id)
        {
            if (_context.UserTables == null)
            {
                return NotFound();
            }
            var userTable = await _context.UserTables.FindAsync(id);

            if (userTable == null)
            {
                return NotFound();
            }

            return userTable;
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] UserTable userTable)
        {
          if (_context.UserTables == null)
          {
              return Problem("Entity set 'ProjectDBContext.UserTables' is null.");
          }
          else if (UserEmailExists(userTable.EmailId,userTable.UserName))
            {
                return Problem("Already Exists");
            }
            _context.UserTables.Add(userTable);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUserTable", new { id = userTable.UserId }, userTable);
        }

        private bool UserTableExists(int id)
        {
            return (_context.UserTables?.Any(e => e.UserId == id)).GetValueOrDefault();
        }
        private bool UserEmailExists(string email,string username)
        {
            return (_context.UserTables?.Any(e => e.EmailId == email || e.UserName == username)).GetValueOrDefault();
        }
    }
}
