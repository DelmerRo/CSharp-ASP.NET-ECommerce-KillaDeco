namespace WebKillaDeco.Models
{
    public class StockItem
    {
        public int StockItemId { get; set; }
        public int LocationId { get; set; }
        public int ProductId { get; set; }
        public Location Location { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
    }
}
