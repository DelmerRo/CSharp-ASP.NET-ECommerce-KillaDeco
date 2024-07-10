using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using WebKillaDeco.Areas.Identity.Data;
using WebKillaDeco.Helpers;
using WebKillaDeco.Models;
using WebKillaDeco.ViewModels;

namespace WebKillaDeco.Controllers
{
    public class ProductsController : Controller
    {
        private readonly KillaDbContext _context;
        private readonly ImageService _imageService;
        private const int PageSize = 20;
        private const int MaxNumberImages = 4;

        public ProductsController(KillaDbContext context, ImageService imageService)
        {
            _context = context;
            _imageService = imageService;
        }

        public async Task<IActionResult> Review(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .Include(p => p.Qualifications)  // Incluye las calificaciones del producto
                    .ThenInclude(q => q.Client)  // Subincluye el cliente asociado a cada calificación
                .FirstOrDefaultAsync(p => p.ProductId == id);

            if (product == null)
            {
                return NotFound();
            }

            return PartialView("Review", product);
        }




        [Authorize]
        public async Task<IActionResult> Index(int pageNumber = 1, int pageSize = PageSize)
        {
            var productActiveDescending = await _context.Products
                                                        .Include(p => p.SubCategories)
                                                        .Include(P => P.Qualifications)
                                                        .Where(p => p.Active)
                                                        .OrderByDescending(d => d.PublicationDate)
                                                        .ToListAsync();

            var brandsWithMaxDiscount = productActiveDescending
                .GroupBy(p => p.Brand)
                .Select(group => new
                {
                    Brand = group.Key,
                    MaxDiscount = group.Max(p => p.Discount)
                })
                .OrderByDescending(item => item.MaxDiscount)
                .Take(5) // Tomar las primeras 5 marcas con el mayor descuento
                .Select(item => item.Brand) // Seleccionar solo el nombre de la marca
                .ToList();

            var categories = await _context.Categories.Include(c => c.SubCategories).OrderByDescending(c => c.Name).ToListAsync();

            int totalProducts = productActiveDescending.Count;
            int totalPages = (int)Math.Ceiling(totalProducts / (double)pageSize);
            var paginatedProducts = productActiveDescending.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();

            var viewModel = new ProductCategoryViewModel
            {
                Products = paginatedProducts,
                Categories = categories,
                Brands = brandsWithMaxDiscount,
                CurrentPage = pageNumber,
                TotalPages = totalPages
            };

            return View(viewModel);
        }

        public ActionResult GetProductsByFilters(int? subcategoryId, List<string> brands, string color, decimal? minPrice, decimal? maxPrice, string sortOrder, int pageNumber = 1, int pageSize = PageSize, string searchString = "")
        {
            var products = _context.Products.Include(p => p.Qualifications).AsQueryable();

            // Here you can use searchString to filter products based on the search input

            products = FilterProducts(products, subcategoryId, brands, color, minPrice, maxPrice, searchString);
            products = SortProducts(products, sortOrder);

            int totalProducts = products.Count();
            int totalPages = (int)Math.Ceiling(totalProducts / (double)pageSize);
            var paginatedProducts = PaginateProducts(products, pageNumber, pageSize);

            var viewModel = new ProductCategoryViewModel
            {
                Products = paginatedProducts,
                CurrentPage = pageNumber,
                TotalPages = totalPages
            };

            return PartialView("_ProductListPartial", viewModel);
        }


        private IQueryable<Product> FilterProducts(IQueryable<Product> products, int? subcategoryId, List<string> brands, string color, decimal? minPrice, decimal? maxPrice, string searchString)
        {
            if (subcategoryId.HasValue)
            {
                products = products.Where(p => p.SubCategoryId == subcategoryId.Value);
            }

            if (brands != null && brands.Any())
            {
                products = products.Where(p => brands.Contains(p.Brand));
            }

            if (!string.IsNullOrEmpty(color))
            {
                products = products.Where(p => p.Color == color);
            }

            if (minPrice.HasValue)
            {
                products = products.Where(p => p.CurrentPrice >= minPrice.Value);
            }

            if (maxPrice.HasValue)
            {
                products = products.Where(p => p.CurrentPrice <= maxPrice.Value);
            }
            if (!string.IsNullOrEmpty(searchString))
            {
                products = products.Where(p => p.Name.Contains(searchString) || p.Description.Contains(searchString));
            }

            return products;
        }

        private IQueryable<Product> SortProducts(IQueryable<Product> products, string sortOrder)
        {
            switch (sortOrder)
            {
                case "low-price":
                    return products.OrderBy(p => p.CurrentPrice);
                case "high-price":
                    return products.OrderByDescending(p => p.CurrentPrice);
                default:
                    return products.OrderByDescending(d => d.PublicationDate);
            }
        }

        private List<Product> PaginateProducts(IQueryable<Product> products, int pageNumber, int pageSize)
        {
            return products.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();
        }


        // Acción para obtener productos por subcategoría mediante AJAX
        //[HttpGet]
        //public IActionResult GetProductsBySubcategory(int subcategoryId)
        //{
        //    var products = _context.Products
        //                           .Include(p => p.SubCategories)
        //                           .Where(p => p.SubCategoryId == subcategoryId)
        //                           .ToList();

        //    return PartialView("_ProductListPartial", products);
        //}

        //// Acción para obtener productos por marca mediante AJAX
        //[HttpGet]
        //public IActionResult GetProductsByBrand(List<string> brands)
        //{
        //    var products = _context.Products
        //                           .Include(p => p.SubCategories)
        //                           .Where(p => brands.Contains(p.Brand))
        //                           .ToList();

        //    return PartialView("_ProductListPartial", products);
        //}

        [Authorize]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                  .Include(P => P.Questions)
                  .ThenInclude(p => p.Answer)
                .Include(p => p.SubCategories)
                .ThenInclude(p => p.Category)
                 .Include(p => p.Qualifications)
                 .ThenInclude(p => p.Client)
                .FirstOrDefaultAsync(m => m.ProductId == id);

            if (product == null)
            {
                return NotFound();
            }

            // Ejemplo de formateo en el controlador
            decimal originalPrice = product.CurrentPrice;
            decimal discountAmount = originalPrice * product.Discount/100;
            decimal discountedPrice = originalPrice - discountAmount;

            ViewBag.FormattedOriginalPrice = string.Format(CultureInfo.CurrentCulture, "{0:C}", originalPrice);
            ViewBag.FormattedDiscountedPrice = string.Format(CultureInfo.CurrentCulture, "{0:C}", discountedPrice);

            return View(product);
        }

        [Authorize]
        public IActionResult Create()
        {
            ViewData["SubCategoryId"] = new SelectList(_context.SubCategories.OrderBy(sc => sc.Name).ToList(), "SubCategoryId", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Create([Bind("ProductId,SubCategoryId,Name,Description,Brand,CurrentPrice,Active,ImageUrlFile,AvailableStock,Weight,Width,Height,Depth,Color,PublicationDate,Discount")] Product product, List<IFormFile> imageFiles)
        {
            ModelState.Remove(nameof(product.ImageUrl));
            ModelState.Remove(nameof(product.Sku));

            if (ModelState.IsValid)
            {
                try
                {
                    if (imageFiles.Count <= MaxNumberImages)
                    {
                        if (imageFiles != null && imageFiles.Count > 0)
                        {
                            var imageUrls = await _imageService.SaveImagesAsync(imageFiles, Alias.ProductImagePath);

                            // Asignar las URLs de las imágenes al producto
                            if (imageUrls.Count > 0) product.ImageUrl = imageUrls[0];
                            if (imageUrls.Count > 1) product.ImageUrl1 = imageUrls[1];
                            if (imageUrls.Count > 2) product.ImageUrl2 = imageUrls[2];
                            if (imageUrls.Count > 3) product.ImageUrl3 = imageUrls[3];
                        }
                    }
                    else
                    {
                        ModelState.AddModelError(nameof(product.ImageUrlFile), ErrorMsgs.QuantityInvalidFiles);
                        ViewData["SubCategoryId"] = new SelectList(_context.SubCategories, "SubCategoryId", "Name", product.SubCategoryId);
                        return View(product);
                    }

                    var subCategory = await _context.SubCategories.Include(sc => sc.Category).FirstOrDefaultAsync(sc => sc.SubCategoryId == product.SubCategoryId);

                    if (subCategory != null)
                    {
                        _context.Add(product);
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

            ViewData["SubCategoryId"] = new SelectList(_context.SubCategories.OrderBy(sc => sc.Name).ToList(), "SubCategoryId", "Name", product.SubCategoryId);
            return View(product);
        }

        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
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
                    existingProduct.Brand = product.Brand;
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
            if (id == null)
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
            var product = await _context.Products.FindAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductExists(int id)
        {
            return _context.Products.Any(e => e.ProductId == id);
        }

    }
}
