using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using section7.Data;
using section7.Models;

namespace section7.Controllers
{
    public class StudentMarksController : Controller
    {
        private readonly SchoolDbContext _context;

        public StudentMarksController(SchoolDbContext context)
        {
            _context = context;
        }

        // GET: StudentMarks
        public async Task<IActionResult> Index()
        {
              return _context.StudentMarks != null ? 
                          View(await _context.StudentMarks.ToListAsync()) :
                          Problem("Entity set 'SchoolDbContext.StudentMarks'  is null.");
        }

        // GET: StudentMarks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.StudentMarks == null)
            {
                return NotFound();
            }

            var studentMarks = await _context.StudentMarks
                .FirstOrDefaultAsync(m => m.StudentId == id);
            if (studentMarks == null)
            {
                return NotFound();
            }

            return View(studentMarks);
        }

        // GET: StudentMarks/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: StudentMarks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StudentId,StudentName,Subject,Marks")] StudentMarks studentMarks)
        {
            if (ModelState.IsValid)
            {
                _context.Add(studentMarks);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(studentMarks);
        }

        // GET: StudentMarks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.StudentMarks == null)
            {
                return NotFound();
            }

            var studentMarks = await _context.StudentMarks.FindAsync(id);
            if (studentMarks == null)
            {
                return NotFound();
            }
            return View(studentMarks);
        }

        // POST: StudentMarks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("StudentId,StudentName,Subject,Marks")] StudentMarks studentMarks)
        {
            if (id != studentMarks.StudentId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(studentMarks);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StudentMarksExists(studentMarks.StudentId))
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
            return View(studentMarks);
        }

        // GET: StudentMarks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.StudentMarks == null)
            {
                return NotFound();
            }

            var studentMarks = await _context.StudentMarks
                .FirstOrDefaultAsync(m => m.StudentId == id);
            if (studentMarks == null)
            {
                return NotFound();
            }

            return View(studentMarks);
        }

        // POST: StudentMarks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.StudentMarks == null)
            {
                return Problem("Entity set 'SchoolDbContext.StudentMarks'  is null.");
            }
            var studentMarks = await _context.StudentMarks.FindAsync(id);
            if (studentMarks != null)
            {
                _context.StudentMarks.Remove(studentMarks);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StudentMarksExists(int id)
        {
          return (_context.StudentMarks?.Any(e => e.StudentId == id)).GetValueOrDefault();
        }
    }
}
