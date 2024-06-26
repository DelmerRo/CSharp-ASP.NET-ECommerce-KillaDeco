using WebKillaDeco.Models;

namespace WebKillaDeco.ViewModels
{
    public class ProductCategoryViewModel
    {
        public List<Product> Products { get; set; }
        public List<Category>? Categories { get; set; }
        public List<string?> Brands { get; set; }
        public int TotalPages { get; set; }
        public int CurrentPage { get; set; }
    }
}
