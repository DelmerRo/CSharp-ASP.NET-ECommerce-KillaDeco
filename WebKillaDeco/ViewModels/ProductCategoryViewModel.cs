using WebKillaDeco.Models;

namespace WebKillaDeco.ViewModels
{
    public class ProductCategoryViewModel
    {
        public List<Product> Products { get; set; }
        public List<Category>? Categories { get; set; }
        public List<string?> Brands { get; set; }
    }
}
