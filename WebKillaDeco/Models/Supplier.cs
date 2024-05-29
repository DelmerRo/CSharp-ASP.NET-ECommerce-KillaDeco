namespace WebKillaDeco.Models
{
    public class Supplier: User
    {
        public string? Cuit { get; set; }
        public List<SupplierOrder>? SupplierOrders { get; set; }
    }
}
