using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebKillaDeco.Areas.Identity.Data;
using WebKillaDeco.Helpers;
using WebKillaDeco.Models;

namespace WebKillaDeco.Controllers
{
    public class ProductsController : Controller
    {
        private readonly KillaDbContext _context;
        private readonly ImageService _imageService;

        public ProductsController(KillaDbContext context, ImageService imageService)
        {
            _context = context;
            _imageService = imageService;
        }

        [Authorize]
        public async Task<IActionResult> Index()
        {
            var killaDbContext = _context.Products.Include(p => p.SubCategories).OrderByDescending(d => d.PublicationDate);
            return View(await killaDbContext.ToListAsync());
        }

        [Authorize]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Products == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .Include(p => p.SubCategories)
                .FirstOrDefaultAsync(m => m.ProductId == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // GET: Products/Create
        [Authorize]
        public IActionResult Create()
        {
            ViewData["SubCategoryId"] = new SelectList(_context.SubCategories.OrderBy(sc => sc.Name).ToList(), "SubCategoryId", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Create([Bind("ProductId,SubCategoryId,Name,Description,CurrentPrice,Active,ImageUrlFile,AvailableStock,Weight,Width,Height,Depth,Color,PublicationDate,Discount")] Product product)
        {
            ModelState.Remove(nameof(product.ImageUrl));
            ModelState.Remove(nameof(product.Sku));

            if (ModelState.IsValid)
            {
                try
                {
                    if (product.ImageUrlFile != null)
                    {
                        product.ImageUrl = await _imageService.SaveImageAsync(product.ImageUrlFile, Alias.ProductImagePath);
                    }
                    else
                    {
                        //ModelState.AddModelError(nameof(product.ImageUrlFile), MessageTemplates.GetPropertyIsRequired(Alias.ProductImage));
                        //ViewData["SubCategoryId"] = new SelectList(_context.SubCategories, "SubCategoryId", "Name", product.SubCategoryId);
                        //return View(product);
                    }
                    var subCategory = await _context.SubCategories.Include(sc => sc.Category).FirstOrDefaultAsync(sc => sc.SubCategoryId == product.SubCategoryId);
                    if (subCategory != null)
                    {
                        await _context.AddAsync(product);
                        await _context.SaveChangesAsync();
                        product.GenerateSku(subCategory.CategoryId, product.SubCategoryId, product.ProductId);
                        _context.Update(product);
                        await _context.SaveChangesAsync();

                        return RedirectToAction(nameof(Index));
                    }
                    ModelState.AddModelError(string.Empty, "Subcategory not found.");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, $"Error: {ex.Message}");
                }
            }

            ViewData["SubCategoryId"] = new SelectList(_context.SubCategories, "SubCategoryId", "Name", product.SubCategoryId);
            return View(product);
        }

        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Products == null)
            {
                return NotFound();
            }

            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            ViewData["SubCategoryId"] = new SelectList(_context.SubCategories, "SubCategoryId", "Name", product.SubCategoryId);
            return View(product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Edit(int id, Product product)
        {
            if (id != product.ProductId)
            {
                return NotFound();
            }
            ModelState.Remove(nameof(product.Sku));
            ModelState.Remove(nameof(product.ImageUrl));
            ModelState.Remove(nameof(product.ImageUrlFile));

            if (ModelState.IsValid)
            {
                try
                {
                    var existingProduct = await _context.Products.FindAsync(id);

                    if (existingProduct == null)
                    {
                        return NotFound();
                    }

                    existingProduct.SubCategoryId = product.SubCategoryId;
                    existingProduct.Name = product.Name;
                    existingProduct.Description = product.Description;
                    existingProduct.CurrentPrice = product.CurrentPrice;
                    existingProduct.Active = product.Active;
                    existingProduct.AvailableStock = product.AvailableStock;
                    existingProduct.Weight = product.Weight;
                    existingProduct.Width = product.Width;
                    existingProduct.Height = product.Height;
                    existingProduct.Depth = product.Depth;
                    existingProduct.Color = product.Color;
                    existingProduct.Discount = product.Discount;

                    if (product.ImageUrlFile != null && product.ImageUrlFile.Length > 0)
                    {
                        existingProduct.ImageUrl = await _imageService.SaveImageAsync(product.ImageUrlFile, Alias.ProductImagePath);
                    }

                    _context.Update(existingProduct);
                    await _context.SaveChangesAsync();

                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(product.ProductId))
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
                    ModelState.AddModelError("", "Error al guardar el producto. Inténtelo de nuevo más tarde.");
                }
            }

            ViewData["SubCategoryId"] = new SelectList(_context.SubCategories, "SubCategoryId", "Name", product.SubCategoryId);
            return View(product);
        }

        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Products == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .Include(p => p.SubCategories)
                .FirstOrDefaultAsync(m => m.ProductId == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Products == null)
            {
                return Problem("Entity set 'KillaDbContext.Products'  is null.");
            }
            var product = await _context.Products.FindAsync(id);
            if (product != null)
            {
                _context.Products.Remove(product);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductExists(int id)
        {
            return (_context.Products?.Any(e => e.ProductId == id)).GetValueOrDefault();
        }
    }
}
