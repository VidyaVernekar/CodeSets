using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPIWithDBFirst.Models;

namespace WebAPIWithDBFirst.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyDetailsController : ControllerBase
    {
        private readonly CompanyDetailsContext _context;

        public CompanyDetailsController(CompanyDetailsContext context)
        {
            _context = context;
        }

        // GET: api/CompanyDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CompanyDetail>>> GetCompanyDetails()
        {
          if (_context.CompanyDetails == null)
          {
              return NotFound();
          }
            return await _context.CompanyDetails.ToListAsync();
        }

        // GET: api/CompanyDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CompanyDetail>> GetCompanyDetail(int id)
        {
          if (_context.CompanyDetails == null)
          {
              return NotFound();
          }
            var companyDetail = await _context.CompanyDetails.FindAsync(id);

            if (companyDetail == null)
            {
                return NotFound();
            }

            return companyDetail;
        }

        // PUT: api/CompanyDetails/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCompanyDetail(int id,[FromBody] CompanyDetail companyDetail)
        {
            if (id != companyDetail.Id)
            {
                return BadRequest();
            }

            _context.Entry(companyDetail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CompanyDetailExists(id))
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

        // POST: api/CompanyDetails
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CompanyDetail>> PostCompanyDetail([FromBody] CompanyDetail companyDetail)
        {
            if (_context.CompanyDetails == null)
            {
                return Problem("Entity set 'CompanyDetailsContext.CompanyDetails'  is null.");
            }
            _context.CompanyDetails.Add(companyDetail);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (CompanyDetailExists(companyDetail.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetCompanyDetail", new { id = companyDetail.Id }, companyDetail);
        }

        // DELETE: api/CompanyDetails/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCompanyDetail(int id)
        {
            if (_context.CompanyDetails == null)
            {
                return NotFound();
            }
            var companyDetail = await _context.CompanyDetails.FindAsync(id);
            if (companyDetail == null)
            {
                return NotFound();
            }

            _context.CompanyDetails.Remove(companyDetail);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CompanyDetailExists(int id)
        {
            return (_context.CompanyDetails?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
