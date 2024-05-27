namespace WebKillaDeco.Models
{
    public class Purchase
    {
        public int PurchaseId { get; set; }
        public int ClientId { get; set; }
        public int AddressId { get; set; }
        public DateTime PurchaseDate { get; set; }
        public decimal Total { get; set; }
        public Client Client { get; set; }
        public Address Address { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public State Status { get; set; }
        public List<PurchaseDetail> PurchaseDetails { get; set; }
    }
}
