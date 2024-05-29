namespace WebKillaDeco.Models
{
    public class Answer
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public int QuestionId { get; set; }
        public string? description { get; set; }
        public DateTime? publicationDate { get; set; }
        public Question? Question { get; set; }
        public Employee? Employee { get; set; }
    }
}
