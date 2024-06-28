using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebKillaDeco.Areas.Identity.Data;
using WebKillaDeco.Models;

namespace WebKillaDeco.Controllers
{
    public class QualificationsController : Controller
    {
        private readonly KillaDbContext _context;

        public QualificationsController(KillaDbContext context)
        {
            _context = context;
        }

        // GET: Qualifications
        public async Task<IActionResult> Index()
        {
            var killaDbContext = _context.Qualifications.Include(q => q.Client).Include(q => q.Product);
            return View(await killaDbContext.ToListAsync());
        }

        // GET: Qualifications/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Qualifications == null)
            {
                return NotFound();
            }

            var qualification = await _context.Qualifications
                .Include(q => q.Client)
                .Include(q => q.Product)
                .FirstOrDefaultAsync(m => m.QualificationId == id);
            if (qualification == null)
            {
                return NotFound();
            }

            return View(qualification);
        }

        // GET: Qualifications/Create
        public IActionResult Create()
        {
            ViewData["ClientId"] = new SelectList(_context.Clients, "Id", "Discriminator");
            ViewData["ProductId"] = new SelectList(_context.Products, "ProductId", "Brand");
            return View();
        }

        // POST: Qualifications/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("QualificationId,ProductId,ClientId,Rating,Comment,DateQualification")] Qualification qualification)
        {
            if (ModelState.IsValid)
            {
                _context.Add(qualification);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClientId"] = new SelectList(_context.Clients, "Id", "Discriminator", qualification.ClientId);
            ViewData["ProductId"] = new SelectList(_context.Products, "ProductId", "Brand", qualification.ProductId);
            return View(qualification);
        }

        // GET: Qualifications/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Qualifications == null)
            {
                return NotFound();
            }

            var qualification = await _context.Qualifications.FindAsync(id);
            if (qualification == null)
            {
                return NotFound();
            }
            ViewData["ClientId"] = new SelectList(_context.Clients, "Id", "Discriminator", qualification.ClientId);
            ViewData["ProductId"] = new SelectList(_context.Products, "ProductId", "Brand", qualification.ProductId);
            return View(qualification);
        }

        // POST: Qualifications/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("QualificationId,ProductId,ClientId,Rating,Comment,DateQualification")] Qualification qualification)
        {
            if (id != qualification.QualificationId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(qualification);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!QualificationExists(qualification.QualificationId))
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
            ViewData["ClientId"] = new SelectList(_context.Clients, "Id", "Discriminator", qualification.ClientId);
            ViewData["ProductId"] = new SelectList(_context.Products, "ProductId", "Brand", qualification.ProductId);
            return View(qualification);
        }

        // GET: Qualifications/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Qualifications == null)
            {
                return NotFound();
            }

            var qualification = await _context.Qualifications
                .Include(q => q.Client)
                .Include(q => q.Product)
                .FirstOrDefaultAsync(m => m.QualificationId == id);
            if (qualification == null)
            {
                return NotFound();
            }

            return View(qualification);
        }

        // POST: Qualifications/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Qualifications == null)
            {
                return Problem("Entity set 'KillaDbContext.Qualifications'  is null.");
            }
            var qualification = await _context.Qualifications.FindAsync(id);
            if (qualification != null)
            {
                _context.Qualifications.Remove(qualification);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool QualificationExists(int id)
        {
          return (_context.Qualifications?.Any(e => e.QualificationId == id)).GetValueOrDefault();
        }
    }
}
