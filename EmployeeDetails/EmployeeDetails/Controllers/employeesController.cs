using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EmployeeDetails.Data;
using EmployeeDetails.Models;

namespace EmployeeDetails.Controllers
{
    public class employeesController : Controller
    {
        private readonly EmployeeDetailsContext _context;

        public employeesController(EmployeeDetailsContext context)
        {
            _context = context;
        }

        // GET: employees
        public async Task<IActionResult> Index()
        {
              return _context.employee != null ? 
                          View(await _context.employee.ToListAsync()) :
                          Problem("Entity set 'EmployeeDetailsContext.employee'  is null.");
        }

        // GET: employees/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.employee == null)
            {
                return NotFound();
            }

            var employee = await _context.employee
                .FirstOrDefaultAsync(m => m.employeeID == id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // GET: employees/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: employees/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("employeeID,employeeName,employeeDesign,Salary")] employee employee)
        {
            if (ModelState.IsValid)
            {
                _context.Add(employee);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(employee);
        }

        // GET: employees/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.employee == null)
            {
                return NotFound();
            }

            var employee = await _context.employee.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }

        // POST: employees/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("employeeID,employeeName,employeeDesign,Salary")] employee employee)
        {
            if (id != employee.employeeID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(employee);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!employeeExists(employee.employeeID))
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
            return View(employee);
        }

        // GET: employees/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.employee == null)
            {
                return NotFound();
            }

            var employee = await _context.employee
                .FirstOrDefaultAsync(m => m.employeeID == id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // POST: employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.employee == null)
            {
                return Problem("Entity set 'EmployeeDetailsContext.employee'  is null.");
            }
            var employee = await _context.employee.FindAsync(id);
            if (employee != null)
            {
                _context.employee.Remove(employee);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool employeeExists(int id)
        {
          return (_context.employee?.Any(e => e.employeeID == id)).GetValueOrDefault();
        }
    }
}
