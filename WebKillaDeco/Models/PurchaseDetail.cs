namespace WebKillaDeco.Models
{
    public class PurchaseDetail
    {
        public int PurchaseDetailId { get; set; }
        public int PurchaseId { get; set; }
        public int ProductId { get; set; }
        public Purchase Purchase { get; set; }
        public Product Product { get; set; }
        public decimal UnitPrice { get; set; }
        public int Amount { get; set; }
        public decimal Subtotal => UnitPrice * Amount;
    }
}