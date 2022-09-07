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

        //// PUT: api/UserLogin/5
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutUserTable(int id, UserTable userTable)
        //{
        //    if (id != userTable.UserId)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(userTable).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!UserTableExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        // POST: api/UserLogin
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Route("Register")]
        public async Task<ActionResult<UserTable>> PostUserTable(UserTable userTable)
        {
          if (_context.UserTables == null)
          {
              return Problem("Entity set 'ProjectDBContext.UserTables'  is null.");
          }
            _context.UserTables.Add(userTable);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUserTable", new { id = userTable.UserId }, userTable);
        }

        ////// DELETE: api/UserLogin/5
        ////[HttpDelete("{id}")]
        ////public async Task<IActionResult> DeleteUserTable(int id)
        ////{
        ////    if (_context.UserTables == null)
        ////    {
        ////        return NotFound();
        ////    }
        ////    var userTable = await _context.UserTables.FindAsync(id);
        ////    if (userTable == null)
        ////    {
        ////        return NotFound();
        ////    }

        ////    _context.UserTables.Remove(userTable);
        ////    await _context.SaveChangesAsync();

        ////    return NoContent();
        ////}

        private bool UserTableExists(int id)
        {
            return (_context.UserTables?.Any(e => e.UserId == id)).GetValueOrDefault();
        }
    }
}
