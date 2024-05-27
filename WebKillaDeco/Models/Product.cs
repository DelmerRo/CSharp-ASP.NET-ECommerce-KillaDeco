namespace WebKillaDeco.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public int CategoryId { get; set; }
        public int Sku { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal CurrentPrice { get; set; }
        public bool Active { get; set; }
        public string ImageUrl { get; set; }
        public int AvailableStock { get; set; }
        public decimal Weight { get; set; }
        public string Dimensions { get; set; }
        public DateTime PublicationDate { get; set; }
        public decimal Discount { get; set; }
        public Category Category { get; set; }
        public List<StockItem> StockItems { get; set; }
        public List<Qualification> Qualifications { get; set; }
        public List<Favorite> Favorites { get; set; }
        public List<CartItem> CartItems { get; set; }
    }
}
