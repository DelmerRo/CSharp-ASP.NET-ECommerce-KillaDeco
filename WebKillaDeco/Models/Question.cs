namespace WebKillaDeco.Models
{
    public class Question
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public int ProductId { get; set; }
        public string? description { get; set; }
        public DateTime publicationDate { get; set; }
        public Product? Product { get; set; }
        public Client? Client { get; set; }
        public Answer? Answer { get; set; }
    }
}
