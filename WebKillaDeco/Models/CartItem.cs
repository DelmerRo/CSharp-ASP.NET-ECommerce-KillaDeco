namespace WebKillaDeco.Models
{
    public class CartItem
    {
        public int CartItemId { get; set; }
        public int CartId { get; set; }
        public int ProductId { get; set; }
        public decimal? UnitPrice { get; set; }
        public int? Amount { get; set; }
        public decimal? Subtotal => UnitPrice * Amount;
        public Cart? Cart { get; set; }
        public Product? Product { get; set; }
    }
}