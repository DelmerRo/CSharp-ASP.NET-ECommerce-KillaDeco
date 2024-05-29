namespace WebKillaDeco.Models
{
    public class SubCategory
    {
        public int SubCategoryId { get; set; }
        public int CategoryId { get; set; }
        public string? Name { get; set; }
        public string? ImageUrl { get; set; }
        public Answer? Category { get; set; }
        public List<Product>? Products { get; set; }
    }
}