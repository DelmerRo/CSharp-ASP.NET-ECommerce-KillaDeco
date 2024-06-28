namespace WebKillaDeco.Models
{
    public class Qualification
    {
        public int QualificationId { get; set; }
        public int ProductId { get; set; }
        public int ClientId { get; set; }
        public int Rating { get; set; } = 5;
        public string? Comment { get; set; }
        public Client? Client { get; set; }
        public Product? Product { get; set; }
        public DateTime DateQualification { get; set; }
    }
}
