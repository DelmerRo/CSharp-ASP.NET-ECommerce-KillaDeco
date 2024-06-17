using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WebKillaDeco.Areas.Identity.Data;
using WebKillaDeco.Models;

namespace WebKillaDeco.Controllers
{
    public class SubCategoriesController : Controller
    {
        private readonly KillaDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public SubCategoriesController(KillaDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        // GET: SubCategories
        [Authorize]
        public async Task<IActionResult> Index()
        {
            var subCategories = await _context.SubCategories.Include(s => s.Category).ToListAsync();
            return View(subCategories);
        }

        // GET: SubCategories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || !ModelState.IsValid)
            {
                return NotFound();
            }

            var subCategory = await _context.SubCategories
                .Include(s => s.Category)
                .Include(p => p.Products)
                .FirstOrDefaultAsync(m => m.SubCategoryId == id);

            if (subCategory == null)
            {
                return NotFound();
            }

            return View(subCategory);
        }

        // GET: SubCategories/Create
        public IActionResult Create()
        {
            ViewData["CategoryId"] = new SelectList(_context.Categories.OrderBy(c => c.Name).ToList(), "CategoryId", "Name");
            return View();
        }

        // POST: SubCategories/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SubCategory subCategory)
        {
            ModelState.Remove(nameof(subCategory.IconUrl));

            if (ModelState.IsValid)
            {
                try
                {
                    await SaveIconAsync(subCategory); // Método privado para guardar el icono
                    await _context.AddAsync(subCategory);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateException ex)
                {
                    ModelState.AddModelError("", "Error al guardar la subcategoría. Inténtelo de nuevo más tarde.");
                    Console.WriteLine(ex.Message);
                }
            }

            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "Name", subCategory.CategoryId);
            return View(subCategory);
        }

        // GET: SubCategories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || !ModelState.IsValid)
            {
                return NotFound();
            }

            var subCategory = await _context.SubCategories.FindAsync(id);
            if (subCategory == null)
            {
                return NotFound();
            }

            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "Name", subCategory.CategoryId);
            return View(subCategory);
        }

        // POST: SubCategories/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, SubCategory subCategory)
        {
            if (id != subCategory.SubCategoryId)
            {
                return NotFound();
            }

            ModelState.Remove(nameof(subCategory.IconUrl));
            ModelState.Remove(nameof(subCategory.IconUrlFile));
            ModelState.Remove(nameof(subCategory.Category));

            if (ModelState.IsValid)
            {
                try
                {
                    var existingSubCategory = await _context.SubCategories.FindAsync(id);
                    if (existingSubCategory == null)
                    {
                        return NotFound();
                    }

                    existingSubCategory.Name = subCategory.Name;
                    existingSubCategory.CategoryId = subCategory.CategoryId;

                    await SaveIconAsync(subCategory); // Método privado para guardar el icono

                    _context.Update(existingSubCategory);
                    await _context.SaveChangesAsync();

                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SubCategoryExists(subCategory.SubCategoryId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }

            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "Name", subCategory.CategoryId);
            return View(subCategory);
        }

        // GET: SubCategories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.SubCategories == null || !ModelState.IsValid)
            {
                return NotFound();
            }

            var subCategory = await _context.SubCategories
                .Include(s => s.Category)
                .FirstOrDefaultAsync(m => m.SubCategoryId == id);

            if (subCategory == null)
            {
                return NotFound();
            }

            return View(subCategory);
        }


        // POST: SubCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var subCategory = await _context.SubCategories.FindAsync(id);
            if (subCategory == null || !ModelState.IsValid)
            {
                return NotFound();
            }

            _context.SubCategories.Remove(subCategory);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> SubCategoryNameAvailable(string name)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("El nombre de la categoría no puede estar vacío.");
            }

            var nameExists = await _context.SubCategories.AnyAsync(p => p.Name == name);
            return Json(!nameExists);
        }

        private async Task SaveIconAsync(SubCategory subCategory)
        {
            if (subCategory.IconUrlFile != null && subCategory.IconUrlFile.Length > 0)
            {
                string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "images", "category-icon");
                string uniqueFileName = Guid.NewGuid().ToString() + "_" + Path.GetFileName(subCategory.IconUrlFile.FileName);
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await subCategory.IconUrlFile.CopyToAsync(fileStream);
                }
                subCategory.IconUrl = "~/images/category-icon/" + uniqueFileName;
            }
        }

        private bool SubCategoryExists(int id)
        {
            return _context.SubCategories.Any(e => e.SubCategoryId == id);
        }
    }
}
