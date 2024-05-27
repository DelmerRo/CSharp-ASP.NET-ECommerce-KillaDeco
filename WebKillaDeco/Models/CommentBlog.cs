namespace WebKillaDeco.Models
{
    public class CommentBlog
    {
        public int CommentBlogId { get; set; }
        public int BlogPostId { get; set; }
        public BlogPost BlogPost { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public string Content { get; set; }
        public DateTime PublicationDate { get; set; }
    }
}
