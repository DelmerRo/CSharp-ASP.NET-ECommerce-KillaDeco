namespace WebKillaDeco.Models
{
    public class Favorite
    {
        public int FavoriteId { get; set; }
        public int ProductId { get; set; }
        public int ClientId { get; set; }
        public DateTime DateFavorite { get; set; }
        public Product? Product { get; set; }
        public Client? Client { get; set; }
    }
}
