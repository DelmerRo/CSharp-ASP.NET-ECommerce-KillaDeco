using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
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
            var killaDbContext = _context.SubCategories.Include(s => s.Category);
            return View(await killaDbContext.ToListAsync());
        }

        // GET: SubCategories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.SubCategories == null)
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

        // GET: SubCategories/Create
        public IActionResult Create()
        {
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "Name");
            return View();
        }

        // POST: SubCategories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SubCategory subCategory)
        {
            // Eliminar las validaciones de las propiedades de archivo antes de la validación del modelo
            ModelState.Remove(nameof(subCategory.IconUrl));

            if (ModelState.IsValid)
            {
                try
                {
                    // Guardar el icono (IconUrlFile)
                    if (subCategory.IconUrlFile != null && subCategory.IconUrlFile.Length > 0)
                    {
                        string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "images", "category-icon");
                        string uniqueFileName = Guid.NewGuid().ToString() + "_" + Path.GetFileName(subCategory.IconUrlFile.FileName);
                        string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                        using (var fileStream = new FileStream(filePath, FileMode.Create))
                        {
                            await subCategory.IconUrlFile.CopyToAsync(fileStream);
                        }
                        subCategory.IconUrl = "~/images/category-icon/" + uniqueFileName; // Guardar la ruta relativa
                    }

                    // Guardar la categoría en la base de datos
                    _context.Add(subCategory);
                    await _context.SaveChangesAsync();

                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateException ex)
                {
                    // Manejo de errores
                    ModelState.AddModelError("", "Error al guardar la categoría. Inténtelo de nuevo más tarde.");
                }
            }

            // Si llegamos aquí, significa que ha habido errores, devolvemos la vista con el modelo para corregirlos
            return View(subCategory);




            //if (ModelState.IsValid)
            //{
            //    _context.Add(subCategory);
            //    await _context.SaveChangesAsync();
            //    return RedirectToAction(nameof(Index));
            //}
            //ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "Name", subCategory.CategoryId);
            //return View(subCategory);
        }

        // GET: SubCategories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.SubCategories == null)
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,  SubCategory subCategory)
        {
            if (id != subCategory.SubCategoryId)
            {
                return NotFound();
            }

            ModelState.Remove(nameof(subCategory.IconUrl));
            ModelState.Remove(nameof(subCategory.IconUrlFile));

            if (ModelState.IsValid)
            {
                try
                {
                    // Obtener la categoría existente de la base de datos
                    var existingSubCategory = await _context.SubCategories.FindAsync(id);
                    if (existingSubCategory == null)
                    {
                        return NotFound();
                    }

                    existingSubCategory.Name = subCategory.Name;

                    if (subCategory.IconUrlFile != null && subCategory.IconUrlFile.Length > 0)
                    {
                        string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "images", "category-icon");
                        string uniqueFileName = Guid.NewGuid().ToString() + "_" + Path.GetFileName(subCategory.IconUrlFile.FileName);
                        string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                        using (var fileStream = new FileStream(filePath, FileMode.Create))
                        {
                            await subCategory.IconUrlFile.CopyToAsync(fileStream);
                        }
                        existingSubCategory.IconUrl = "~/images/category-icon/" + uniqueFileName;
                    }

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
            return View(subCategory);
        }

        // GET: SubCategories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.SubCategories == null)
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
            if (_context.SubCategories == null)
            {
                return Problem("Entity set 'KillaDbContext.SubCategories'  is null.");
            }
            var subCategory = await _context.SubCategories.FindAsync(id);
            if (subCategory != null)
            {
                _context.SubCategories.Remove(subCategory);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


        [HttpGet]
        public async Task<IActionResult> SubCategoryNameAvailable(string name)
        {
            var nameExists = await _context.SubCategories.AnyAsync(p => p.Name == name);

            if (!nameExists)
            {
                // Si no está el nombre usado, entonces, el nombre está disponible.
                return Json(true);
            }
            else
            {
                // El nombre ya está en uso, entonces, no se cumple la validación. Se devuelve un mensaje de error.
                return Json($"La subcategoría {name} ya está en uso.");
            }
        }

        private bool SubCategoryExists(int id)
        {
          return (_context.SubCategories?.Any(e => e.SubCategoryId == id)).GetValueOrDefault();
        }
    }
}
