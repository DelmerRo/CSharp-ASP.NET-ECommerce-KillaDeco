namespace WebKillaDeco.Models
{
    public class Employee: User
    {
        public string Occupation { get; set; }
        public decimal Salary { get; set; }
        public List<BlogPost> BlogPosts { get; set; }
    }
}
