namespace WebKillaDeco.Models
{
    public class BlogPost
    {
        public int BlogPostId { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }
        public string ImageUrl { get; set; }
        public DateTime PublicationDate { get; set; }
        public List<CommentBlog> CommentsBlog { get; set; }
    }
}
