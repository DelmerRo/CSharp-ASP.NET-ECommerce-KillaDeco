namespace WebKillaDeco.Models
{
    public class DetailOrderSupplier
    {
        public int DetailOrderSupplierId { get; set; }
        public int SupplierOrderId { get; set; }
        public int ProductId { get; set; }
        public int Amount { get; set; }
        public decimal UnitPrice { get; set; }
        public SupplierOrder? SupplierOrder { get; set; }
        public Product? Product { get; set; }
    }
}