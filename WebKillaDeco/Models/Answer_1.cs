namespace WebKillaDeco.Models
{
    public class Answer
    {
        public int CategoryId { get; set; }
        public string? Name { get; set; }
        public string? ImageUrl { get; set; }
        public List<SubCategory>? SubCategories { get; set; }
    }
}
