namespace WebKillaDeco.Models
{
    public class SupplierOrder
    {
        public int SupplierOrderId { get; set; }
        public int SupplierId { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime ReceptionDate { get; set; }
        public State State { get; set; }
        public Supplier? Supplier { get; set; }
        public List<DetailOrderSupplier>? DetailsOrderSupplier { get; set; }
    }
}