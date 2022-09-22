﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CreateAndSearchBook.Models;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace CreateAndSearchBook.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PurchasesController : ControllerBase
    {
        private readonly ProjectDBContext _context;

        public PurchasesController(ProjectDBContext context)
        {
            _context = context;
        }

        // GET: api/Purchases
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Purchase>>> GetPurchases()
        {
          if (_context.Purchases == null)
          {
              return NotFound();
          }
            return await _context.Purchases.ToListAsync();
        }

        // GET: api/Purchases/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Purchase>> GetPurchase(int id)
        {
          if (_context.Purchases == null)
          {
              return NotFound();
          }
            var purchase = await _context.Purchases.FindAsync(id);

            if (purchase == null)
            {
                return NotFound();
            }

            return purchase;
        }

        // PUT: api/Purchases/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPurchase(int id, Purchase purchase)
        {
            if (id != purchase.PurchaseId)
            {
                return BadRequest();
            }

            _context.Entry(purchase).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PurchaseExists(id))
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

        // POST: api/Purchases
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<IActionResult> PostPurchase([FromBody] Purchase purchase)
        {
           // Purchase purchase = Purch.;
          if (_context.Purchases == null)
          {
              return Problem("Entity set 'ProjectDBContext.Purchases'  is null.");
          }
           _context.Purchases.Add(purchase);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPurchase", new { id = purchase.PurchaseId }, purchase);
        }
        // DELETE: api/Purchases/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePurchase(int id)
        {
            if (_context.Purchases == null)
            {
                return NotFound();
            }
            var purchase = await _context.Purchases.FindAsync(id);
            if (purchase == null)
            {
                return NotFound();
            }

            _context.Purchases.Remove(purchase);
            await _context.SaveChangesAsync();

            return NoContent();
        }
        // GET: api/Purchases
        [HttpGet]
        [Route("GetPurchaseHistory")]
        public async Task<ActionResult<IEnumerable<Purchase>>> GetPurchasesData(string emailID)
        {
            if (_context.Purchases == null)
            {
                return NotFound();
            }
            var query = await (from n in _context.Books
                               join p in _context.Purchases on n.BookId equals p.BookId
                               join c in _context.UserTables on n.UserId equals c.UserId
                               where p.EmailId == emailID
                               select new
                               {
                                   n.BookId,
                                   n.BookName,
                                   n.CategoryId,
                                   n.Price,
                                   n.Publisher,
                                   n.PublishedDate,
                                   n.Content,
                                   n.Active,
                                   p.EmailId,
                                   p.PurchaseDate,
                                   p.PaymentMode,
                                   c.UserName
                               }).ToListAsync();
            return Ok(query);
        }
        private bool PurchaseExists(int id)
        {
            return (_context.Purchases?.Any(e => e.PurchaseId == id)).GetValueOrDefault();
        }
    }
}
