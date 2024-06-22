using WebKillaDeco.Areas.Identity.Data;
using WebKillaDeco.Models;

namespace WebKillaDeco.Interfaces
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetProductsBySubCategory(int subcategoryId);
        IEnumerable<Product> GetProductsByBrand(string[] brands);
        IEnumerable<Product> GetProductsByColor(string color);
        IEnumerable<Product> GetProductsByPriceRange(decimal minPrice, decimal maxPrice);
    }

    public class ProductRepository : IProductRepository
    {
        private readonly KillaDbContext _context;

        public ProductRepository(KillaDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Product> GetProductsBySubCategory(int subcategoryId)
        {
            return _context.Products.Where(p => p.SubCategoryId == subcategoryId).ToList();
        }

        public IEnumerable<Product> GetProductsByBrand(string[] brands)
        {
            return _context.Products.Where(p => brands.Contains(p.Brand)).ToList();
        }

        public IEnumerable<Product> GetProductsByColor(string color)
        {
            return _context.Products.Where(p => p.Color == color).ToList();
        }

        public IEnumerable<Product> GetProductsByPriceRange(decimal minPrice, decimal maxPrice)
        {
            return _context.Products.Where(p => p.CurrentPrice >= minPrice && p.CurrentPrice <= maxPrice).ToList();
        }
    }

}
