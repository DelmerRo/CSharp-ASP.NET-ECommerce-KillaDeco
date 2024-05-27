namespace WebKillaDeco.Models
{
    public class Cart
    {
        public int CartId { get; set; }
        public int ClientId { get; set; }
        public bool Active { get; set; }
        public decimal Subtotal => CartItems?.Sum(item => item.Subtotal) ?? 0;
        public Client Client { get; set; }
        public List<CartItem> CartItems { get; set; }
    }
}
