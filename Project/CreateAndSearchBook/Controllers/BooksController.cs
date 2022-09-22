using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CreateAndSearchBook.Models;
using Microsoft.AspNetCore.Authorization;
using System.Reflection.Metadata;
using System.Security.Policy;

namespace CreateAndSearchBook.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly ProjectDBContext _context;

        public BooksController(ProjectDBContext context)
        {
            _context = context;
        }

        // GET: api/Books
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Book>>> GetBooks()
        {
          if (_context.Books == null)
          {
              return NotFound();
          }
            var query = await (from n in _context.Books
                               join c in _context.UserTables on n.UserId equals c.UserId

                               select new
                               {
                                   n.BookId,
                                   n.BookName,
                                   c.UserName,
                                   n.CategoryId,
                                   n.Price,
                                   n.Publisher,
                                   n.UserId,
                                   n.PublishedDate,
                                   n.Content,
                                   n.Active
                               }).ToListAsync();
            return Ok(query);
        }
        // GET: api/Books
        [HttpGet]
        [Route("GetBookswithAutor")]
        public async Task<ActionResult<IEnumerable<Book>>> GetBookswithAutor()
        {
            if (_context.Books == null)
            {
                return NotFound();
            }
            var query = await (from n in _context.Books
                               join c in _context.UserTables on n.UserId equals c.UserId where n.Active == "1"
                               select new
                               {
                                   n.BookId,
                                   n.BookName,
                                   c.UserName,
                                   n.CategoryId,
                                   n.Price,
                                   n.Publisher,
                                   n.UserId,
                                   n.PublishedDate,
                                   n.Content,
                                   n.Active
                               }).ToListAsync();
            return Ok(query);
        }
        // GET: api/Books/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Book>> GetBook(int id)
        {
          if (_context.Books == null)
          {
              return NotFound();
          }
            var query = await (from n in _context.Books
                               join c in _context.UserTables on n.UserId equals c.UserId

                               select new
                               {
                                   n.BookId,
                                   n.BookName,
                                   c.UserName,
                                   n.CategoryId,
                                   n.Price,
                                   n.Publisher,
                                   n.UserId,
                                   n.PublishedDate,
                                   n.Content,
                                   n.Active,
                                   n.CreatedDate,
                                   n.Createdby
                               }).ToListAsync();
            var book = query.Where(x => x.BookId == id);

            if (book == null)
            {
                return NotFound();
            }

            return Ok(book);
        }
        // GET: api/Books/5
        [HttpGet]
        [Route("SearchBook")]
        public async Task<ActionResult<IEnumerable<Book>>> SearchBook(int category,int autorID,decimal price)
        {
            if (_context.Books == null)
            {
                return NotFound();
            }
            ActionResult<IEnumerable<Book>> book = await _context.Books.Where(x => x.CategoryId == category && x.UserId == autorID && x.Price == price).ToListAsync();

            if (book == null)
            {
                return NotFound();
            }

            return book;
        }
        // PUT: api/Books/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBook(int id, Book book)
        {
            book.Modifiedby = book.UserId;
            book.ModifiedDate = DateTime.Now;
            if (id != book.BookId)
            {
                return BadRequest();
            }
            _context.Entry(book).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookExists(id))
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

        // POST: api/Books
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<IActionResult> PostBook([FromBody] Book book)
        {
          if (_context.Books == null)
          {
              return Problem("Entity set 'ProjectDBContext.Books'  is null.");
          }
            _context.Books.Add(book);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBook", new { id = book.BookId }, book);
        }

        // DELETE: api/Books/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            if (_context.Books == null)
            {
                return NotFound();
            }
            var book = await _context.Books.FindAsync(id);
            if (book == null)
            {
                return NotFound();
            }

            _context.Books.Remove(book);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BookExists(int id)
        {
            return (_context.Books?.Any(e => e.BookId == id)).GetValueOrDefault();
        }
        [HttpGet]
        [Route("GetBooksAutho")]
        public async Task<ActionResult<IEnumerable<Book>>> GetBooksAutho(int ID)
        {
            if (_context.Purchases == null)
            {
                return NotFound();
            }
            var query = await (from n in _context.Books
                               join c in _context.UserTables on n.UserId equals c.UserId
                               join d in _context.Categories on n.CategoryId equals d.CategoryId
                               where c.UserId == ID orderby n.BookId descending
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
                                   c.UserName,
                                   d.CategoryName,
                                   n.CreatedDate,
                                   n.ModifiedDate
                               }).ToListAsync();
            return Ok(query);
        }

    }
}
