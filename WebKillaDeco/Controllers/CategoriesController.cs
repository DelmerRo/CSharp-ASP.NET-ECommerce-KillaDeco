
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebKillaDeco.Areas.Identity.Data;
using WebKillaDeco.Helpers;
using WebKillaDeco.Models;

namespace WebKillaDeco.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly KillaDbContext _context;
        private readonly ImageService _imageService;

        public CategoriesController(KillaDbContext context, ImageService imageService)
        {
            _context = context;
            _imageService = imageService;
        }

        // GET: Categories
        [Authorize]
        public async Task<IActionResult> Index()
        {
            return _context.Categories != null ?
                        View(await _context.Categories.ToListAsync()) :
                        Problem("Entity set 'KillaDbContext.Categories'  is null.");
        }

        // GET: Categories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category = await _context.Categories
                .Include(c => c.SubCategories)
                .FirstOrDefaultAsync(m => m.CategoryId == id);

            if (category == null)
            {
                return NotFound();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return View(category);
        }

        [Authorize]
        public IActionResult Create()
        {
            var category = new Category();
            return View(category);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Category category)
        {
            ModelState.Remove(nameof(category.ImageUrl));
            ModelState.Remove(nameof(category.IconUrl));

            if (ModelState.IsValid)
            {
                try
                {
                    if (category.ImageUrlFile != null && category.ImageUrlFile.Length > 0)
                    {
                        category.ImageUrl = await _imageService.SaveImageAsync(category.ImageUrlFile, Alias.CategoryImagePath);
                    }
                    else
                    {
                        ModelState.AddModelError(nameof(category.ImageUrlFile), MessageTemplates.GetPropertyIsRequired(Alias.UrlCategoryImage));
                        return View(category);
                    }
                    if (category.IconUrlFile != null && category.IconUrlFile.Length > 0)
                    {
                        category.IconUrl = await _imageService.SaveImageAsync(category.IconUrlFile, Alias.CategoryIconPath);
                    }
                    else
                    {
                        ModelState.AddModelError(nameof(category.IconUrlFile), MessageTemplates.GetPropertyIsRequired(Alias.Icon));
                        return View(category);
                    }
                    await _context.AddAsync(category);
                    await _context.SaveChangesAsync();

                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateException ex)
                {
                    Console.WriteLine(ex.Message);
                    ModelState.AddModelError("", MessageTemplates.GetErrorSaving(Alias.Category));
                }
            }
            return View(category);
        }



        // GET: Categories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category = await _context.Categories.FindAsync(id);
            if (category == null)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return View(category);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Category category)
        {
            if (id != category.CategoryId)
            {
                return NotFound();
            }

            ModelState.Remove(nameof(category.ImageUrl));
            ModelState.Remove(nameof(category.IconUrl));
            ModelState.Remove(nameof(category.ImageUrlFile));
            ModelState.Remove(nameof(category.IconUrlFile));

            if (ModelState.IsValid)
            {
                try
                {
                    var existingCategory = await _context.Categories.FindAsync(id);

                    if (existingCategory == null)
                    {
                        return NotFound();
                    }
                    existingCategory.Name = category.Name;

                    if (category.ImageUrlFile != null && category.ImageUrlFile.Length > 0)
                    {
                        existingCategory.ImageUrl = await _imageService.SaveImageAsync(category.ImageUrlFile, Alias.CategoryImagePath);
                    }

                    if (category.IconUrlFile != null && category.IconUrlFile.Length > 0)
                    {
                        existingCategory.IconUrl = await _imageService.SaveImageAsync(category.IconUrlFile, Alias.CategoryIconPath);
                    }

                    // Actualizar la categoría en la base de datos
                    _context.Update(existingCategory);
                    await _context.SaveChangesAsync();

                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CategoryExists(category.CategoryId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                catch (DbUpdateException ex)
                {
                    Console.WriteLine(ex.Message);
                    ModelState.AddModelError("", "Error al guardar la categoría. Inténtelo de nuevo más tarde.");
                }
            }

            // Si llegamos aquí, significa que ha habido errores, devolvemos la vista con el modelo para corregirlos
            return View(category);
        }

        private bool CategoryExists(int id)
        {
            return _context.Categories.Any(e => e.CategoryId == id);
        }


        [HttpGet]
        public async Task<IActionResult> CategoryNameAvailable(string name)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("El nombre de la categoría no puede estar vacío.");
            }

            var nameExists = await _context.Categories.AnyAsync(p => p.Name == name);

            if (!nameExists)
            {
                return Json(true);
            }
            else
            {
                return Json($"La categoría {name} ya está en uso.");
            }
        }


        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Categories == null || !ModelState.IsValid)
            {
                return NotFound();
            }

            var category = await _context.Categories
                .FirstOrDefaultAsync(m => m.CategoryId == id);
            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        // POST: Categories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Categories == null || !ModelState.IsValid)
            {
                return Problem("Entity set 'KillaDbContext.Categories'  is null.");
            }
            var category = await _context.Categories.FindAsync(id);
            if (category != null)
            {
                _context.Categories.Remove(category);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
