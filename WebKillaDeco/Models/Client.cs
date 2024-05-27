namespace WebKillaDeco.Models
{
    public class Client: User
    {
        public List<Purchase> Purchases { get; set; }
        public List<Cart> Carts { get; set; }
        public List<Qualification> Qualifications { get; set; }
        public List<Favorite> Favorites { get; set; }
        public List<CommentBlog> CommentsBlog { get; set; }
    }
}
