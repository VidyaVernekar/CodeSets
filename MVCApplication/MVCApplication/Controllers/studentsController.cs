using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVCApplication.Data;
using MVCApplication.Models;

namespace MVCApplication.Controllers
{
    public class studentsController : Controller
    {
        private readonly MVCApplicationContext _context;

        public studentsController(MVCApplicationContext context)
        {
            _context = context;
        }

        // GET: students
        public async Task<IActionResult> Index()
        {
              return _context.studentmodel != null ? 
                          View(await _context.studentmodel.ToListAsync()) :
                          Problem("Entity set 'MVCApplicationContext.studentmodel'  is null.");
        }

        // GET: students/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.studentmodel == null)
            {
                return NotFound();
            }

            var studentmodel = await _context.studentmodel
                .FirstOrDefaultAsync(m => m.StudentID == id);
            if (studentmodel == null)
            {
                return NotFound();
            }

            return View(studentmodel);
        }

        // GET: students/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: students/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StudentID,StudentName,StudentSub")] studentmodel studentmodel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(studentmodel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(studentmodel);
        }

        // GET: students/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.studentmodel == null)
            {
                return NotFound();
            }

            var studentmodel = await _context.studentmodel.FindAsync(id);
            if (studentmodel == null)
            {
                return NotFound();
            }
            return View(studentmodel);
        }

        // POST: students/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("StudentID,StudentName,StudentSub")] studentmodel studentmodel)
        {
            if (id != studentmodel.StudentID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(studentmodel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!studentmodelExists(studentmodel.StudentID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(studentmodel);
        }

        // GET: students/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.studentmodel == null)
            {
                return NotFound();
            }

            var studentmodel = await _context.studentmodel
                .FirstOrDefaultAsync(m => m.StudentID == id);
            if (studentmodel == null)
            {
                return NotFound();
            }

            return View(studentmodel);
        }

        // POST: students/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.studentmodel == null)
            {
                return Problem("Entity set 'MVCApplicationContext.studentmodel'  is null.");
            }
            var studentmodel = await _context.studentmodel.FindAsync(id);
            if (studentmodel != null)
            {
                _context.studentmodel.Remove(studentmodel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool studentmodelExists(int id)
        {
          return (_context.studentmodel?.Any(e => e.StudentID == id)).GetValueOrDefault();
        }
    }
}
