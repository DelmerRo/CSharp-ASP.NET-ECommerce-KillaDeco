namespace WebKillaDeco.Models
{
    public class Question
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public int ProductId { get; set; }
        public string? Description { get; set; }
        public DateTime PublicationDate { get; set; }
        public Product? Product { get; set; }
        public Client? Client { get; set; }
        public Answer? Answer { get; set; }
    }
}
