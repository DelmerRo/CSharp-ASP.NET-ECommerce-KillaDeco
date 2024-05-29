namespace WebKillaDeco.Models
{
    public class Location
    {
        public int LocationId { get; set; }
        public int AddressId { get; set; }
        public string? Name { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public Address? Address { get; set; }
        public List<StockItem>? StockItems { get; set; }
    }
}
