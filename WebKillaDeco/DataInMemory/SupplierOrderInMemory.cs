using WebKillaDeco.Models;

namespace WebKillaDeco.DataInMemory
{
    public class SupplierOrderInMemory
    {
        public static List<SupplierOrder> GetSupplierOrders()
        {
            List<SupplierOrder> supplierOrders = new()
            {
                new SupplierOrder
                {
                    SupplierId = 1,
                    OrderDate = DateTime.Now.AddDays(-10),
                    ReceptionDate = DateTime.Now.AddDays(-5),
                    State = State.Pending
                },
                new SupplierOrder
                {
                    SupplierId = 2,
                    OrderDate = DateTime.Now.AddDays(-8),
                    ReceptionDate = DateTime.Now.AddDays(-3),
                    State = State.Completed
                },
                new SupplierOrder
                {
                    SupplierId = 3,
                    OrderDate = DateTime.Now.AddDays(-6),
                    ReceptionDate = DateTime.Now.AddDays(-2),
                    State = State.Pending
                },
                new SupplierOrder
                {
                    SupplierId = 4,
                    OrderDate = DateTime.Now.AddDays(-4),
                    ReceptionDate = DateTime.Now,
                    State = State.Processing
                },
                new SupplierOrder
                {
                    SupplierId = 5,
                    OrderDate = DateTime.Now.AddDays(-2),
                    ReceptionDate = DateTime.Now.AddDays(2),
                    State = State.Shipped
                }
            };

            return supplierOrders;
        }
    }
}
