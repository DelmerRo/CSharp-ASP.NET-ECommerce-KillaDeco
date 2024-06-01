namespace WebKillaDeco.Models
{
    public class Location
    {
        public int LocationId { get; set; }
        public string? Name { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }

        // Relación uno a uno con Address
        public Address? Address { get; set; }

        public List<StockItem>? StockItems { get; set; }
    }
}
