using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EmployeeDetails.Data;
using EmployeeDetails.Models;

namespace EmployeeDetails.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DetailsController : ControllerBase
    {
        private readonly EmployeeDetailsContext _context;

        public DetailsController(EmployeeDetailsContext context)
        {
            _context = context;
        }

        // GET: api/Details
        [HttpGet]
        public async Task<ActionResult<IEnumerable<employee>>> Getemployee()
        {
          if (_context.employee == null)
          {
              return NotFound();
          }
            return await _context.employee.ToListAsync();
        }

        // GET: api/Details/5
        [HttpGet("{id}")]
        public async Task<ActionResult<employee>> Getemployee(int id)
        {
          if (_context.employee == null)
          {
              return NotFound();
          }
            var employee = await _context.employee.FindAsync(id);

            if (employee == null)
            {
                return NotFound();
            }

            return employee;
        }

        // PUT: api/Details/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Putemployee(int id,[FromBody] employee employee)
        {
            if (id != employee.employeeID)
            {
                return BadRequest();
            }

            _context.Entry(employee).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!employeeExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Details
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<employee>> Postemployee([FromBody] employee employee)
        {
          if (_context.employee == null)
          {
              return Problem("Entity set 'EmployeeDetailsContext.employee'  is null.");
          }
            _context.employee.Add(employee);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getemployee", new { id = employee.employeeID }, employee);
        }

        // DELETE: api/Details/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deleteemployee(int id)
        {
            if (_context.employee == null)
            {
                return NotFound();
            }
            var employee = await _context.employee.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }

            _context.employee.Remove(employee);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool employeeExists(int id)
        {
            return (_context.employee?.Any(e => e.employeeID == id)).GetValueOrDefault();
        }
    }
}
