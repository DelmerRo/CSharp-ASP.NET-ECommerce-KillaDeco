
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebKillaDeco.Areas.Identity.Data;
using WebKillaDeco.Models;

namespace WebKillaDeco.Controllers
{
    
    public class CategoriesController : Controller
    {
        private readonly KillaDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public CategoriesController(KillaDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
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
                    .ThenInclude(s => s.Products)
                .FirstOrDefaultAsync(m => m.CategoryId == id);

            if (category == null)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                // Manejar el estado de modelo no válido según sea necesario
                // Por ejemplo, redirigir a una página de error o manejar el error de otra manera
                return BadRequest(ModelState); // O utiliza otro tipo de respuesta adecuada
            }

            return View(category);
        }




        [Authorize]
        public IActionResult Create()
        {
            var category = new Category(); // Crear una nueva instancia de Category
            return View(category);
        }

        // POST: Categories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("CategoryId,Name,ImageUrl,IconUrl")] Category category)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(category);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(category);
        //}


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Category category)
        {
            // Eliminar las validaciones de las propiedades de archivo antes de la validación del modelo
            ModelState.Remove(nameof(category.ImageUrl));
            ModelState.Remove(nameof(category.IconUrl));

            if (ModelState.IsValid)
            {
                try
                {
                    // Guardar la imagen principal (ImageUrlFile)
                    if (category.ImageUrlFile != null && category.ImageUrlFile.Length > 0)
                    {
                        string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "images", "category-image");
                        string uniqueFileName = Guid.NewGuid().ToString() + "_" + Path.GetFileName(category.ImageUrlFile.FileName);
                        string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                        using (var fileStream = new FileStream(filePath, FileMode.Create))
                        {
                            await category.ImageUrlFile.CopyToAsync(fileStream);
                        }
                        category.ImageUrl = "~/images/category-image/" + uniqueFileName; // Guardar la ruta relativa
                    }

                    // Guardar el icono (IconUrlFile)
                    if (category.IconUrlFile != null && category.IconUrlFile.Length > 0)
                    {
                        string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "images", "category-icon");
                        string uniqueFileName = Guid.NewGuid().ToString() + "_" + Path.GetFileName(category.IconUrlFile.FileName);
                        string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                        using (var fileStream = new FileStream(filePath, FileMode.Create))
                        {
                            await category.IconUrlFile.CopyToAsync(fileStream);
                        }
                        category.IconUrl = "~/images/category-icon/" + uniqueFileName; // Guardar la ruta relativa
                    }

                    // Guardar la categoría en la base de datos
                    _context.Add(category);
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
            return View(category);
        }


        // GET: Categories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Categories == null)
            {
                return NotFound();
            }

            var category = await _context.Categories.FindAsync(id);
            if (category == null)
            {
                return NotFound();
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

            // Eliminar las validaciones de las propiedades de archivo antes de la validación del modelo
            ModelState.Remove(nameof(category.ImageUrl));
            ModelState.Remove(nameof(category.IconUrl));
            ModelState.Remove(nameof(category.ImageUrlFile));
            ModelState.Remove(nameof(category.IconUrlFile));

            if (ModelState.IsValid)
            {
                try
                {
                    // Obtener la categoría existente de la base de datos
                    var existingCategory = await _context.Categories.FindAsync(id);
                    if (existingCategory == null)
                    {
                        return NotFound();
                    }

                    // Actualizar el nombre
                    existingCategory.Name = category.Name;

                    // Guardar la nueva imagen principal (ImageUrlFile) si se proporciona
                    if (category.ImageUrlFile != null && category.ImageUrlFile.Length > 0)
                    {
                        string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "images", "category-image");
                        string uniqueFileName = Guid.NewGuid().ToString() + "_" + Path.GetFileName(category.ImageUrlFile.FileName);
                        string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                        using (var fileStream = new FileStream(filePath, FileMode.Create))
                        {
                            await category.ImageUrlFile.CopyToAsync(fileStream);
                        }
                        existingCategory.ImageUrl = "~/images/category-image/" + uniqueFileName; // Guardar la ruta relativa
                    }

                    // Guardar el nuevo icono (IconUrlFile) si se proporciona
                    if (category.IconUrlFile != null && category.IconUrlFile.Length > 0)
                    {
                        string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "images", "category-icon");
                        string uniqueFileName = Guid.NewGuid().ToString() + "_" + Path.GetFileName(category.IconUrlFile.FileName);
                        string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                        using (var fileStream = new FileStream(filePath, FileMode.Create))
                        {
                            await category.IconUrlFile.CopyToAsync(fileStream);
                        }
                        existingCategory.IconUrl = "~/images/category-icon/" + uniqueFileName; // Guardar la ruta relativa
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
                    // Manejo de errores
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
            var nameExists = await _context.Categories.AnyAsync(p => p.Name == name);

            if (!nameExists)
            {
                // Si no está el nombre usado, entonces, el nombre está disponible.
                return Json(true);
            }
            else
            {
                // El nombre ya está en uso, entonces, no se cumple la validación. Se devuelve un mensaje de error.
                return Json($"La categoría {name} ya está en uso.");
            }
        }


        // GET: Categories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Categories == null)
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
            if (_context.Categories == null)
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
